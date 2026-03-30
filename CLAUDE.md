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

`dlv` is a .NET 10 AOT-compatible CLI tool that reads .NET assembly metadata and outputs Markdown documentation.

**Data pipeline:** `PackageResolver` -> `AssemblyReader` -> `XmlDocReader` -> `MarkdownGenerator`

- **PackageResolver.cs** — Resolves NuGet packages by shelling out to `dotnet add package` + `dotnet restore` in a temp project, then finding the DLL/XML in `~/.nuget/packages/`. Also supports local DLL paths.
- **AssemblyReader.cs** — Core component. Uses `System.Reflection.Metadata` (`MetadataReader` + `PEReader`) to read public types and members without runtime reflection. Contains two `ISignatureTypeProvider<string, object?>` implementations:
  - `DisplaySignatureProvider` — decodes signatures to C# display strings (`int`, `List<string>`)
  - `DocIdSignatureProvider` — decodes to fully-qualified XML doc ID format (`System.Int32`, with `{...}` for generics)
- **XmlDocReader.cs** — Parses XML doc files via `XDocument`, builds a `Dictionary<string, MemberDoc>` keyed by doc ID strings (`T:`, `M:`, `P:`, `F:`, `E:` prefixes).
- **MarkdownGenerator.cs** — Pure function converting `AssemblyInfo` model into Markdown with tables per member kind, grouped by namespace.
- **Program.cs** — `System.CommandLine` 2.0 setup. Single positional argument (package name or DLL path) with options.

**Key constraint:** No runtime `System.Reflection` — AOT compatibility requires `System.Reflection.Metadata` exclusively. Uses `using SR = System.Reflection` alias to access `TypeAttributes`, `MethodAttributes`, `FieldAttributes` enums without conflicting with the `Models` namespace.

## Models (Models/)

Immutable `sealed record` types: `AssemblyInfo`, `TypeInfo`, `MemberInfo`, `ParameterInfo`, plus enums `TypeKind`, `MemberKind`, `Accessibility`. The `TypeInfo.Members` list is cast to `List<TypeInfo>` in `MergeXmlDocs` for mutation during XML doc merging.

## CLI Options

```
dlv <package> [--package-version <ver>] [--framework <tfm>] [--output <file>] [--xml <path>]
```

Auto-detects NuGet vs local DLL mode based on whether input ends with `.dll` and the file exists.
