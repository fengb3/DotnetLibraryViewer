---
name: dotnet-library-viewer
description: >
  Use this skill when a developer needs to explore or understand types, methods, properties,
  or APIs inside a NuGet package or local DLL — especially when they don't know what's available
  or can't find the right class/method for their task. This covers scenarios like: "what types are
  in this package", "how do I use class X from this library", "find methods related to Y", "show
  me the API surface of this DLL", "I don't know which class handles Z". Also trigger when users
  mention dlv, DotnetLibraryViewer, or want to browse/search .NET assembly metadata. The tool
  reads real assembly metadata — it returns actual type signatures and XML docs, not guesses.
  Works with any AI assistant ( Claude Code, Copilot, Cursor, etc.) and standalone CLI usage.
---

# dlv — .NET Library Viewer

When a developer is working with a .NET library and doesn't know what types or members are available, `dlv` lets you read the actual assembly metadata directly — no source code, no web search, no guessing. It works with any NuGet package or local DLL and returns real type signatures, member lists, and XML doc comments.

This is especially useful for obscure or poorly-documented libraries where web search won't help.

## AI Assistants

This skill works with any AI coding assistant. The instructions below use `dlv` CLI commands that the AI agent can run directly in the terminal. Whether you're using Claude Code, GitHub Copilot, Cursor, Windsurf, or any other AI tool with terminal access, the workflow is the same: install dlv, then run queries.

## Quick Start

```bash
# Install (requires .NET 10.0 SDK)
dotnet tool install -g DotnetLibraryViewer

# Start exploring any package
dlv query-type <package-name> -k *
```

## Commands

`<package>` is either a NuGet package name or a path to a `.dll` file. Auto-detected based on whether the input ends with `.dll` and the file exists.

### `dlv query-type <package> -k <pattern>` — Find types

Wildcard search (`*` any chars, `?` single char). Case-insensitive.

```bash
dlv query-type Newtonsoft.Json -k *Serializer*
dlv query-type ./mylib.dll -k *Service*
```

### `dlv query-member <package> -k <pattern>` — Find members

Search methods, properties, fields, events across all types. Optionally filter by type with `-t`.

```bash
dlv query-member Newtonsoft.Json -k *Serialize*
dlv query-member Newtonsoft.Json -k *Serialize* -t JsonSerializer
```

### `dlv detail <package> -t <type> [-m <member>]` — Inspect details

Full signatures, XML doc comments, parameters, return types.

```bash
dlv detail Newtonsoft.Json -t JsonSerializer
dlv detail Newtonsoft.Json -t JsonSerializer -m Serialize
```

### `dlv doc <package> [--output <file>]` — Generate full docs

Complete Markdown with all types/members grouped by namespace.

```bash
dlv doc Newtonsoft.Json --output docs.md
dlv doc ./library.dll --xml ./library.xml --output api.md
```

## Options

| Option | Description |
|--------|-------------|
| `--package-version <ver>` | NuGet package version |
| `--framework <tfm>` | Target framework (e.g. `net8.0`) |
| `--xml <path>` | XML doc file (local DLL mode) |
| `--output <file>` | Output file (`doc` only) |

## Typical exploration flow

When a developer says they don't know how to use a library or can't find the right API:

1. **Find relevant types**: `dlv query-type <package> -k *keyword*`
2. **Find relevant members**: `dlv query-member <package> -k *keyword*`
3. **Get full details**: `dlv detail <package> -t <type> -m <member>`
4. **Export everything**: `dlv doc <package> --output docs.md`

## Notes

- Uses `System.Reflection.Metadata` — reads any .NET assembly without loading it
- XML doc comments are included when available (NuGet packages usually include them)
- Published on NuGet: https://www.nuget.org/packages/DotnetLibraryViewer/
