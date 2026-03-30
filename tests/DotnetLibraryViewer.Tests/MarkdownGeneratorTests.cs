using DotnetLibraryViewer.Models;

namespace DotnetLibraryViewer.Tests;

public class MarkdownGeneratorTests
{
    [Fact]
    public void Generate_EmptyAssembly_ProducesHeader()
    {
        var assembly = new AssemblyInfo("TestLib", "1.0.0", null, []);

        var result = MarkdownGenerator.Generate(assembly);

        Assert.Contains("# TestLib", result);
        Assert.Contains("**Version:** 1.0.0", result);
    }

    [Fact]
    public void Generate_ClassWithMethods_ProducesTable()
    {
        var member = new MemberInfo(
            Name: "DoSomething",
            DocId: "M:TestLib.MyClass.DoSomething",
            Kind: MemberKind.Method,
            Signature: "void DoSomething()",
            TypeName: "void",
            Accessibility: Accessibility.Public,
            IsStatic: false,
            IsVirtual: false,
            IsAbstract: false,
            Parameters: [],
            ReturnType: "void",
            XmlDocSummary: "Does something."
        );

        var type = new TypeInfo(
            Name: "MyClass",
            FullName: "TestLib.MyClass",
            Namespace: "TestLib",
            Kind: TypeKind.Class,
            BaseType: null,
            IsStatic: false,
            IsAbstract: false,
            IsSealed: false,
            GenericParameterCount: 0,
            GenericParameterNames: [],
            Interfaces: [],
            Members: [member],
            XmlDocSummary: "A test class."
        );

        var assembly = new AssemblyInfo("TestLib", "1.0.0", null, [type]);

        var result = MarkdownGenerator.Generate(assembly);

        Assert.Contains("### `class MyClass`", result);
        Assert.Contains("A test class.", result);
        Assert.Contains("DoSomething", result);
        Assert.Contains("Does something.", result);
        Assert.Contains("#### Methods", result);
    }

    [Fact]
    public void Generate_GenericClass_ShowsGenericParams()
    {
        var type = new TypeInfo(
            Name: "MyList`1",
            FullName: "TestLib.MyList`1",
            Namespace: "TestLib",
            Kind: TypeKind.Class,
            BaseType: null,
            IsStatic: false,
            IsAbstract: false,
            IsSealed: false,
            GenericParameterCount: 1,
            GenericParameterNames: ["T"],
            Interfaces: [],
            Members: [],
            XmlDocSummary: null
        );

        var assembly = new AssemblyInfo("TestLib", "1.0.0", null, [type]);

        var result = MarkdownGenerator.Generate(assembly);

        Assert.Contains("MyList`1<T>", result);
    }

    [Fact]
    public void Generate_ClassWithProperties_ProducesPropertyTable()
    {
        var prop = new MemberInfo(
            Name: "Count",
            DocId: "P:TestLib.MyClass.Count",
            Kind: MemberKind.Property,
            Signature: "int Count { get; set; }",
            TypeName: "int",
            Accessibility: Accessibility.Public,
            IsStatic: false,
            IsVirtual: false,
            IsAbstract: false,
            Parameters: [],
            ReturnType: "int",
            XmlDocSummary: "Gets the count."
        );

        var type = new TypeInfo(
            Name: "MyClass",
            FullName: "TestLib.MyClass",
            Namespace: "TestLib",
            Kind: TypeKind.Class,
            BaseType: "System.Object",
            IsStatic: false,
            IsAbstract: false,
            IsSealed: false,
            GenericParameterCount: 0,
            GenericParameterNames: [],
            Interfaces: [],
            Members: [prop],
            XmlDocSummary: null
        );

        var assembly = new AssemblyInfo("TestLib", "1.0.0", null, [type]);

        var result = MarkdownGenerator.Generate(assembly);

        Assert.Contains("#### Properties", result);
        Assert.Contains("`Count`", result);
        Assert.Contains("`int`", result);
        Assert.Contains("Gets the count.", result);
    }

    [Fact]
    public void Generate_StaticClass_ShowsStaticModifier()
    {
        var type = new TypeInfo(
            Name: "Helper",
            FullName: "TestLib.Helper",
            Namespace: "TestLib",
            Kind: TypeKind.Class,
            BaseType: "System.Object",
            IsStatic: true,
            IsAbstract: false,
            IsSealed: false,
            GenericParameterCount: 0,
            GenericParameterNames: [],
            Interfaces: [],
            Members: [],
            XmlDocSummary: null
        );

        var assembly = new AssemblyInfo("TestLib", "1.0.0", null, [type]);

        var result = MarkdownGenerator.Generate(assembly);

        Assert.Contains("`static class Helper`", result);
    }
}
