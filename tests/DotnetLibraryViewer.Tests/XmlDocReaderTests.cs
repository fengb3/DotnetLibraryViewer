using System.Xml.Linq;

namespace DotnetLibraryViewer.Tests;

public class XmlDocReaderTests
{
    [Fact]
    public void Load_ValidXml_ReturnsReader()
    {
        var xml = @"<?xml version=""1.0""?>
<doc>
  <assembly><name>TestLib</name></assembly>
  <members>
    <member name=""T:TestLib.MyClass"">
      <summary>A test class.</summary>
    </member>
    <member name=""M:TestLib.MyClass.DoSomething"">
      <summary>Does something.</summary>
      <param name=""x"">The x value.</param>
      <returns>True if successful.</returns>
    </member>
  </members>
</doc>";

        var tempFile = Path.GetTempFileName();
        try
        {
            File.WriteAllText(tempFile, xml);

            var reader = XmlDocReader.Load(tempFile);

            Assert.NotNull(reader);
            var typeDoc = reader.GetDoc("T:TestLib.MyClass");
            Assert.NotNull(typeDoc);
            Assert.Equal("A test class.", typeDoc.Summary);

            var methodDoc = reader.GetDoc("M:TestLib.MyClass.DoSomething");
            Assert.NotNull(methodDoc);
            Assert.Equal("Does something.", methodDoc.Summary);
            Assert.Equal("The x value.", methodDoc.Parameters["x"]);
            Assert.Equal("True if successful.", methodDoc.Returns);
        }
        finally
        {
            File.Delete(tempFile);
        }
    }

    [Fact]
    public void Load_NullPath_ReturnsNull()
    {
        var result = XmlDocReader.Load(null);
        Assert.Null(result);
    }

    [Fact]
    public void Load_NonExistentPath_ReturnsNull()
    {
        var result = XmlDocReader.Load("/nonexistent/path.xml");
        Assert.Null(result);
    }

    [Fact]
    public void GetDoc_UnknownMember_ReturnsNull()
    {
        var xml = @"<?xml version=""1.0""?>
<doc>
  <members>
    <member name=""T:TestLib.MyClass"">
      <summary>Test.</summary>
    </member>
  </members>
</doc>";

        var tempFile = Path.GetTempFileName();
        try
        {
            File.WriteAllText(tempFile, xml);
            var reader = XmlDocReader.Load(tempFile);
            Assert.NotNull(reader);

            var doc = reader.GetDoc("T:NonExistent");
            Assert.Null(doc);
        }
        finally
        {
            File.Delete(tempFile);
        }
    }
}
