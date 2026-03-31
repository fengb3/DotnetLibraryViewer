namespace DotnetLibraryViewer.Models;

public enum MemberKind
{
    Method,
    Constructor,
    Property,
    Field,
    Event
}

public enum Accessibility
{
    Public,
    Internal,
    Protected,
    Private,
    ProtectedInternal,
    PrivateProtected
}

public sealed record ParameterInfo(
    string Name,
    string Type,
    bool IsRef,
    bool IsOut,
    bool IsParams
);

public sealed record MemberInfo(
    string Name,
    string DocId,
    MemberKind Kind,
    string Signature,
    string? TypeName,
    Accessibility Accessibility,
    bool IsStatic,
    bool IsVirtual,
    bool IsAbstract,
    IReadOnlyList<ParameterInfo> Parameters,
    string? ReturnType,
    string? XmlDocSummary,
    IReadOnlyDictionary<string, string>? XmlDocParameters = null,
    IReadOnlyDictionary<string, string>? XmlDocTypeParameters = null,
    string? XmlDocReturns = null
);
