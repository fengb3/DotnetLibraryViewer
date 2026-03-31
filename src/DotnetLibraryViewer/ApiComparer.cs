using DotnetLibraryViewer.Models;

namespace DotnetLibraryViewer;

public static class ApiComparer
{
    public static VersionComparisonResult Compare(AssemblyInfo v1, AssemblyInfo v2)
    {
        var v1Types = v1.Types.ToDictionary(t => t.FullName);
        var v2Types = v2.Types.ToDictionary(t => t.FullName);

        var addedTypes = v2.Types
            .Where(t => !v1Types.ContainsKey(t.FullName))
            .OrderBy(t => t.FullName)
            .ToList();

        var removedTypes = v1.Types
            .Where(t => !v2Types.ContainsKey(t.FullName))
            .OrderBy(t => t.FullName)
            .ToList();

        var newlyObsoleteTypes = v2.Types
            .Where(t => t.IsObsolete
                     && v1Types.TryGetValue(t.FullName, out var v1t)
                     && !v1t.IsObsolete)
            .OrderBy(t => t.FullName)
            .ToList();

        var changedTypes = new List<TypeMemberDiff>();
        foreach (var v2Type in v2.Types.OrderBy(t => t.FullName))
        {
            if (!v1Types.TryGetValue(v2Type.FullName, out var v1Type))
                continue;

            var v1DocIds = v1Type.Members.Select(m => m.DocId).ToHashSet();
            var v2DocIds = v2Type.Members.Select(m => m.DocId).ToHashSet();

            // Use lookup for v1 members to handle duplicate DocIds (e.g., operator overloads)
            var v1MemberLookup = v1Type.Members.ToLookup(m => m.DocId);
            var v2MemberLookup = v2Type.Members.ToLookup(m => m.DocId);

            var addedMembers = v2Type.Members
                .Where(m => !v1DocIds.Contains(m.DocId))
                .ToList();

            var removedMembers = v1Type.Members
                .Where(m => !v2DocIds.Contains(m.DocId))
                .ToList();

            var newlyObsolete = v2Type.Members
                .Where(m => m.IsObsolete
                         && v1MemberLookup.Contains(m.DocId)
                         && !v1MemberLookup[m.DocId].Any(v1m => v1m.IsObsolete))
                .ToList();

            if (addedMembers.Count > 0 || removedMembers.Count > 0 || newlyObsolete.Count > 0)
            {
                changedTypes.Add(new TypeMemberDiff(v2Type, addedMembers, removedMembers, newlyObsolete));
            }
        }

        return new VersionComparisonResult(
            v2.Name,
            v1.Version ?? "?",
            v2.Version ?? "?",
            addedTypes,
            removedTypes,
            newlyObsoleteTypes,
            changedTypes
        );
    }

    public static VersionComparisonResult FilterByNamespace(VersionComparisonResult result, string nsPattern)
    {
        bool MatchesNs(TypeInfo t) =>
            t.Namespace is not null && WildcardMatcher.IsMatch(t.Namespace, nsPattern);

        bool MatchesNsDiff(TypeMemberDiff d) => MatchesNs(d.TypeInV2);

        return result with
        {
            AddedTypes = result.AddedTypes.Where(MatchesNs).ToList(),
            RemovedTypes = result.RemovedTypes.Where(MatchesNs).ToList(),
            NewlyObsoleteTypes = result.NewlyObsoleteTypes.Where(MatchesNs).ToList(),
            ChangedTypes = result.ChangedTypes.Where(MatchesNsDiff).ToList()
        };
    }
}
