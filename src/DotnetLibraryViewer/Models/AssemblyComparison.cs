namespace DotnetLibraryViewer.Models;

public sealed record VersionComparisonResult(
    string PackageName,
    string Version1,
    string Version2,
    IReadOnlyList<TypeInfo> AddedTypes,
    IReadOnlyList<TypeInfo> RemovedTypes,
    IReadOnlyList<TypeMemberDiff> ChangedTypes
);

public sealed record TypeMemberDiff(
    TypeInfo TypeInV2,
    IReadOnlyList<MemberInfo> AddedMembers,
    IReadOnlyList<MemberInfo> RemovedMembers,
    IReadOnlyList<MemberInfo> NewlyObsoleteMembers
);
