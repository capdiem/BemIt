namespace BemIt.Tests;

using BemIt;

public class BlockTests
{
    [Fact]
    public void Test()
    {
        var outlined = true;
        var isDisabled = true;
        var density = Density.Dense;

        var cardModifierBuilder = new Block("card")
            .CreateModifierBuilder()
            .Add(outlined)
            .Add("disabled", isDisabled)
            .Add(density)
            .AddClass("theme--light");
        
        Assert.Equal("card card--outlined card--disabled card--density-dense theme--light", cardModifierBuilder.ToString());
    }

    enum Density
    {
        Dense,
        Comfortable,
        Compact,
    }

    [Fact]
    public void Constructor_WithValidName_InitializesNameProperty()
    {
        var block = new Block("validName");

        Assert.Equal("validname", block.Name);
    }

    [Fact]
    public void Constructor_WithNullName_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentNullException>(() => new Block(null));
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void Constructor_WithWhiteSpaceName_ThrowsArgumentException(string invalidName)
    {
        Assert.Throws<ArgumentException>(() => new Block(invalidName));
    }

    [Fact]
    public void Element_WithValidName_ReturnsElementWithCorrectName()
    {
        var block = new Block("block");
        var element = block.Element("element");

        Assert.Equal("block__element", element.Name);
    }

    [Fact]
    public void CreateModifierBuilder_ReturnsModifierBuilderWithCorrectName()
    {
        var block = new Block("block");
        var modifierBuilder = block.CreateModifierBuilder();

        Assert.Equal("block", modifierBuilder.ToString());
    }

    [Fact]
    public void CreateModifierBuilder_AddModifier_AppendsModifier()
    {
        var block = new Block("block");
        var modifierBuilder = block.CreateModifierBuilder().Add("modifier");

        Assert.Equal("block block--modifier", modifierBuilder.ToString());
    }

    [Fact]
    public void CreateModifierBuilder_AddClass_AppendsClasses()
    {
        var block = new Block("block");
        var modifierBuilder = block.CreateModifierBuilder().AddClass("class");

        Assert.Equal("block class", modifierBuilder.ToString());
    }

    [Fact]
    public void ToString_ReturnsNameInLowerCase()
    {
        var block = new Block("BLOCK");

        Assert.Equal("block", block.ToString());
    }
}