namespace BemIt.Tests;

using Xunit;
using BemIt;

public class ElementTests
{
    [Fact]
    public void Constructor_WithValidNames_InitializesNameProperty()
    {
        var element = new Element("validBlock", "validElement");

        Assert.Equal("validblock__validelement", element.Name);
    }

    [Theory]
    [InlineData(null, "validElement")]
    [InlineData("validBlock", null)]
    public void Constructor_WithNullNames_ThrowsArgumentException(string block, string element)
    {
        Assert.Throws<ArgumentNullException>(() => new Element(block, element));
    }

    [Theory]
    [InlineData("", "validElement")]
    [InlineData(" ", "validElement")]
    [InlineData("validBlock", "")]
    [InlineData("validBlock", " ")]
    public void Constructor_WithWhiteSpaceNames_ThrowsArgumentException(string block, string element)
    {
        Assert.Throws<ArgumentException>(() => new Element(block, element));
    }

    [Fact]
    public void CreateModifierBuilder_ReturnsModifierBuilderWithCorrectName()
    {
        var element = new Element("block", "element");
        var modifierBuilder = element.CreateModifierBuilder();

        Assert.Equal("block__element", modifierBuilder.ToString());
    }

    [Fact]
    public void ToString_ReturnsNameInLowerCase()
    {
        var element = new Element("BLOCK", "ELEMENT");

        Assert.Equal("block__element", element.ToString());
    }
}