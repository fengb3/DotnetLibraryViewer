using System.CommandLine;
using System.Text;
using DotnetLibraryViewer.Models;

namespace DotnetLibraryViewer;

public static class Program
{
    private static string WithExamples(string description, params (string desc, string cmd)[] examples)
    {
        var sb = new StringBuilder(description);
        sb.AppendLine();
        sb.AppendLine();
        sb.Append("Examples:");
        foreach (var (desc, cmd) in examples)
        {
            sb.AppendLine();
            sb.Append("  # ").Append(desc);
            sb.AppendLine();
            sb.Append("  ").Append(cmd);
        }
        return sb.ToString();
    }

    public static async Task<int> Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        // Shared options (applied to each subcommand individually to avoid duplicate usage display)
        var versionOption = new Option<string?>("--package-version") { Description = "Package version (NuGet mode)" };
        var frameworkOption = new Option<string?>("--framework") { Description = "Target framework moniker (e.g. net8.0)" };
        var xmlOption = new Option<string?>("--xml") { Description = "Path to XML documentation file (local DLL mode)" };
        var namespaceOption = new Option<string?>("--namespace", "-n") { Description = "Filter by namespace (wildcard supported)" };

        var rootCommand = new RootCommand("dotnet lib-view - .NET Library Viewer: inspect NuGet packages and DLLs");

        // === doc subcommand (original full markdown output) ===
        var docPackageArg = new Argument<string>("package") { Description = "NuGet package name or path to a DLL file" };
        var outputOption = new Option<string?>("--output") { Description = "Output markdown file path" };

        var docCommand = new Command("doc", WithExamples(
            "Generate full Markdown documentation for a package",
            ("Print docs to console", "dotnet lib-view doc Newtonsoft.Json"),
            ("Save to file", "dotnet lib-view doc ./MyLib.dll --output docs.md"),
            ("Filter by namespace", "dotnet lib-view doc Serilog --package-version 3.1.1 -n Serilog*")))
        {
            docPackageArg,
            versionOption,
            frameworkOption,
            outputOption,
            xmlOption,
            namespaceOption
        };

        docCommand.SetAction(async (parseResult, ct) =>
        {
            var package = parseResult.GetValue(docPackageArg)!;
            var version = parseResult.GetValue(versionOption);
            var framework = parseResult.GetValue(frameworkOption);
            var output = parseResult.GetValue(outputOption);
            var xml = parseResult.GetValue(xmlOption);
            var nsFilter = parseResult.GetValue(namespaceOption);

            var assembly = await ResolveAndReadAsync(package, version, framework, xml, ct);

            if (nsFilter is not null)
            {
                assembly = assembly with
                {
                    Types = assembly.Types
                        .Where(t => t.Namespace is not null && WildcardMatcher.IsMatch(t.Namespace, nsFilter))
                        .ToList()
                };
            }

            var markdown = MarkdownGenerator.Generate(assembly);

            if (output is not null)
            {
                await File.WriteAllTextAsync(output, markdown, ct);
                Console.Error.WriteLine($"Documentation written to {output}");
            }
            else
            {
                Console.WriteLine(markdown);
            }

            return 0;
        });

        // === query-type subcommand ===
        var qtPackageArg = new Argument<string>("package") { Description = "NuGet package name or path to a DLL file" };
        var qtKeywordOption = new Option<string>("--keyword", "-k") { Description = "Wildcard pattern to match type names (* and ? supported)", Required = true };

        var queryTypeCommand = new Command("query-type", WithExamples(
            "List types matching a keyword pattern",
            ("Wildcard search for types", "dotnet lib-view query-type Newtonsoft.Json -k *Serializer*"),
            ("Filter by namespace", "dotnet lib-view query-type System.CommandLine -k Command -n System.CommandLine*")))
        {
            qtPackageArg,
            qtKeywordOption,
            versionOption,
            frameworkOption,
            xmlOption,
            namespaceOption
        };

        queryTypeCommand.SetAction(async (parseResult, ct) =>
        {
            var package = parseResult.GetValue(qtPackageArg)!;
            var keyword = parseResult.GetValue(qtKeywordOption)!;
            var version = parseResult.GetValue(versionOption);
            var framework = parseResult.GetValue(frameworkOption);
            var xml = parseResult.GetValue(xmlOption);
            var nsFilter = parseResult.GetValue(namespaceOption);

            var assembly = await ResolveAndReadAsync(package, version, framework, xml, ct);

            var types = assembly.Types.AsEnumerable();
            if (nsFilter is not null)
                types = types.Where(t => t.Namespace is not null && WildcardMatcher.IsMatch(t.Namespace, nsFilter));

            var matched = types
                .Where(t => WildcardMatcher.IsMatch(t.Name, keyword)
                         || WildcardMatcher.IsMatch(t.FullName, keyword)
                         || WildcardMatcher.IsMatch(t.FullName.Replace('+', '.'), keyword))
                .ToList();

            OutputFormatter.ListTypes(matched);
            return 0;
        });

