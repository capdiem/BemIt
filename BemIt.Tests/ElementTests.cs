namespace BemIt.Tests;

public class BemCssBuilderTests
{
    private readonly Block _block = new("m-list-item");
    
    [Fact]
    public void Element()
    {
        Assert.Equal("m-list-item__avatar", _block.Element("avatar").Build());
    }

    [Fact]
    public void Block_modifier_empty_ctor()
    {
        Assert.Equal("m-list-item__avatar", _block.Element("avatar").Modifier().Build());
    }

    [Fact]
    public void Element_modifier()
    {
        Assert.Equal("m-list-item__avatar m-list-item__avatar--tile", _block.Element("avatar").Modifier("tile").Build());
    }

    [Fact]
    public void Element_modifier_with_true_condition()
    {
        Assert.Equal("m-list-item__avatar m-list-item__avatar--tile", _block.Element("avatar").Modifier("tile", true).Build());
    }

    [Fact]
    public void Element_modifier_with_false_condition()
    {
        Assert.Equal("m-list-item__avatar", _block.Element("avatar").Modifier("tile", false).Build());
    }

    [Fact]
    public void Element_modifier_with_multi_true_conditions()
    {
        Assert.Equal("m-list-item__avatar m-list-item__avatar--tile m-list-item__avatar--small",
            _block.Element("avatar").Modifier(new Dictionary<string, bool>
            {
                { "tile", true },
                { "small", true }
            }).Build());
    }

    [Fact]
    public void Element_modifier_with_multi_false_conditions()
    {
        Assert.Equal("m-list-item__avatar",
            _block.Element("avatar").Modifier(new Dictionary<string, bool>
            {
                { "tile", false },
                { "small", false }
            }).Build());
    }

    [Fact]
    public void Element_modifier_with_multi_true_and_false_conditions()
    {
        Assert.Equal("m-list-item__avatar m-list-item__avatar--tile",
            _block.Element("avatar").Modifier(new Dictionary<string, bool>
            {
                { "tile", true },
                { "small", false }
            }).Build());
    }

    [Fact]
    public void Element_modifier_with_one_argument_and_default_name()
    {
        var tile = true;
        Assert.Equal("m-list-item__avatar m-list-item__avatar--tile", _block.Element("avatar").Modifier(tile).Build());

        var link = false;
        Assert.Equal("m-list-item__avatar", _block.Element("avatar").Modifier(link).Build());
    }

    [Fact]
    public void Element_modifier_with_two_arguments_and_default_name()
    {
        var active = true;
        var link = true;
        Assert.Equal("m-list-item m-list-item--active m-list-item--link", _block.Modifier(active, link).Build());

        var modifier1 = false;
        var modifier2 = false;
        Assert.Equal("m-list-item", _block.Modifier(modifier1, modifier2).Build());
    }

    [Fact]
    public void Element_modifier_with_one_argument_and_custom_name()
    {
        var active = true;
        Assert.Equal("m-list-item m-list-item--living", _block.Modifier(active, "living").Build());

        var link = false;
        Assert.Equal("m-list-item", _block.Modifier(link, "clickable").Build());
    }

    [Fact]
    public void Element_modifier_with_two_arguments_and_custom_name()
    {
        var active = true;
        var link = true;
        Assert.Equal("m-list-item m-list-item--living m-list-item--clickable", _block.Modifier(active, link, "living", "clickable").Build());

        var modifier1 = false;
        var modifier2 = false;
        Assert.Equal("m-list-item", _block.Modifier(modifier1, modifier2, "custom-modifier1", "custom-modifier2").Build());
    }

    [Fact]
    public void Element_modifier_with_one_true_and_one_false_arguments()
    {
        var active = false;
        var link = true;
        Assert.Equal("m-list-item m-list-item--link", _block.Modifier(active, link).Build());
        Assert.Equal("m-list-item m-list-item--clickable", _block.Modifier(active, link, "living", "clickable").Build());
    }

    [Fact]
    public void Element_modifier_with_three_arguments()
    {
        var active = true;
        var link = true;
        var ripple = true;

        Assert.Equal("m-list-item m-list-item--active m-list-item--link m-list-item--ripple",
            _block.Modifier(active, link, ripple).Build());

        Assert.Equal("m-list-item m-list-item--living m-list-item--clickable m-list-item--anim",
            _block.Modifier(active, link, ripple, "living", "clickable", "anim").Build());

        var modifier1 = false;
        var modifier2 = false;
        var modifier3 = false;

        Assert.Equal("m-list-item",
            _block.Modifier(modifier1, modifier2, modifier3).Build());

        Assert.Equal("m-list-item",
            _block.Modifier(modifier1, modifier2, modifier3, "custom-modifier1", "custom-modifier2", "custom-modifier3").Build());
    }
}
