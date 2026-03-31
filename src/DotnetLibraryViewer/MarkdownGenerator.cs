using System.Text;
using DotnetLibraryViewer.Models;

namespace DotnetLibraryViewer;

public static class MarkdownGenerator
{
    public static string Generate(AssemblyInfo assembly)
    {
        var sb = new StringBuilder();

        sb.AppendLine($"# {assembly.Name}");
        if (assembly.Version is not null)
            sb.AppendLine($"**Version:** {assembly.Version}");
        sb.AppendLine();

        var groupedByNamespace = assembly.Types
            .GroupBy(t => t.Namespace ?? "(Global)")
            .OrderBy(g => g.Key);

        foreach (var nsGroup in groupedByNamespace)
        {
            sb.AppendLine($"## {nsGroup.Key}");
            sb.AppendLine();

            foreach (var type in nsGroup.OrderBy(t => t.Name))
            {
                WriteType(sb, type);
            }
        }

        return sb.ToString();
    }

    private static void WriteType(StringBuilder sb, TypeInfo type)
    {
        var kind = type.Kind.ToString().ToLowerInvariant();
        var modifiers = new List<string>();
        if (type.IsStatic) modifiers.Add("static");
        if (type.IsAbstract && !type.IsStatic) modifiers.Add("abstract");
        if (type.IsSealed && !type.IsStatic) modifiers.Add("sealed");

        var genericSuffix = type.GenericParameterCount > 0
            ? $"<{string.Join(", ", type.GenericParameterNames)}>"
            : "";

        var inheritance = new List<string>();
        if (type.BaseType is not null && type.BaseType is not "System.Object" and not "System.ValueType" and not "System.Enum")
            inheritance.Add(type.BaseType);
        foreach (var iface in type.Interfaces)
            inheritance.Add(iface);

        var modifierStr = modifiers.Count > 0 ? string.Join(" ", modifiers) + " " : "";
        var inheritStr = inheritance.Count > 0 ? $" : {string.Join(", ", inheritance)}" : "";

        sb.AppendLine($"### `{modifierStr}{kind} {type.Name}{genericSuffix}{inheritStr}`");
        sb.AppendLine();

        if (type.DeclaringType is not null)
        {
            sb.AppendLine($"**Nested in:** `{type.DeclaringType}`");
            sb.AppendLine();
        }

        if (!string.IsNullOrWhiteSpace(type.XmlDocSummary))
        {
            sb.AppendLine(type.XmlDocSummary);
            sb.AppendLine();
        }

        WriteProperties(sb, type);
        WriteMethods(sb, type);
        WriteFields(sb, type);
        WriteEvents(sb, type);

        sb.AppendLine("---");
        sb.AppendLine();
    }

    private static void WriteProperties(StringBuilder sb, TypeInfo type)
    {
        var properties = type.Members.Where(m => m.Kind == MemberKind.Property).ToList();
        if (properties.Count == 0) return;

        sb.AppendLine("#### Properties");
        sb.AppendLine();
        sb.AppendLine("| Name | Type | Description |");
        sb.AppendLine("|------|------|-------------|");
        foreach (var prop in properties)
        {
            var desc = EscapeMarkdown(prop.XmlDocSummary);
            sb.AppendLine($"| `{prop.Name}` | `{prop.TypeName}` | {desc} |");
        }
        sb.AppendLine();
    }

    private static void WriteMethods(StringBuilder sb, TypeInfo type)
    {
        var methods = type.Members
            .Where(m => m.Kind == MemberKind.Method || m.Kind == MemberKind.Constructor)
            .ToList();
        if (methods.Count == 0) return;

        sb.AppendLine("#### Methods");
        sb.AppendLine();
        sb.AppendLine("| Signature | Description |");
        sb.AppendLine("|-----------|-------------|");
        foreach (var method in methods)
        {
            var desc = EscapeMarkdown(method.XmlDocSummary);
            sb.AppendLine($"| `{method.Signature}` | {desc} |");
        }
        sb.AppendLine();
    }

    private static void WriteFields(StringBuilder sb, TypeInfo type)
    {
        var fields = type.Members.Where(m => m.Kind == MemberKind.Field).ToList();
        if (fields.Count == 0) return;

        sb.AppendLine("#### Fields");
        sb.AppendLine();
        sb.AppendLine("| Name | Type | Description |");
        sb.AppendLine("|------|------|-------------|");
        foreach (var field in fields)
        {
            var desc = EscapeMarkdown(field.XmlDocSummary);
            sb.AppendLine($"| `{field.Name}` | `{field.TypeName}` | {desc} |");
        }
        sb.AppendLine();
    }

    private static void WriteEvents(StringBuilder sb, TypeInfo type)
    {
        var events = type.Members.Where(m => m.Kind == MemberKind.Event).ToList();
        if (events.Count == 0) return;

        sb.AppendLine("#### Events");
        sb.AppendLine();
        sb.AppendLine("| Name | Type | Description |");
        sb.AppendLine("|------|------|-------------|");
        foreach (var evt in events)
        {
            var desc = EscapeMarkdown(evt.XmlDocSummary);
            sb.AppendLine($"| `{evt.Name}` | `{evt.TypeName}` | {desc} |");
        }
        sb.AppendLine();
    }

    private static string EscapeMarkdown(string? text)
    {
        if (string.IsNullOrWhiteSpace(text)) return "";
        return text.Replace("|", "\\|").Replace("\n", " ").Trim();
    }
}
