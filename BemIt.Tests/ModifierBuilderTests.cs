namespace BemIt.Tests;

using Xunit;
using BemIt;

public class ModifierBuilderTests
{
    [Fact]
    public void NoModifiers_ReturnsBlock()
    {
        // Arrange
        var builder = new ModifierBuilder("block");

        // Act
        var result = builder.ToString();

        // Assert
        Assert.Equal("block", result);
    }

    [Fact]
    public void AddModifier_WithTrueCondition_AppendsModifier()
    {
        // Arrange
        var builder = new ModifierBuilder("block");

        // Act
        builder.Add("modifier", true);

        // Assert
        Assert.Equal("block block--modifier", builder.ToString());
    }

    [Fact]
    public void AddModifier_WithFalseCondition_DoesNotAppendModifier()
    {
        // Arrange
        var builder = new ModifierBuilder("block");

        // Act
        builder.Add("modifier", false);

        // Assert
        Assert.Equal("block", builder.ToString());
    }

    [Fact]
    public void AddEnumModifier_ExcludingSameValue_DoesNotAppendModifier()
    {
        // Arrange
        var builder = new ModifierBuilder("block");

        var density = Density.Default;
        // Act
        builder.Add(density, Density.Default);

        // Assert
        Assert.Equal("block", builder.ToString());
    }

    [Fact]
    public void AddEnumModifier_ExcludingDifferentValue_AppendsModifier()
    {
        // Arrange
        var builder = new ModifierBuilder("block");

        var density = Density.Default;
        // Act
        builder.Add(density, Density.Comfortable);

        // Assert
        Assert.Equal("block block--density-default", builder.ToString());
    }


    [Fact]
    public void AddEnumModifier_NotExcludingSpecificValue_AppendsValue()
    {
        // Arrange
        var builder = new ModifierBuilder("block");
        var density = Density.Default;

        // Act
        builder.Add(density);

        // Assert
        Assert.Equal("block block--density-default", builder.ToString());
    }

    [Fact]
    public void AddEnumModifier_WithSpecificName_AppendsModifier()
    {
        // Arrange
        var builder = new ModifierBuilder("block");

        var density = Density.Default;
        // Act
        builder.Add(density, "size");

        // Assert
        Assert.Equal("block block--size-default", builder.ToString());
    }

    [Fact]
    public void AddBooleanModifier_WithTrueCondition_AppendsModifier()
    {
        // Arrange
        var builder = new ModifierBuilder("block");

        var active = true;
        // Act
        builder.Add(active);

        // Assert
        Assert.Equal("block block--active", builder.ToString());
    }

    [Fact]
    public void AddBooleanModifier_WithTrueConditionAndSpecificName_AppendsModifier()
    {
        // Arrange
        var builder = new ModifierBuilder("block");

        var active = true;
        // Act
        builder.Add(active, "is-active");

        // Assert
        Assert.Equal("block block--is-active", builder.ToString());
    }

    [Fact]
    public void AddBooleanModifier_WithFalseCondition_DoesNotAppendModifier()
    {
        // Arrange
        var builder = new ModifierBuilder("block");

        var active = false;
        // Act
        builder.Add(active);

        // Assert
        Assert.Equal("block", builder.ToString());
    }

    [Fact]
    public void AddBooleanModifier_WithFalseConditionAndSpecificName_DoesNotAppendModifier()
    {
        // Arrange
        var builder = new ModifierBuilder("block");

        var active = false;
        // Act
        builder.Add(active, "is-active");

        // Assert
        Assert.Equal("block", builder.ToString());
    }

    [Fact]
    public void AddClass_AppendsClass()
    {
        // Arrange
        var builder = new ModifierBuilder("block");

        // Act
        builder.AddClass("class1", "class2");

        // Assert
        Assert.Equal("block class1 class2", builder.ToString());
    }

    [Fact]
    public void Build_ReturnsBuiltString()
    {
        // Arrange
        var builder = new ModifierBuilder("block");
        builder.Add("modifier", true);

        // Act
        var result = builder.Build();

        // Assert
        Assert.Equal("block block--modifier", result);
    }

    [Fact]
    public void AddModifiers_WithMultipleModifiers_AppendsAllModifiers()
    {
        // Arrange
        var builder = new ModifierBuilder("block");
        var active = true;
        var density = Density.Compact;

        // Act
        builder.Add("rounded", true)
            .Add(active)
            .Add(density);

        // Assert
        Assert.Equal("block block--rounded block--active block--density-compact", builder.ToString());
    }

    [Fact]
    public void AddModifiersAndClasses_AppendsAllModifiersAndClasses()
    {
        // Arrange
        var builder = new ModifierBuilder("block");
        var active = true;
        var density = Density.Compact;

        // Act
        builder.Add("rounded", true)
            .Add(active)
            .Add(density)
            .AddClass("class1", "class2");

        // Assert
        Assert.Equal("block block--rounded block--active block--density-compact class1 class2", builder.ToString());
    }
}