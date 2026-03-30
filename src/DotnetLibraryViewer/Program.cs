using System.CommandLine;

namespace DotnetLibraryViewer;

public static class Program
{
    public static async Task<int> Main(string[] args)
    {
        var packageArgument = new Argument<string>("package")
        {
            Description = "NuGet package name or path to a DLL file"
        };

        var versionOption = new Option<string?>("--package-version") { Description = "Package version (NuGet mode)" };
        var frameworkOption = new Option<string?>("--framework") { Description = "Target framework moniker (e.g. net8.0)" };
        var outputOption = new Option<string?>("--output") { Description = "Output markdown file path" };
        var xmlOption = new Option<string?>("--xml") { Description = "Path to XML documentation file (local DLL mode)" };

        var rootCommand = new RootCommand("dlv - .NET Library Viewer: inspect NuGet packages and DLLs")
        {
            packageArgument,
            versionOption,
            frameworkOption,
            outputOption,
            xmlOption
        };

        rootCommand.SetAction(async (parseResult, ct) =>
        {
            var package = parseResult.GetValue(packageArgument)!;
            var version = parseResult.GetValue(versionOption);
            var framework = parseResult.GetValue(frameworkOption);
            var output = parseResult.GetValue(outputOption);
            var xml = parseResult.GetValue(xmlOption);

            return await RunAsync(package, version, framework, output, xml, ct);
        });

        return await rootCommand.Parse(args).InvokeAsync();
    }

    private static async Task<int> RunAsync(
        string package, string? version, string? framework,
        string? output, string? xml, CancellationToken ct)
    {
        try
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

            var markdown = MarkdownGenerator.Generate(assemblyInfo);

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
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
            return 1;
        }
    }
}
