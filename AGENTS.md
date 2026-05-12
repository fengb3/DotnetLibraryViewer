# AGENTS.md

Guidance for AI agents working in this repository. Also linked as `CLAUDE.md`.

## Build & Test

```bash
dotnet build                                                    # Build
dotnet test                                                     # All tests (xUnit, ~47)
dotnet test --filter "FullyQualifiedName~WildcardMatcherTests"  # Single test class
dotnet run --project src/DotnetLibraryViewer -- --help          # CLI help
dotnet publish src/DotnetLibraryViewer -r win-x64 -c Release    # AOT publish (requires MSVC)
```

Tests are pure unit tests — no NuGet network calls, no I/O. Fast.

## Release

Bump `<Version>` in `src/DotnetLibraryViewer/DotnetLibraryViewer.csproj`, commit, push to main.
The `release.yml` workflow detects the version change and auto-publishes: NuGet package + AOT binaries (win-x64, linux-x64, osx-x64, osx-arm64) + `.skill` file.

Commit message convention: `chore: bump version to X.Y.Z`

## Architecture

`dotnet lib-view` is a .NET 10 AOT-compatible CLI tool that reads .NET assembly metadata and outputs Markdown documentation.

**Data pipeline:** `PackageResolver` → `AssemblyReader` → `XmlDocReader` → `MarkdownGenerator`

```
src/DotnetLibraryViewer/
  Program.cs            # System.CommandLine 2.0 CLI setup, all subcommands
  PackageResolver.cs    # Shells out to dotnet CLI to resolve NuGet packages
  AssemblyReader.cs     # System.Reflection.Metadata reader (core)
  XmlDocReader.cs       # XML doc parser → Dictionary<string, MemberDoc>
  MarkdownGenerator.cs  # AssemblyInfo → Markdown
  ApiComparer.cs        # Diff two AssemblyInfo instances
  OutputFormatter.cs    # Console output for query/detail/compare
  WildcardMatcher.cs    # Glob pattern → regex
  NuGetSearchClient.cs  # NuGet search API client
  UpdateChecker.cs      # Daily silent update check
  Models/               # Immutable sealed records

tests/DotnetLibraryViewer.Tests/
  *Tests.cs             # One test file per source file
```

- **AssemblyReader.cs** — Two `ISignatureTypeProvider<string, object?>` implementations: `DisplaySignatureProvider` (C# display strings) and `DocIdSignatureProvider` (fully-qualified XML doc ID format).
- **XmlDocReader.cs** — Builds `Dictionary<string, MemberDoc>` keyed by doc ID prefixes (`T:`, `M:`, `P:`, `F:`, `E:`).
- **Models/** — Immutable `sealed record` types: `AssemblyInfo`, `TypeInfo`, `MemberInfo`, `ParameterInfo`, `AssemblyComparison` (`VersionComparisonResult`, `TypeMemberDiff`), plus enums `TypeKind`, `MemberKind`, `Accessibility`.

## CLI Commands

```
dotnet lib-view doc <package> [options]                                   # Full Markdown documentation
dotnet lib-view query-type <package> -k <pattern> [options]               # List types matching wildcard
dotnet lib-view query-member <package> -k <pattern> [-t <type>] [options] # List members matching wildcard
dotnet lib-view detail <package> -t <type> [-m <member>] [options]        # Show full type/member details
dotnet lib-view compare-version <package> -v1 <ver> -v2 <ver> [options]   # Compare API surface between versions
```

Shared options: `--package-version`, `--framework`, `--xml`, `-n`/`--namespace`. Exceptions: `compare-version` uses `-v1`/`-v2` and omits `--xml`; `doc` adds `--output`.

Auto-detects NuGet vs local DLL mode based on whether input ends with `.dll` and the file exists.
Tool name: `dotnet-lib-view` (invoked as `dotnet lib-view` when installed as a .NET tool).

## Critical Gotchas

### System.CommandLine 2.0 swallows handler exceptions

`ParseResult.InvokeAsync()` catches exceptions thrown inside `SetAction` handlers, prints a full stack trace to stderr as "Unhandled exception", and returns exit code 1. The exception does **not** propagate to the caller.

**Do not** rely on outer `try/catch` around `InvokeAsync()` for error handling. Instead, catch exceptions **inside** each handler. Use `TryResolveAndReadAsync()` (returns `null` on failure) rather than letting `PackageResolutionException` escape the handler.

### No runtime System.Reflection

AOT compatibility means `System.Reflection` is forbidden. Use `System.Reflection.Metadata` exclusively. The `using SR = System.Reflection` alias exists solely to access attribute enums (`TypeAttributes`, `MethodAttributes`, etc.) without namespace collisions.

### Solution file is `.slnx`

The solution uses the new XML-based `.slnx` format (`DotnetLibraryViewer.slnx`), not `.sln`.

## Adding a New Subcommand

Follow the pattern in `Program.cs`:

1. `Command` with own `Argument<string>("package")` + shared options
2. Call `TryResolveAndReadAsync()` (not `ResolveAndReadCoreAsync()`) — check for `null` return
3. Format output via `OutputFormatter.cs`, never inline in `Program.cs`
4. Register via `rootCommand.Subcommands.Add(...)`
5. Add examples to `CommandExamples` dictionary (not command description)
6. Naming: kebab-case commands (`query-type`), single-dash short aliases (`-k`, `-t`)
