[English](README.md) | [简体中文](README.zh-CN.md)

# dlv - .NET Library Viewer

[![NuGet](https://img.shields.io/nuget/v/DotnetLibraryViewer.svg)](https://www.nuget.org/packages/DotnetLibraryViewer/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/DotnetLibraryViewer.svg)](https://www.nuget.org/packages/DotnetLibraryViewer/)
[![License](https://img.shields.io/github/license/fengb3/DotnetLibraryViewer.svg)](https://github.com/fengb3/DotnetLibraryViewer)

A .NET CLI tool that reads assembly metadata and outputs Markdown documentation for NuGet packages or local DLLs.

## Features

- Browse types and members from any NuGet package or local DLL
- Wildcard-powered search for types and members
- Full detail view with XML documentation, signatures, and parameters
- Cross-platform (Windows, Linux, macOS) via AOT native binaries

## Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) (for `dotnet tool` install)

## Install

```bash
dotnet tool install -g DotnetLibraryViewer
```

## Usage

```bash
# Generate full Markdown documentation
dlv doc <package>

# Search types by keyword (wildcards: * and ?)
dlv query-type <package> -k <pattern>

# Search members by keyword
dlv query-member <package> -k <pattern>

# Show full details of a type or member
dlv detail <package> -t <type-name>
dlv detail <package> -t <type-name> -m <member-name>

# Use a local DLL
dlv doc ./path/to/library.dll
dlv query-type ./path/to/library.dll -k *Service*
dlv detail ./path/to/library.dll -t MyClass -m MyMethod
```

### Options

| Option | Description |
|--------|-------------|
| `--package-version <ver>` | Package version (NuGet mode) |
| `--framework <tfm>` | Target framework moniker (e.g. net8.0) |
| `--xml <path>` | Path to XML documentation file (local DLL mode) |
| `--output <file>` | Output markdown file path (`doc` only) |

## Examples

```bash
# Search for serializer types in Newtonsoft.Json
dlv query-type Newtonsoft.Json -k *Serializer*

# Search for serialize-related members
dlv query-member Newtonsoft.Json -k *Serialize*

# View details of a specific type
dlv detail Newtonsoft.Json -t JsonSerializer

# View details of a specific method
dlv detail Newtonsoft.Json -t JsonSerializer -m Serialize

# Generate and save full documentation
dlv doc Newtonsoft.Json --output docs.md

# Use a specific version and framework
dlv doc Newtonsoft.Json --package-version 13.0.3 --framework net8.0
```

## License

[MIT](LICENSE)
