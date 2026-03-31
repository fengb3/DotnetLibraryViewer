using System.IO;
using DotnetLibraryViewer.Models;

namespace DotnetLibraryViewer.Tests;

public class NestedTypeModelTests
{
    private static TypeInfo CreateNestedType(string name, string fullName, string? ns, string declaringType)
    {
        return new TypeInfo(
            Name: name,
            FullName: fullName,
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
            XmlDocSummary: null,
            DeclaringType: declaringType
        );
    }

    private static TypeInfo CreateTopLevelType(string name, string fullName, string ns)
    {
        return new TypeInfo(
            Name: name,
            FullName: fullName,
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
            XmlDocSummary: null
        );
    }

    [Fact]
    public void MarkdownGenerator_NestedType_ShowsNestingInfo()
    {
        var nestedType = CreateNestedType(
            "EventMessage",
            "Ns.OuterType+EventMessage",
            "Ns",
            "Ns.OuterType"
        );

        var assembly = new AssemblyInfo("TestLib", "1.0.0", null, [nestedType]);
        var result = MarkdownGenerator.Generate(assembly);

        Assert.Contains("EventMessage", result);
        Assert.Contains("**Nested in:**", result);
        Assert.Contains("Ns.OuterType", result);
    }

    [Fact]
    public void MarkdownGenerator_TopLevelType_NoNestingInfo()
    {
        var type = CreateTopLevelType("MyClass", "Ns.MyClass", "Ns");

        var assembly = new AssemblyInfo("TestLib", "1.0.0", null, [type]);
        var result = MarkdownGenerator.Generate(assembly);

        Assert.Contains("MyClass", result);
        Assert.DoesNotContain("**Nested in:**", result);
    }

    [Fact]
    public void TypeInfo_DeclaringType_DefaultIsNull()
    {
        var type = new TypeInfo(
            Name: "MyClass",
            FullName: "Ns.MyClass",
            Namespace: "Ns",
            Kind: TypeKind.Class,
            BaseType: null,
            IsStatic: false,
            IsAbstract: false,
            IsSealed: false,
            GenericParameterCount: 0,
            GenericParameterNames: [],
            Interfaces: [],
            Members: [],
            XmlDocSummary: null
        );

        Assert.Null(type.DeclaringType);
    }

    [Fact]
    public void TypeInfo_DeclaringType_SetForNestedType()
    {
        var type = CreateNestedType("Inner", "Ns.Outer+Inner", "Ns", "Ns.Outer");

        Assert.Equal("Ns.Outer", type.DeclaringType);
        Assert.Equal("Ns.Outer+Inner", type.FullName);
    }

    [Fact]
    public void TypeInfo_DeeplyNested_ThreeLevels()
    {
        // Simulates A+B+C
        var type = CreateNestedType("C", "Ns.A+B+C", "Ns", "Ns.A+B");

        Assert.Equal("Ns.A+B+C", type.FullName);
        Assert.Equal("Ns", type.Namespace);
        Assert.Equal("Ns.A+B", type.DeclaringType);
        Assert.Equal("C", type.Name);
    }

    [Fact]
    public void WildcardMatcher_DeeplyNestedDotForm()
    {
        // FullName.Replace('+', '.') gives "Ns.A.B.C"
        var fullName = "Ns.A+B+C";
        var dotForm = fullName.Replace('+', '.');

        Assert.Equal("Ns.A.B.C", dotForm);
        Assert.True(WildcardMatcher.IsMatch(dotForm, "*A.B.C"));
        Assert.True(WildcardMatcher.IsMatch(dotForm, "Ns.*"));
    }

    [Fact]
    public void WildcardMatcher_FindsNestedTypeByShortName()
    {
        var type = CreateNestedType("EventMessage", "Ns.OuterType+EventMessage", "Ns", "Ns.OuterType");

        Assert.True(WildcardMatcher.IsMatch(type.Name, "EventMessage"));
        Assert.True(WildcardMatcher.IsMatch(type.FullName.Replace('+', '.'), "*EventMessage"));
    }

    [Fact]
    public void CandidateSuggestion_FindsPartialMatch()
    {
        var types = new List<TypeInfo>
        {
            CreateTopLevelType("MyClass", "Ns.MyClass", "Ns"),
            CreateNestedType("EventMessage", "Ns.Outer+EventMessage", "Ns", "Ns.Outer"),
            CreateTopLevelType("OtherClass", "Ns.OtherClass", "Ns"),
        };

        var searchTerm = "EventMessage";
        var candidates = types
            .Where(t => t.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                     || t.FullName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            .Take(5)
            .ToList();

        Assert.Single(candidates);
        Assert.Equal("EventMessage", candidates[0].Name);
    }

    [Fact]
    public void CandidateSuggestion_LimitsTo5()
    {
        var types = Enumerable.Range(0, 10)
            .Select(i => CreateTopLevelType($"EventMessage{i}", $"Ns.EventMessage{i}", "Ns"))
            .ToList();

        var searchTerm = "EventMessage";
        var candidates = types
            .Where(t => t.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            .Take(5)
            .ToList();

        Assert.Equal(5, candidates.Count);
    }

    [Fact]
    public void CandidateSuggestion_NoMatch_ReturnsEmpty()
    {
        var types = new List<TypeInfo>
        {
            CreateTopLevelType("MyClass", "Ns.MyClass", "Ns"),
        };

        var searchTerm = "CompletelyDifferent";
        var candidates = types
            .Where(t => t.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            .Take(5)
            .ToList();

        Assert.Empty(candidates);
    }
}
