using System.Text;
using DotnetLibraryViewer.Models;

namespace DotnetLibraryViewer;

public static class OutputFormatter
{
    public static void ListTypes(IEnumerable<TypeInfo> types)
    {
        var list = types.ToList();
        if (list.Count == 0)
        {
            Console.WriteLine("No matching types found.");
            return;
        }

        foreach (var type in list)
        {
            var kind = type.Kind.ToString().ToLowerInvariant();
            var ns = type.Namespace ?? "(Global)";
            var generic = type.GenericParameterCount > 0
                ? $"<{string.Join(", ", type.GenericParameterNames)}>"
                : "";
            var modifiers = BuildTypeModifiers(type);
            Console.WriteLine($"  {modifiers}{kind} {type.Name}{generic}");
            Console.WriteLine($"    Namespace: {ns}");
            if (type.DeclaringType is not null)
                Console.WriteLine($"    Nested in: {type.DeclaringType}");
            if (type.BaseType is not null && type.BaseType is not "System.Object" and not "System.ValueType" and not "System.Enum")
                Console.WriteLine($"    Base: {type.BaseType}");
            if (!string.IsNullOrWhiteSpace(type.XmlDocSummary))
                Console.WriteLine($"    Summary: {Truncate(type.XmlDocSummary, 100)}");
        }

        Console.WriteLine();
        Console.WriteLine($"{list.Count} type(s) found.");
    }

    public static void ListMembers(IEnumerable<(TypeInfo Type, MemberInfo Member)> results)
    {
        var list = results.ToList();
        if (list.Count == 0)
        {
            Console.WriteLine("No matching members found.");
            return;
        }

        string? lastType = null;
        foreach (var (type, member) in list)
        {
            if (type.Name != lastType)
            {
                if (lastType is not null) Console.WriteLine();
                Console.WriteLine($"  {type.Name}:");
                lastType = type.Name;
            }

            var kind = member.Kind.ToString().ToLowerInvariant();
            Console.WriteLine($"    [{kind}] {member.Signature}");
            if (!string.IsNullOrWhiteSpace(member.XmlDocSummary))
                Console.WriteLine($"           {Truncate(member.XmlDocSummary, 100)}");
        }

        Console.WriteLine();
        Console.WriteLine($"{list.Count} member(s) found.");
    }

    public static void WriteTypeDetail(TypeInfo type)
    {
        var kind = type.Kind.ToString().ToLowerInvariant();
        var modifiers = BuildTypeModifiers(type);
        var generic = type.GenericParameterCount > 0
            ? $"<{string.Join(", ", type.GenericParameterNames)}>"
            : "";

        Console.WriteLine($"{modifiers}{kind} {type.Name}{generic}");
        Console.WriteLine($"  Full Name: {type.FullName}");
        Console.WriteLine($"  Namespace: {type.Namespace ?? "(Global)"}");

        if (type.DeclaringType is not null)
            Console.WriteLine($"  Declaring Type: {type.DeclaringType}");

        if (type.BaseType is not null && type.BaseType is not "System.Object" and not "System.ValueType" and not "System.Enum")
            Console.WriteLine($"  Base Type: {type.BaseType}");

        if (type.Interfaces.Count > 0)
            Console.WriteLine($"  Interfaces: {string.Join(", ", type.Interfaces)}");

        if (type.XmlDocTypeParameters is { Count: > 0 })
        {
            Console.WriteLine("  Type Parameters:");
            foreach (var (name, desc) in type.XmlDocTypeParameters)
                Console.WriteLine($"    {name}: {desc}");
        }

        if (!string.IsNullOrWhiteSpace(type.XmlDocSummary))
        {
            Console.WriteLine();
            Console.WriteLine($"  Summary: {type.XmlDocSummary}");
        }

        WriteMemberGroup("Properties", type.Members.Where(m => m.Kind == MemberKind.Property), showType: true);
        WriteMemberGroup("Methods", type.Members.Where(m => m.Kind is MemberKind.Method or MemberKind.Constructor), showType: false);
        WriteMemberGroup("Fields", type.Members.Where(m => m.Kind == MemberKind.Field), showType: true);
        WriteMemberGroup("Events", type.Members.Where(m => m.Kind == MemberKind.Event), showType: true);
    }

    public static void WriteMemberDetail(TypeInfo type, MemberInfo member)
    {
        Console.WriteLine($"Type: {type.FullName}");
        Console.WriteLine($"Member: {member.Name}");
        Console.WriteLine($"  Kind: {member.Kind}");
        Console.WriteLine($"  Signature: {member.Signature}");
        Console.WriteLine($"  Accessibility: {member.Accessibility}");
        var flags = new List<string>();
        if (member.IsStatic) flags.Add("static");
        if (member.IsVirtual) flags.Add("virtual");
        if (member.IsAbstract) flags.Add("abstract");
        if (flags.Count > 0)
            Console.WriteLine($"  Modifiers: {string.Join(", ", flags)}");

        if (member.Parameters.Count > 0)
        {
            Console.WriteLine("  Parameters:");
            foreach (var p in member.Parameters)
            {
                var line = $"    {p.Type} {p.Name}";
                var extras = new List<string>();
                if (p.IsRef) extras.Add("ref");
                if (p.IsOut) extras.Add("out");
                if (p.IsParams) extras.Add("params");
                if (extras.Count > 0)
                    line = $"    {string.Join(" ", extras)} {p.Type} {p.Name}";

                var paramDoc = member.XmlDocParameters?.GetValueOrDefault(p.Name);
                if (!string.IsNullOrWhiteSpace(paramDoc))
                    line += $" — {paramDoc}";
                Console.WriteLine(line);
            }
        }

        if (!string.IsNullOrWhiteSpace(member.ReturnType) && member.ReturnType != "void")
        {
            var returnLine = $"  Returns: {member.ReturnType}";
            if (!string.IsNullOrWhiteSpace(member.XmlDocReturns))
                returnLine += $" — {member.XmlDocReturns}";
            Console.WriteLine(returnLine);
        }

        if (member.XmlDocTypeParameters is { Count: > 0 })
        {
            Console.WriteLine("  Type Parameters:");
            foreach (var (name, desc) in member.XmlDocTypeParameters)
                Console.WriteLine($"    {name}: {desc}");
        }

        if (!string.IsNullOrWhiteSpace(member.XmlDocSummary))
        {
            Console.WriteLine();
            Console.WriteLine($"  Summary: {member.XmlDocSummary}");
        }
    }

    private static void WriteMemberGroup(string title, IEnumerable<MemberInfo> members, bool showType)
    {
        var list = members.ToList();
        if (list.Count == 0) return;

        Console.WriteLine();
        Console.WriteLine($"  {title}:");
        foreach (var m in list)
        {
            var line = showType ? $"    {m.Signature}" : $"    {m.Signature}";
            Console.WriteLine(line);
        }
    }

    private static string BuildTypeModifiers(TypeInfo type)
    {
        var mods = new List<string>();
        if (type.IsStatic) mods.Add("static ");
        if (type.IsAbstract) mods.Add("abstract ");
        if (type.IsSealed) mods.Add("sealed ");
        return mods.Count > 0 ? string.Join("", mods) : "";
    }

    private static string Truncate(string text, int maxLength)
        => text.Length <= maxLength ? text : text[..(maxLength - 3)] + "...";
}
