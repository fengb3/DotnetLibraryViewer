using DotnetLibraryViewer.Models;

namespace DotnetLibraryViewer.Tests;

public class ApiComparerTests
{
    private static TypeInfo MakeType(string name, string ns, params MemberInfo[] members) => new(
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
        Members: members,
        XmlDocSummary: null
    );

    private static MemberInfo MakeMethod(string name, string fullName, bool isObsolete = false) => new(
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
        XmlDocSummary: null,
        IsObsolete: isObsolete
    );

    private static AssemblyInfo MakeAssembly(string name, string version, params TypeInfo[] types) => new(
        Name: name,
        Version: version,
        XmlDocSummary: null,
        Types: types
    );

    [Fact]
    public void Compare_IdenticalAssemblies_NoDiffs()
    {
        var type = MakeType("MyClass", "Ns", MakeMethod("DoWork", "Ns.MyClass"));
        var v1 = MakeAssembly("Lib", "1.0.0", type);
        var v2 = MakeAssembly("Lib", "1.0.0", type);

        var result = ApiComparer.Compare(v1, v2);

        Assert.Empty(result.AddedTypes);
        Assert.Empty(result.RemovedTypes);
        Assert.Empty(result.ChangedTypes);
    }

    [Fact]
    public void Compare_AddedType_InResult()
    {
        var v1 = MakeAssembly("Lib", "1.0.0");
        var newType = MakeType("NewClass", "Ns");
        var v2 = MakeAssembly("Lib", "2.0.0", newType);

        var result = ApiComparer.Compare(v1, v2);

        Assert.Single(result.AddedTypes);
        Assert.Equal("Ns.NewClass", result.AddedTypes[0].FullName);
        Assert.Empty(result.RemovedTypes);
    }

    [Fact]
    public void Compare_RemovedType_InResult()
    {
        var oldType = MakeType("OldClass", "Ns");
        var v1 = MakeAssembly("Lib", "1.0.0", oldType);
        var v2 = MakeAssembly("Lib", "2.0.0");

        var result = ApiComparer.Compare(v1, v2);

        Assert.Single(result.RemovedTypes);
        Assert.Equal("Ns.OldClass", result.RemovedTypes[0].FullName);
        Assert.Empty(result.AddedTypes);
    }

    [Fact]
    public void Compare_AddedMember_InResult()
    {
        var v1Type = MakeType("MyClass", "Ns");
        var v2Type = MakeType("MyClass", "Ns", MakeMethod("NewMethod", "Ns.MyClass"));
        var v1 = MakeAssembly("Lib", "1.0.0", v1Type);
        var v2 = MakeAssembly("Lib", "2.0.0", v2Type);

        var result = ApiComparer.Compare(v1, v2);

        Assert.Empty(result.AddedTypes);
        Assert.Empty(result.RemovedTypes);
        Assert.Single(result.ChangedTypes);
        Assert.Single(result.ChangedTypes[0].AddedMembers);
        Assert.Equal("NewMethod", result.ChangedTypes[0].AddedMembers[0].Name);
    }

    [Fact]
    public void Compare_RemovedMember_InResult()
    {
        var v1Type = MakeType("MyClass", "Ns", MakeMethod("OldMethod", "Ns.MyClass"));
        var v2Type = MakeType("MyClass", "Ns");
        var v1 = MakeAssembly("Lib", "1.0.0", v1Type);
        var v2 = MakeAssembly("Lib", "2.0.0", v2Type);

        var result = ApiComparer.Compare(v1, v2);

        Assert.Single(result.ChangedTypes);
        Assert.Single(result.ChangedTypes[0].RemovedMembers);
        Assert.Equal("OldMethod", result.ChangedTypes[0].RemovedMembers[0].Name);
    }

    [Fact]
    public void Compare_NewlyObsoleteMember_InResult()
    {
        var v1Type = MakeType("MyClass", "Ns", MakeMethod("Deprecated", "Ns.MyClass", isObsolete: false));
        var v2Type = MakeType("MyClass", "Ns", MakeMethod("Deprecated", "Ns.MyClass", isObsolete: true));
        var v1 = MakeAssembly("Lib", "1.0.0", v1Type);
        var v2 = MakeAssembly("Lib", "2.0.0", v2Type);

        var result = ApiComparer.Compare(v1, v2);

        Assert.Single(result.ChangedTypes);
        Assert.Empty(result.ChangedTypes[0].AddedMembers);
        Assert.Empty(result.ChangedTypes[0].RemovedMembers);
        Assert.Single(result.ChangedTypes[0].NewlyObsoleteMembers);
        Assert.Equal("Deprecated", result.ChangedTypes[0].NewlyObsoleteMembers[0].Name);
    }

    [Fact]
    public void Compare_AlreadyObsoleteInBoth_NotInResult()
    {
        var v1Type = MakeType("MyClass", "Ns", MakeMethod("Old", "Ns.MyClass", isObsolete: true));
        var v2Type = MakeType("MyClass", "Ns", MakeMethod("Old", "Ns.MyClass", isObsolete: true));
        var v1 = MakeAssembly("Lib", "1.0.0", v1Type);
        var v2 = MakeAssembly("Lib", "2.0.0", v2Type);

        var result = ApiComparer.Compare(v1, v2);

        Assert.Empty(result.ChangedTypes);
    }

    [Fact]
    public void Compare_UnchangedTypeNotInChangedTypes()
    {
        var member = MakeMethod("Same", "Ns.MyClass");
        var v1Type = MakeType("MyClass", "Ns", member);
        var v2Type = MakeType("MyClass", "Ns", member);
        var v1 = MakeAssembly("Lib", "1.0.0", v1Type);
        var v2 = MakeAssembly("Lib", "2.0.0", v2Type);

        var result = ApiComparer.Compare(v1, v2);

        Assert.Empty(result.ChangedTypes);
    }

    [Fact]
    public void FilterByNamespace_FiltersResults()
    {
        var typeA = MakeType("A", "Ns1");
        var typeB = MakeType("B", "Ns2");
        var v1 = MakeAssembly("Lib", "1.0.0");
        var v2 = MakeAssembly("Lib", "2.0.0", typeA, typeB);

        var result = ApiComparer.Compare(v1, v2);
        var filtered = ApiComparer.FilterByNamespace(result, "Ns1");

        Assert.Single(filtered.AddedTypes);
        Assert.Equal("Ns1.A", filtered.AddedTypes[0].FullName);
    }

    [Fact]
    public void Compare_ResultContainsVersionInfo()
    {
        var v1 = MakeAssembly("MyLib", "1.0.0");
        var v2 = MakeAssembly("MyLib", "2.0.0");

        var result = ApiComparer.Compare(v1, v2);

        Assert.Equal("MyLib", result.PackageName);
        Assert.Equal("1.0.0", result.Version1);
        Assert.Equal("2.0.0", result.Version2);
    }
}
