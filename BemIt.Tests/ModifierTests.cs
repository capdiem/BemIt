namespace BemIt.Tests;

public class ModifierTests
{
    private readonly Block _block = new("m-list-item");

    [Fact]
    public void Modifier_one_with()
    {
        Assert.Equal("m-list-item m-list-item--active", _block.Modifier().With("active").Build());
    }

    [Fact]
    public void Modifier_two_withs()
    {
        Assert.Equal("m-list-item m-list-item--active m-list-item--link", _block.Modifier().With("active").With("link").Build());
    }

    [Fact]
    public void Modifier_three_withs()
    {
        Assert.Equal("m-list-item m-list-item--active m-list-item--link m-list-item--ripple",
            _block.Modifier().With("active").With("link").With("ripple").Build());
    }

    [Fact]
    public void Modifier_with_enum_with_one_mod()
    {
        Assert.Equal("m-list-item m-list-item--density-comfortable m-list-item--link",
            _block.Modifier().With(Density.Comfortable).With("link").Build());
    }

    [Fact]
    public void Modifier_with_enum_with_multi()
    {
        Assert.Equal("m-list-item m-list-item--density-comfortable m-list-item--link m-list-item--active",
            _block.Modifier().With(Density.Comfortable).With(new Dictionary<string, bool>()
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
            _block.Modifier().With(active).With(Density.Comfortable).Build());

        Assert.Equal("m-list-item m-list-item--active m-list-item--link m-list-item--density-comfortable",
            _block.Modifier().With(active, link).With(Density.Comfortable).Build());

        Assert.Equal("m-list-item m-list-item--active m-list-item--link m-list-item--ripple m-list-item--density-comfortable",
            _block.Modifier().With(active, link, ripple).With(Density.Comfortable).Build());
    }
}
