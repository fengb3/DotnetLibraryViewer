using DotnetLibraryViewer.Models;

namespace DotnetLibraryViewer.Tests;

public class OutputFormatterTests
{
    private static TypeInfo MakeType(string name, string ns, string? summary = null) => new(
        Name: name,
        FullName: $"{ns}.{name}",
        Namespace: ns,
        Kind: TypeKind.Class,
        BaseType: null,
        IsStatic: false,
        IsAbstract: false,
        IsSealed: false,
        GenericParameterCount: 0,
        GenericParameterNames: [],
        Interfaces: [],
        Members: [],
        XmlDocSummary: summary
    );

    private static MemberInfo MakeMethod(string name, string fullName, string? summary = null) => new(
        Name: name,
        DocId: $"M:{fullName}.{name}",
        Kind: MemberKind.Method,
        Signature: $"void {name}()",
        TypeName: "void",
        Accessibility: Accessibility.Public,
        IsStatic: false,
        IsVirtual: false,
        IsAbstract: false,
        Parameters: [],
        ReturnType: "void",
        XmlDocSummary: summary
    );

    private static string CaptureOutput(Action action)
    {
        var sw = new StringWriter();
        var originalOut = Console.Out;
        try
        {
            Console.SetOut(sw);
            action();
            return sw.ToString();
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }

    [Fact]
    public void ListTypes_SummaryTruncated_EndsWithBrackets()
    {
        var longSummary = new string('a', 120);
        var type = MakeType("MyClass", "Ns", longSummary);

        var output = CaptureOutput(() => OutputFormatter.ListTypes([type]));

        Assert.Contains("[...]", output);
        Assert.DoesNotContain(new string('a', 120), output);
    }

    [Fact]
    public void ListTypes_SummaryNotTruncated_NoBrackets()
    {
        var shortSummary = "A short description.";
        var type = MakeType("MyClass", "Ns", shortSummary);

        var output = CaptureOutput(() => OutputFormatter.ListTypes([type]));

        Assert.Contains(shortSummary, output);
        Assert.DoesNotContain("[...]", output);
    }

    [Fact]
    public void ListMembers_SummaryTruncated_EndsWithBrackets()
    {
        var longSummary = new string('b', 120);
        var type = MakeType("MyClass", "Ns");
        var member = MakeMethod("DoWork", "Ns.MyClass", longSummary);

        var output = CaptureOutput(() => OutputFormatter.ListMembers([(type, member)]));

        Assert.Contains("[...]", output);
    }

    [Fact]
    public void WriteComparisonResult_ShowsNuGetVersion()
    {
        var result = new VersionComparisonResult(
            "MyLib", "13.0.1", "13.0.3", [], [], [], []);

        var output = CaptureOutput(() => OutputFormatter.WriteComparisonResult(result));

        Assert.Contains("v13.0.1", output);
        Assert.Contains("v13.0.3", output);
    }

    [Fact]
    public void WriteComparisonResult_NoDiffs_ShowsNoDifferences()
    {
        var result = new VersionComparisonResult(
            "MyLib", "1.0.0", "2.0.0", [], [], [], []);

        var output = CaptureOutput(() => OutputFormatter.WriteComparisonResult(result));

        Assert.Contains("No API differences found.", output);
    }
}
