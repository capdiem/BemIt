using BemIt.Extensions;

namespace BemIt.Tests;

public class CssProviderTests
{
    [Fact]
    public void Test1()
    {
        // Arrange
        var cssProvider = new CssProvider("m-list-item");

        // Act
        cssProvider
            .Block(css => css.Modifier("link").Add("active"),
                style =>  style.Add("color", "red"))
            .Element("avatar", css => css.Modifier("tile"))
            .Extend("title") // extend root block to 'm-list-item-title'
            .Element("intro")
            .Revert() // back to root block 'm-list-item'
            .Element("content");

        // Assert
        var rootClass = cssProvider.GetClass();
        var avatarClass = cssProvider.GetClass("avatar");
        var titleClass = cssProvider.GetClass("title");
        var introClass = cssProvider.GetClass("intro");
        var contentClass = cssProvider.GetClass("content");

        Assert.Equal("m-list-item m-list-item--link m-list-item--active", rootClass);
        Assert.Equal("m-list-item__avatar m-list-item__avatar--tile", avatarClass);
        Assert.Equal("m-list-item-title", titleClass);
        Assert.Equal("m-list-item-title__intro", introClass);
        Assert.Equal("m-list-item__content", contentClass);
    }
}