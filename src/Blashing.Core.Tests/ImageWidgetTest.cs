using Bunit;

using Blashing.Core.Components.Image;

namespace Blashing.Core.Tests;

public class ImageWidgetTest : BunitContext
{
    [Fact]
    public void ImageWidgetMarkupShouldContainPassedInValues()
    {
        var src = "https://www.alexhedley.com/images/icon-myapps.png";
        var width = "100px";

        var cut = Render<ImageWidget>(parameters => parameters
            .Add(p => p.Src, src)
            .Add(p => p.Width, width)
        );

        //var widget = @"
        //    <div class=""widget-image"">
        //      <img data-bind-src=""image | prepend '/assets'"" src=""@Src"" width="@Width"/>
        //    </div>";

        var expectedImageMarkup = $"<img data-bind-src=\"image | prepend '/assets'\" src=\"{src}\" width=\"{width}\" />";
        cut.FindAll("img")[0].MarkupMatches(expectedImageMarkup);
    }

    [Fact]
    public void ClockWidgetShouldContainPassedInValues()
    {
        var src = "https://www.alexhedley.com/images/icon-myapps.png";
        var width = "100px";

        var cut = Render<ImageWidget>(parameters => parameters
            .Add(p => p.Src, src)
            .Add(p => p.Width, width)
        );

        var imageWidget = cut.Instance;
        Assert.Equal(imageWidget.Src, src);
        Assert.Equal(imageWidget.Width, width);
    }
}