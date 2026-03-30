using System.Xml.Linq;

namespace DotnetLibraryViewer;

public sealed record MemberDoc(
    string Summary,
    IReadOnlyDictionary<string, string> Parameters,
    IReadOnlyDictionary<string, string> TypeParameters,
    string? Returns
);

public sealed class XmlDocReader
{
    private readonly Dictionary<string, MemberDoc> _docs;

    private XmlDocReader(Dictionary<string, MemberDoc> docs) => _docs = docs;

    public static XmlDocReader? Load(string? xmlPath)
    {
        if (xmlPath is null || !File.Exists(xmlPath))
            return null;

        try
        {
            var doc = XDocument.Load(xmlPath);
            var members = doc.Root?.Element("members")?.Elements("member");
            if (members is null)
                return null;

            var dict = new Dictionary<string, MemberDoc>(StringComparer.Ordinal);
            foreach (var member in members)
            {
                var name = member.Attribute("name")?.Value;
                if (name is null) continue;

                var summary = CleanText(member.Element("summary")?.Value);
                var returns = CleanText(member.Element("returns")?.Value);

                var parameters = new Dictionary<string, string>();
                foreach (var param in member.Elements("param"))
                {
                    var paramName = param.Attribute("name")?.Value;
                    if (paramName is not null)
                        parameters[paramName] = CleanText(param.Value) ?? "";
                }

                var typeParameters = new Dictionary<string, string>();
                foreach (var typeParam in member.Elements("typeparam"))
                {
                    var paramName = typeParam.Attribute("name")?.Value;
                    if (paramName is not null)
                        typeParameters[paramName] = CleanText(typeParam.Value) ?? "";
                }

                dict[name] = new MemberDoc(
                    summary ?? "",
                    parameters,
                    typeParameters,
                    returns
                );
            }

            return new XmlDocReader(dict);
        }
        catch
        {
            return null;
        }
    }

    public MemberDoc? GetDoc(string docId) =>
        _docs.TryGetValue(docId, out var doc) ? doc : null;

    private static string? CleanText(string? text)
    {
        if (text is null) return null;
        // Normalize whitespace
        var result = new System.Text.StringBuilder(text.Length);
        bool lastWasSpace = true; // trim leading spaces
        foreach (var c in text)
        {
            if (c is '\r' or '\n' or '\t')
            {
                if (!lastWasSpace)
                {
                    result.Append(' ');
                    lastWasSpace = true;
                }
            }
            else if (c == ' ')
            {
                if (!lastWasSpace)
                {
                    result.Append(' ');
                    lastWasSpace = true;
                }
            }
            else
            {
                result.Append(c);
                lastWasSpace = false;
            }
        }
        // Trim trailing
        return result.ToString().Trim();
    }
}
