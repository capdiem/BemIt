namespace BemIt.Tests;

public class BlockTests
{
    private readonly Block _block = new("m-list-item");

    [Fact]
    public void Block()
    {
        Assert.Equal("m-list-item", _block.Build());
    }

    [Fact]
    public void Extend()
    {
        Assert.Equal("m-list-item-title", _block.Extend("title").Build());
    }

    [Fact]
    public void Extend_element()
    {
        Assert.Equal("m-list-item-title__intro", _block.Extend("title").Element("intro").Build());
    }

    [Fact]
    public void Extend_element_modifier()
    {
        Assert.Equal("m-list-item-title__intro m-list-item-title__intro--hoverable",
            _block.Extend("title").Element("intro").Modifier("hoverable").Build());
    }

    [Fact]
    public void Block_modifier()
    {
        Assert.Equal("m-list-item m-list-item--link", _block.Modifier("link").Build());
    }

    [Fact]
    public void Block_modifier_with_true_condition()
    {
        Assert.Equal("m-list-item m-list-item--link", _block.Modifier("link", true).Build());
    }

    [Fact]
    public void Block_modifier_with_false_condition()
    {
        Assert.Equal("m-list-item", _block.Modifier("link", false).Build());
    }

    [Fact]
    public void Block_modifier_with_multi_true_conditions()
    {
        Assert.Equal("m-list-item m-list-item--active m-list-item--link",
            _block.Modifier(new Dictionary<string, bool>
            {
                { "active", true },
                { "link", true }
            }).Build());
    }

    [Fact]
    public void Block_modifier_with_multi_false_conditions()
    {
        Assert.Equal("m-list-item",
            _block.Modifier(new Dictionary<string, bool>
            {
                { "active", false },
                { "link", false }
            }).Build());
    }

    [Fact]
    public void Block_modifier_with_multi_true_and_false_conditions()
    {
        Assert.Equal("m-list-item m-list-item--active",
            _block.Modifier(new Dictionary<string, bool>
            {
                { "active", true },
                { "link", false }
            }).Build());
    }

    [Fact]
    public void Block_modifier_with_one_argument_and_default_name()
    {
        var active = true;
        Assert.Equal("m-list-item m-list-item--active", _block.Modifier(active).Build());

        var link = false;
        Assert.Equal("m-list-item", _block.Modifier(link).Build());
    }

    [Fact]
    public void Block_modifier_with_two_arguments_and_default_name()
    {
        var active = true;
        var link = true;
        Assert.Equal("m-list-item m-list-item--active m-list-item--link", _block.Modifier(active, link).Build());

        var modifier1 = false;
        var modifier2 = false;
        Assert.Equal("m-list-item", _block.Modifier(modifier1, modifier2).Build());
    }

    [Fact]
    public void Block_modifier_with_one_argument_and_custom_name()
    {
        var active = true;
        Assert.Equal("m-list-item m-list-item--living", _block.Modifier(active, "living").Build());

        var link = false;
        Assert.Equal("m-list-item", _block.Modifier(link, "clickable").Build());
    }

    [Fact]
    public void Block_modifier_with_two_arguments_and_custom_name()
    {
        var active = true;
        var link = true;
        Assert.Equal("m-list-item m-list-item--living m-list-item--clickable",
            _block.Modifier(active, link, "living", "clickable").Build());

        var modifier1 = false;
        var modifier2 = false;
        Assert.Equal("m-list-item",
            _block.Modifier(modifier1, modifier2, "custom-modifier1", "custom-modifier2").Build());
    }

    [Fact]
    public void Block_modifier_with_one_true_and_one_false_arguments()
    {
        var active = false;
        var link = true;
        Assert.Equal("m-list-item m-list-item--link", _block.Modifier(active, link).Build());
        Assert.Equal("m-list-item m-list-item--clickable",
            _block.Modifier(active, link, "living", "clickable").Build());
    }

    [Fact]
    public void Block_modifier_enum()
    {
        Assert.Equal("m-list-item m-list-item--density-default", _block.Modifier(Density.Default).Build());
        Assert.Equal("m-list-item m-list-item--density-comfortable", _block.Modifier(Density.Comfortable).Build());
        Assert.Equal("m-list-item m-list-item--density-compact", _block.Modifier(Density.Compact).Build());
    }

    [Fact]
    public void GenerateCssClasses()
    {
        var classes = _block.Modifier("active").And("link").GenerateCssClasses();
        Assert.Collection(classes,
            item => Assert.Equal("m-list-item", item),
            item => Assert.Equal("m-list-item--active", item),
            item => Assert.Equal("m-list-item--link", item));

        var block2 = new Block("m-sheet");
        var classes2 = classes.Concat(block2.Modifier("outlined").GenerateCssClasses());
        Assert.Collection(classes2,
            item => Assert.Equal("m-list-item", item),
            item => Assert.Equal("m-list-item--active", item),
            item => Assert.Equal("m-list-item--link", item),
            item => Assert.Equal("m-sheet", item),
            item => Assert.Equal("m-sheet--outlined", item));
    }
}