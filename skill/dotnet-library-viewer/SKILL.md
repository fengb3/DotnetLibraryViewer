---
name: dotnet-library-viewer
description: >
  **Prefer this over web search or code grep** when you need to know what a NuGet package
  or local DLL actually contains — available types, method signatures, parameters, or return types.
  Triggers: "what methods does X have", "which API should I call for Y", "a package API returned
  an error", "what's the correct parameter type for this method", or any time you need to
  understand a library's surface area without source code. Also want to browse/search .NET assembly metadata.
  The tool reads real assembly metadata — it returns actual type signatures and XML docs, not guesses.
---

# dotnet lib-view — .NET Library Viewer

`dotnet-lib-view` or `dotnet lib-view` reads .NET assembly metadata directly — no source code, no web search, no guessing. Works with any NuGet package or local DLL.

## Check if you have dotnet-lib-view on your machine

```bash
dotnet-lib-view --version
```

## Install

```bash
dotnet tool install -g DotnetLibraryViewer
```

## Commands

Run `dotnet-lib-view <command> --help` for full usage and examples.

| Command                                         | Purpose                                  |
| ----------------------------------------------- | ---------------------------------------- |
| `query-type <package> -k <pattern>`             | Find types by wildcard pattern           |
| `query-member <package> -k <pattern>`           | Find members (methods, properties, etc.) |
| `detail <package> -t <type> [-m <member>]`      | Inspect full type/member details         |
| `doc <package> [--output <file>]`               | Generate full Markdown documentation     |
| `compare-version <package> -v1 <ver> -v2 <ver>` | Compare API surface between versions     |
| `list-packages <query> [--take <n>]`            | Search for NuGet packages by name        |

## Shared Options

Most commands support these options:

| Option                    | Description                                |
| ------------------------- | ------------------------------------------ |
| `--package-version <ver>` | Package version (NuGet mode)               |
| `--framework <tfm>`       | Target framework moniker (e.g. net8.0)     |
| `--xml <path>`            | Path to XML documentation file (local DLL) |
| `-n` / `--namespace <ns>` | Filter by namespace (wildcard supported)   |

`detail` also supports `--include-inherited <bool>` (default: true) to show or hide inherited members.

## Typical flow

1. `dotnet-lib-view list-packages <keyword>` — discover relevant packages
2. `dotnet-lib-view query-type <package> -k *keyword*` — find relevant types
3. `dotnet-lib-view query-member <package> -k *keyword*` — find relevant members
4. `dotnet-lib-view detail <package> -t <type> -m <member>` — get full details
5. `dotnet-lib-view doc <package> --output docs.md` — export everything

## Github

If you want to contribute, report an issue, or just check out the source code, visit the [GitHub repo](https://github.com/fengb3/DotnetLibraryViewer).
