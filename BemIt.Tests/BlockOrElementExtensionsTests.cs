namespace BemIt.Tests;

using Xunit;
using BemIt;

public class BlockOrElementExtensionsTests
{
    [Fact]
    public void Modifier_WithTrueCondition_ReturnsCorrectModifier()
    {
        var block = new Block("block");
        var result = block.Modifier(true, "modifier");

        Assert.Equal("block--modifier", result);
    }

    [Fact]
    public void Modifier_WithFalseCondition_ReturnsEmptyString()
    {
        var block = new Block("block");
        var result = block.Modifier(false, "modifier");

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void Modifier_WithConditionAndModifier_ReturnsCorrectModifier()
    {
        var block = new Block("block");
        var result = block.Modifier("modifier", true);

        Assert.Equal("block--modifier", result);
    }

    [Fact]
    public void Modifier_WithConditionAndModifier_ReturnsEmptyString()
    {
        var block = new Block("block");
        var result = block.Modifier("modifier", false);

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void Modifier_WithEnumAndSpecificName_ReturnsCorrectModifier()
    {
        var block = new Block("block");
        var result = block.Modifier(Density.Default, "density");

        Assert.Equal("block--density-default", result);
    }

    [Fact]
    public void Modifier_WithEnumAndExcludeAndSpecificName_ReturnsCorrectModifier()
    {
        var block = new Block("block");
        var result = block.Modifier(Density.Comfortable, Density.Default, "density");

        Assert.Equal("block--density-comfortable", result);
    }

    [Fact]
    public void Modifier_WithEnumVariable_ReturnsCorrectModifier()
    {
        var block = new Block("block");
        var density = Density.Default;
        var result = block.Modifier(density);

        Assert.Equal("block--density-default", result);
    }

    [Fact]
    public void Modifier_WithEnumVariableAndSameExclude_ReturnsEmptyString()
    {
        var block = new Block("block");
        var density = Density.Default;
        var result = block.Modifier(density, Density.Default);

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void Modifier_WithEnumAndExclude_ReturnsEmptyString()
    {
        var block = new Block("block");
        var density = Density.Default;
        var exclude = Density.Default;
        var result = block.Modifier(density, exclude);

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void Modifier_WithEnumAndEmptySpecificName_ReturnsCorrectModifier()
    {
        var block = new Block("block");
        var result = block.Modifier(Density.Default, "");

        Assert.Equal("block--default", result);
    }
}