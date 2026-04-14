[English](README.md) | [简体中文](README.zh-CN.md)

.NET Library Viewer

[![NuGet](https://img.shields.io/nuget/v/DotnetLibraryViewer.svg)](https://www.nuget.org/packages/DotnetLibraryViewer/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/DotnetLibraryViewer.svg)](https://www.nuget.org/packages/DotnetLibraryViewer/)
[![License](https://img.shields.io/github/license/fengb3/DotnetLibraryViewer.svg)](https://github.com/fengb3/DotnetLibraryViewer)

一个 .NET 命令行工具，读取程序集元数据并为 NuGet 包或本地 DLL 生成 Markdown 文档。

## 功能特性

- 浏览任意 NuGet 包或本地 DLL 的类型和成员
- 支持通配符搜索类型和成员
- 详细视图包含 XML 文档注释、方法签名、参数说明
- 跨平台支持（Windows、Linux、macOS），通过 AOT 原生二进制文件运行

## 前置条件

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)（用于 `dotnet tool` 安装）

## 安装

```bash
dotnet tool install -g DotnetLibraryViewer
```

## 用法

```bash
# 生成完整 Markdown 文档
dotnet-lib-view doc <包名>

# 按关键字搜索类型（通配符：* 和 ?）
dotnet-lib-view query-type <包名> -k <模式>

# 按关键字搜索成员
dotnet-lib-view query-member <包名> -k <模式>

# 查看类型或成员的详细信息
dotnet-lib-view detail <包名> -t <类型名>
dotnet-lib-view detail <包名> -t <类型名> -m <成员名>

# 使用本地 DLL
dotnet-lib-view doc ./path/to/library.dll
dotnet-lib-view query-type ./path/to/library.dll -k *Service*
dotnet-lib-view detail ./path/to/library.dll -t MyClass -m MyMethod
```

### 选项

| 选项 | 说明 |
|--------|------|
| `--package-version <ver>` | 包版本（NuGet 模式） |
| `--framework <tfm>` | 目标框架名称（如 net8.0） |
| `--xml <path>` | XML 文档文件路径（本地 DLL 模式） |
| `--output <file>` | 输出 Markdown 文件路径（仅 `doc` 命令） |

## 示例

```bash
# 搜索 Newtonsoft.Json 中的序列化器类型
dotnet-lib-view query-type Newtonsoft.Json -k *Serializer*

# 搜索与序列化相关的成员
dotnet-lib-view query-member Newtonsoft.Json -k *Serialize*

# 查看特定类型的详细信息
dotnet-lib-view detail Newtonsoft.Json -t JsonSerializer

# 查看特定方法的详细信息
dotnet-lib-view detail Newtonsoft.Json -t JsonSerializer -m Serialize

# 生成并保存完整文档
dotnet-lib-view doc Newtonsoft.Json --output docs.md

# 使用指定版本和框架
dotnet-lib-view doc Newtonsoft.Json --package-version 13.0.3 --framework net8.0
```

## 作为 Claude Code Skill 安装

本工具也作为 Claude Code 技能提供，允许 Claude 直接查询 .NET 程序集元数据。

1. 从 [GitHub Releases](https://github.com/fengb3/DotnetLibraryViewer/releases?q=skill) 下载最新的 `.skill` 文件
2. 使用以下命令安装：

```bash
claude install-skill dotnet-library-viewer.skill
```

## 许可证

[MIT](LICENSE)
