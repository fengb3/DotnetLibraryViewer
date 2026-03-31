namespace DotnetLibraryViewer.Tests;

public class WildcardMatcherTests
{
    [Fact]
    public void IsMatch_StarMatchesAll()
    {
        Assert.True(WildcardMatcher.IsMatch("Anything", "*"));
        Assert.True(WildcardMatcher.IsMatch("", "*"));
    }

    [Fact]
    public void IsMatch_QuestionMarkMatchesSingleChar()
    {
        Assert.True(WildcardMatcher.IsMatch("abc", "a?c"));
        Assert.False(WildcardMatcher.IsMatch("abbc", "a?c"));
        Assert.False(WildcardMatcher.IsMatch("ac", "a?c"));
    }

    [Fact]
    public void IsMatch_CaseInsensitive()
    {
        Assert.True(WildcardMatcher.IsMatch("MyClass", "myclass"));
        Assert.True(WildcardMatcher.IsMatch("MyClass", "MY*"));
        Assert.True(WildcardMatcher.IsMatch("serializer", "*Serializer*"));
    }

    [Fact]
    public void IsMatch_PrefixAndSuffixStar()
    {
        Assert.True(WildcardMatcher.IsMatch("JsonSerializer", "*Serializer*"));
        Assert.True(WildcardMatcher.IsMatch("MySerializerHelper", "*Serializer*"));
        Assert.False(WildcardMatcher.IsMatch("MyHelper", "*Serializer*"));
    }

    [Fact]
    public void IsMatch_PlusSeparatedName()
    {
        Assert.True(WildcardMatcher.IsMatch("Outer+EventMessage", "*EventMessage*"));
        Assert.True(WildcardMatcher.IsMatch("Ns.OuterType+EventMessage", "*EventMessage"));
    }

    [Fact]
    public void IsMatch_DotSeparatedName()
    {
        Assert.True(WildcardMatcher.IsMatch("Ns.OuterType.EventMessage", "*EventMessage"));
        Assert.True(WildcardMatcher.IsMatch("FeishuNetSdk.Im.Events", "FeishuNetSdk.Im*"));
    }

    [Fact]
    public void IsMatch_SubstringMatch()
    {
        // Without wildcards, pattern matches as substring
        Assert.True(WildcardMatcher.IsMatch("MyClass", "MyClass"));
        Assert.True(WildcardMatcher.IsMatch("MyClass2", "MyClass"));
        Assert.False(WildcardMatcher.IsMatch("OtherClass", "MyClass"));
    }

    [Fact]
    public void IsMatch_NamespacePattern()
    {
        Assert.True(WildcardMatcher.IsMatch("FeishuNetSdk.Im.Events", "FeishuNetSdk.Im*"));
        Assert.False(WildcardMatcher.IsMatch("FeishuNetSdk.Mail.Events", "FeishuNetSdk.Im*"));
    }
}
