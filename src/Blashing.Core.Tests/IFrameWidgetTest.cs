using Bunit;

using Blashing.Core.Components.IFrame;

namespace Blashing.Core.Tests;

public class IFrameWidgetTest : BunitContext
{
    [Fact]
    public void IFrameWidgetMarkupShouldContainPassedInValues()
    {
        var url = "https://www.alexhedley.com/";

        var cut = Render<IFrameWidget>(parameters => parameters
                .Add(p => p.Url, url)
            );

        //var widget = @"
        //    <div class=""widget-iframe"">
        //        <iframe src="https://www.alexhedley.com/" frameborder="0"></iframe>
        //    </div>";

        var expectedIFrameMarkup = $"<iframe src=\"{url}\" frameborder=\"0\"></iframe>";
        cut.FindAll("iframe")[0].MarkupMatches(expectedIFrameMarkup);
    }

    [Fact]
    public void IFrameWidgetShouldContainPassedInValues()
    {
        var url = "https://www.alexhedley.com/";

        var cut = Render<IFrameWidget>(parameters => parameters
                .Add(p => p.Url, url)
            );

        var iFrameWidget = cut.Instance;
        Assert.Equal(iFrameWidget.Url, url);
    }
}