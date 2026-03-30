namespace DotnetLibraryViewer.Models;

public sealed record AssemblyInfo(
    string Name,
    string? Version,
    string? XmlDocSummary,
    IReadOnlyList<TypeInfo> Types
);
