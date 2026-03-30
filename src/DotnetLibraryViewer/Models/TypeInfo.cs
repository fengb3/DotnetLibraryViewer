namespace DotnetLibraryViewer.Models;

public enum TypeKind
{
    Class,
    Struct,
    Enum,
    Interface,
    Delegate
}

public sealed record TypeInfo(
    string Name,
    string FullName,
    string? Namespace,
    TypeKind Kind,
    string? BaseType,
    bool IsStatic,
    bool IsAbstract,
    bool IsSealed,
    int GenericParameterCount,
    IReadOnlyList<string> GenericParameterNames,
    IReadOnlyList<string> Interfaces,
    IReadOnlyList<MemberInfo> Members,
    string? XmlDocSummary
);
