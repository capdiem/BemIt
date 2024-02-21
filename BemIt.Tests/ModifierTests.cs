namespace BemIt.Tests;

public class ModifierTests
{
    private readonly Block _block = new("m-list-item");

    [Fact]
    public void Modifier_one_with()
    {
        Assert.Equal("m-list-item m-list-item--active", _block.Modifier("active").Build());
    }

    [Fact]
    public void Modifier_two_withs()
    {
        Assert.Equal("m-list-item m-list-item--active m-list-item--link",
            _block.Modifier("active").And("link").Build());
    }

    [Fact]
    public void Modifier_three_withs()
    {
        Assert.Equal("m-list-item m-list-item--active m-list-item--link m-list-item--ripple",
            _block.Modifier("active").And("link").And("ripple").Build());
    }

    [Fact]
    public void Modifier_with_enum_with_one_mod()
    {
        Assert.Equal("m-list-item m-list-item--density-comfortable m-list-item--link",
            _block.Modifier(Density.Comfortable).And("link").Build());
    }

    [Fact]
    public void Modifier_with_enum_with_multi()
    {
        Assert.Equal("m-list-item m-list-item--density-comfortable m-list-item--link m-list-item--active",
            _block.Modifier(Density.Comfortable).And(new Dictionary<string, bool>()
            {
                { "link", true },
                { "ripple", false },
                { "active", true }
            }).Build());
    }

    [Fact]
    public void Modifier_with_args_with_enum()
    {
        var active = true;
        var link = true;
        var ripple = true;

        Assert.Equal("m-list-item m-list-item--active m-list-item--density-comfortable",
            _block.Modifier(active).And(Density.Comfortable).Build());

        Assert.Equal("m-list-item m-list-item--active m-list-item--link m-list-item--density-comfortable",
            _block.Modifier(active, link).And(Density.Comfortable).Build());

        Assert.Equal(
            "m-list-item m-list-item--active m-list-item--link m-list-item--ripple m-list-item--density-comfortable",
            _block.Modifier(active, link, ripple).And(Density.Comfortable).Build());
    }
}