namespace BemIt.Tests;

using Xunit;
using BemIt;

public class ModifierTests
{
    [Fact]
    public void Constructor_WithValidNames_InitializesNameProperty()
    {
        var modifier = new Modifier("validBlockOrElement", "validModifier");

        Assert.Equal("validblockorelement--validmodifier", modifier.Name);
    }

    [Theory]
    [InlineData(null, "validModifier")]
    [InlineData("validBlockOrElement", null)]
    public void Constructor_WithNullNames_ThrowsArgumentException(string blockOrElement, string modifier)
    {
        Assert.Throws<ArgumentNullException>(() => new Modifier(blockOrElement, modifier));
    }

    [Theory]
    [InlineData("", "validModifier")]
    [InlineData(" ", "validModifier")]
    [InlineData("validBlockOrElement", "")]
    [InlineData("validBlockOrElement", " ")]
    public void Constructor_WithWhiteSpaceNames_ThrowsArgumentException(string blockOrElement, string modifier)
    {
        Assert.Throws<ArgumentException>(() => new Modifier(blockOrElement, modifier));
    }

    [Fact]
    public void ToString_ReturnsNameInLowerCase()
    {
        var modifier = new Modifier("BLOCKORELEMENT", "MODIFIER");

        Assert.Equal("blockorelement--modifier", modifier.ToString());
    }
}