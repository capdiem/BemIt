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
    public void Modifier_WithEnum_ReturnsCorrectModifier()
    {
        var block = new Block("block");
        var result = block.Modifier(Density.Default);

        Assert.Equal("block--density-default", result);
    }

    [Fact]
    public void Modifier_WithEnumAndExclude_ReturnsCorrectModifier()
    {
        var block = new Block("block");
        var result = block.Modifier(Density.Comfortable, Density.Default);

        Assert.Equal("block--density-comfortable", result);
    }

    [Fact]
    public void Modifier_WithEnumAndExclude_ReturnsEmptyString()
    {
        var block = new Block("block");
        var result = block.Modifier(Density.Default, Density.Default);

        Assert.Equal(string.Empty, result);
    }
}