        // === query-member subcommand ===
        var qmPackageArg = new Argument<string>("package") { Description = "NuGet package name or path to a DLL file" };
        var qmKeywordOption = new Option<string>("--keyword", "-k") { Description = "Wildcard pattern to match member names (* and ? supported)", Required = true };
        var qmTypeOption = new Option<string?>("--type", "-t") { Description = "Limit search to a specific type name (wildcard supported)" };

        var queryMemberCommand = new Command("query-member", WithExamples(
            "List members matching a keyword pattern",
            ("Search members across all types", "dotnet lib-view query-member Newtonsoft.Json -k *Serialize*"),
            ("Limit to a specific type", "dotnet lib-view query-member System.CommandLine -k *Parse* -t Command")))
        {
            qmPackageArg,
            qmKeywordOption,
            qmTypeOption,
            versionOption,
            frameworkOption,
            xmlOption,
            namespaceOption
        };

        queryMemberCommand.SetAction(async (parseResult, ct) =>
        {
            var package = parseResult.GetValue(qmPackageArg)!;
            var keyword = parseResult.GetValue(qmKeywordOption)!;
            var typeFilter = parseResult.GetValue(qmTypeOption);
            var version = parseResult.GetValue(versionOption);
            var framework = parseResult.GetValue(frameworkOption);
            var xml = parseResult.GetValue(xmlOption);
            var nsFilter = parseResult.GetValue(namespaceOption);

            var assembly = await ResolveAndReadAsync(package, version, framework, xml, ct);

            var results = new List<(TypeInfo Type, MemberInfo Member)>();
            foreach (var type in assembly.Types)
            {
                if (nsFilter is not null
                    && (type.Namespace is null || !WildcardMatcher.IsMatch(type.Namespace, nsFilter)))
                    continue;

                if (typeFilter is not null
                    && !WildcardMatcher.IsMatch(type.Name, typeFilter)
                    && !WildcardMatcher.IsMatch(type.FullName, typeFilter)
                    && !WildcardMatcher.IsMatch(type.FullName.Replace('+', '.'), typeFilter))
                    continue;

                foreach (var member in type.Members)
                {
                    if (WildcardMatcher.IsMatch(member.Name, keyword)
                        || WildcardMatcher.IsMatch(member.Signature, keyword))
                    {
                        results.Add((type, member));
                    }
                }
            }

            OutputFormatter.ListMembers(results);
            return 0;
        });

        // === detail subcommand ===
        var dPackageArg = new Argument<string>("package") { Description = "NuGet package name or path to a DLL file" };
        var dTypeOption = new Option<string>("--type", "-t") { Description = "Type name to inspect", Required = true };
        var dMemberOption = new Option<string?>("--member", "-m") { Description = "Member name to inspect (optional)" };

        var detailCommand = new Command("detail", WithExamples(
            "Show detailed information about a type or member",
            ("Inspect a type", "dotnet lib-view detail Newtonsoft.Json -t JsonSerializer"),
            ("Inspect a specific member", "dotnet lib-view detail Newtonsoft.Json -t JsonSerializer -m Serialize"),
            ("Works with local DLLs", "dotnet lib-view detail ./MyLib.dll -t MyNamespace.MyClass")))
        {
            dPackageArg,
            dTypeOption,
            dMemberOption,
            versionOption,
            frameworkOption,
            xmlOption,
            namespaceOption
        };

        detailCommand.SetAction(async (parseResult, ct) =>
        {
            var package = parseResult.GetValue(dPackageArg)!;
            var typeName = parseResult.GetValue(dTypeOption)!;
            var memberName = parseResult.GetValue(dMemberOption);
            var version = parseResult.GetValue(versionOption);
            var framework = parseResult.GetValue(frameworkOption);
            var xml = parseResult.GetValue(xmlOption);
            var nsFilter = parseResult.GetValue(namespaceOption);

            var assembly = await ResolveAndReadAsync(package, version, framework, xml, ct);

            var candidateTypes = assembly.Types.AsEnumerable();
            if (nsFilter is not null)
                candidateTypes = candidateTypes.Where(t => t.Namespace is not null && WildcardMatcher.IsMatch(t.Namespace, nsFilter));
            var candidateList = candidateTypes.ToList();

            var type = candidateList.FirstOrDefault(t =>
                t.Name == typeName || t.FullName == typeName || t.FullName.Replace('+', '.') == typeName);

            if (type is null)
            {
                // Try wildcard match
                type = candidateList.FirstOrDefault(t =>
                    WildcardMatcher.IsMatch(t.Name, typeName) ||
                    WildcardMatcher.IsMatch(t.FullName, typeName) ||
                    WildcardMatcher.IsMatch(t.FullName.Replace('+', '.'), typeName));
            }

            if (type is null)
            {
                Console.Error.WriteLine($"Type '{typeName}' not found.");

                var suggestions = candidateList
                    .Where(t => t.Name.Contains(typeName, StringComparison.OrdinalIgnoreCase)
                             || t.FullName.Contains(typeName, StringComparison.OrdinalIgnoreCase))
                    .Take(5)
                    .ToList();

                if (suggestions.Count > 0)
                {
                    Console.Error.WriteLine("Did you mean:");
                    foreach (var s in suggestions)
                        Console.Error.WriteLine($"  {s.FullName}");
                }

                return 1;
            }

            if (memberName is not null)
            {
                var member = type.Members.FirstOrDefault(m =>
                    m.Name == memberName || WildcardMatcher.IsMatch(m.Name, memberName));

                if (member is null)
                {
                    Console.Error.WriteLine($"Member '{memberName}' not found in type '{type.Name}'.");
                    return 1;
                }

                OutputFormatter.WriteMemberDetail(type, member);
            }
            else
            {
                OutputFormatter.WriteTypeDetail(type);
            }

            return 0;
        });

