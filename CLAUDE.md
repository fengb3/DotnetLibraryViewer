# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build & Run Commands

```bash
dotnet build                              # Build solution
dotnet test                               # Run all tests
dotnet run --project src/DotnetLibraryViewer -- --help  # Show CLI help
dotnet publish src/DotnetLibraryViewer -r win-x64 -c Release  # AOT publish (requires MSVC)
```

## Architecture

`dotnet lib-view` is a .NET 10 AOT-compatible CLI tool that reads .NET assembly metadata and outputs Markdown documentation.

**Data pipeline:** `PackageResolver` -> `AssemblyReader` -> `XmlDocReader` -> `MarkdownGenerator`

- **PackageResolver.cs** — Resolves NuGet packages by shelling out to `dotnet add package` + `dotnet restore` in a temp project, then finding the DLL/XML in `~/.nuget/packages/`. Also supports local DLL paths.
- **AssemblyReader.cs** — Core component. Uses `System.Reflection.Metadata` (`MetadataReader` + `PEReader`) to read public types and members without runtime reflection. Contains two `ISignatureTypeProvider<string, object?>` implementations:
  - `DisplaySignatureProvider` — decodes signatures to C# display strings (`int`, `List<string>`)
  - `DocIdSignatureProvider` — decodes to fully-qualified XML doc ID format (`System.Int32`, with `{...}` for generics)
- **XmlDocReader.cs** — Parses XML doc files via `XDocument`, builds a `Dictionary<string, MemberDoc>` keyed by doc ID strings (`T:`, `M:`, `P:`, `F:`, `E:` prefixes).
- **MarkdownGenerator.cs** — Pure function converting `AssemblyInfo` model into Markdown with tables per member kind, grouped by namespace.
- **Program.cs** — `System.CommandLine` 2.0 setup. Root command is argument-free; all functionality lives in subcommands.
- **WildcardMatcher.cs** — Converts `*`/`?` wildcard patterns to regex for filtering. Case-insensitive.
- **OutputFormatter.cs** — Console output formatting for query/detail subcommands.

**Key constraint:** No runtime `System.Reflection` — AOT compatibility requires `System.Reflection.Metadata` exclusively. Uses `using SR = System.Reflection` alias to access `TypeAttributes`, `MethodAttributes`, `FieldAttributes` enums without conflicting with the `Models` namespace.

## Models (Models/)

Immutable `sealed record` types: `AssemblyInfo`, `TypeInfo`, `MemberInfo`, `ParameterInfo`, plus enums `TypeKind`, `MemberKind`, `Accessibility`. The `TypeInfo.Members` list is cast to `List<TypeInfo>` in `MergeXmlDocs` for mutation during XML doc merging.

## CLI Commands

```
dotnet lib-view doc <package> [options]                                  # Full Markdown documentation
dotnet lib-view query-type <package> -k <pattern> [options]              # List types matching wildcard
dotnet lib-view query-member <package> -k <pattern> [-t <type>] [options] # List members matching wildcard
dotnet lib-view detail <package> -t <type> [-m <member>] [options]       # Show full type/member details
```

Shared options (on every subcommand): `--package-version`, `--framework`, `--xml`

Auto-detects NuGet vs local DLL mode based on whether input ends with `.dll` and the file exists.

## Adding New Subcommands

Follow the pattern established in `Program.cs`:

1. **Define** a new `Command` with its own `Argument<string>("package")` + shared options (`versionOption`, `frameworkOption`, `xmlOption`). Each subcommand owns its own package argument — the root command has none.
2. **Resolve** the package by calling the shared `ResolveAndReadAsync()` helper, which returns `AssemblyInfo`.
3. **Filter/query** using `WildcardMatcher.IsMatch()` for user-facing pattern matching.
4. **Format output** by adding methods to `OutputFormatter.cs` — never write formatting logic inline in `Program.cs`.
5. **Register** the command via `rootCommand.Subcommands.Add(...)`.
6. **Naming**: kebab-case for command names (`query-type`, `query-member`); short aliases with single dash (`-k`, `-t`, `-m`).
