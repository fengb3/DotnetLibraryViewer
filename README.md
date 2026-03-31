# dlv - .NET Library Viewer

[![NuGet](https://img.shields.io/nuget/v/DotnetLibraryViewer.svg)](https://www.nuget.org/packages/DotnetLibraryViewer/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/DotnetLibraryViewer.svg)](https://www.nuget.org/packages/DotnetLibraryViewer/)
[![License](https://img.shields.io/github/license/fengb3/DotnetLibraryViewer.svg)](https://github.com/fengb3/DotnetLibraryViewer)

A .NET CLI tool that reads assembly metadata and outputs Markdown documentation for NuGet packages or local DLLs.

一个 .NET 命令行工具，读取程序集元数据并为 NuGet 包或本地 DLL 生成 Markdown 文档。

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

---

## 功能特性

- 浏览任意 NuGet 包或本地 DLL 的类型和成员
- 支持通配符搜索类型和成员
- 详细视图包含 XML 文档注释、方法签名、参数说明
- 跨平台支持（Windows、Linux、macOS），提供 AOT 原生二进制

## 前置条件

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

## 安装

```bash
dotnet tool install -g DotnetLibraryViewer
```

## 用法

```bash
# 生成完整 Markdown 文档
dlv doc <包名>

# 按关键字搜索类型（通配符：* 和 ?）
dlv query-type <包名> -k <模式>

# 按关键字搜索成员
dlv query-member <包名> -k <模式>

# 查看类型或成员的详细信息
dlv detail <包名> -t <类型名>
dlv detail <包名> -t <类型名> -m <成员名>

# 使用本地 DLL
dlv doc ./path/to/library.dll
dlv query-type ./path/to/library.dll -k *Service*
dlv detail ./path/to/library.dll -t MyClass -m MyMethod
```

## 示例

```bash
# 搜索 Newtonsoft.Json 中的序列化器类型
dlv query-type Newtonsoft.Json -k *Serializer*

# 搜索与序列化相关的成员
dlv query-member Newtonsoft.Json -k *Serialize*

# 查看特定类型的详细信息
dlv detail Newtonsoft.Json -t JsonSerializer

# 查看特定方法的详细信息
dlv detail Newtonsoft.Json -t JsonSerializer -m Serialize

# 生成并保存完整文档
dlv doc Newtonsoft.Json --output docs.md
```

## 许可证

[MIT](LICENSE)