        // === compare-version subcommand ===
        var cvPackageArg = new Argument<string>("package") { Description = "NuGet package name" };
        var cvV1Option = new Option<string>("--version1", "-v1") { Description = "First version to compare", Required = true };
        var cvV2Option = new Option<string>("--version2", "-v2") { Description = "Second version to compare", Required = true };

        var compareVersionCommand = new Command("compare-version", WithExamples(
            "Compare API surface between two versions of a package",
            ("Compare two versions", "dotnet lib-view compare-version Serilog -v1 2.12.0 -v2 3.1.1"),
            ("Filter diff by namespace", "dotnet lib-view compare-version Newtonsoft.Json -v1 12.0.3 -v2 13.0.3 -n Newtonsoft.Json*")))
        {
            cvPackageArg,
            cvV1Option,
            cvV2Option,
            frameworkOption,
            namespaceOption
        };

        compareVersionCommand.SetAction(async (parseResult, ct) =>
        {
            var package = parseResult.GetValue(cvPackageArg)!;
            var version1 = parseResult.GetValue(cvV1Option)!;
            var version2 = parseResult.GetValue(cvV2Option)!;
            var framework = parseResult.GetValue(frameworkOption);
            var nsFilter = parseResult.GetValue(namespaceOption);

            if (package.EndsWith(".dll", StringComparison.OrdinalIgnoreCase) && File.Exists(package))
            {
                Console.Error.WriteLine("Error: compare-version requires a NuGet package name, not a DLL path.");
                return 1;
            }

            Console.Error.WriteLine($"Resolving {package} v{version1}...");
            var v1 = await ResolveAndReadAsync(package, version1, framework, null, ct);

            Console.Error.WriteLine($"Resolving {package} v{version2}...");
            var v2 = await ResolveAndReadAsync(package, version2, framework, null, ct);

            var result = ApiComparer.Compare(v1, v2);

            if (nsFilter is not null)
                result = ApiComparer.FilterByNamespace(result, nsFilter);

            OutputFormatter.WriteComparisonResult(result);
            return 0;
        });

        // Add subcommands to root
        rootCommand.Subcommands.Add(docCommand);
        rootCommand.Subcommands.Add(queryTypeCommand);
        rootCommand.Subcommands.Add(queryMemberCommand);
        rootCommand.Subcommands.Add(detailCommand);
        rootCommand.Subcommands.Add(compareVersionCommand);

        return await rootCommand.Parse(args).InvokeAsync();
    }

    private static async Task<AssemblyInfo> ResolveAndReadAsync(
        string package, string? version, string? framework,
        string? xml, CancellationToken ct)
    {
        var isLocalDll = package.EndsWith(".dll", StringComparison.OrdinalIgnoreCase)
                        && File.Exists(package);

        ResolvedPackage resolved;
        if (isLocalDll)
        {
            resolved = PackageResolver.ResolveFromLocalPath(package, xml);
            Console.Error.WriteLine($"Reading local DLL: {package}");
        }
        else
        {
            Console.Error.WriteLine($"Resolving NuGet package: {package}...");
            resolved = await PackageResolver.ResolveFromNuGetAsync(package, version, framework, ct);
            Console.Error.WriteLine($"Found: {resolved.DllPath}");
        }

        var assemblyInfo = AssemblyReader.ReadAssembly(resolved.DllPath);

        var xmlDoc = XmlDocReader.Load(resolved.XmlPath);
        if (xmlDoc is not null && resolved.XmlPath is not null)
        {
            AssemblyReader.MergeXmlDocs(assemblyInfo, xmlDoc);
            Console.Error.WriteLine($"Loaded XML docs: {resolved.XmlPath}");
        }
        else
        {
            Console.Error.WriteLine("No XML documentation found.");
        }

        return assemblyInfo;
    }
}
