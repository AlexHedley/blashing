using Bunit;

using Blashing.Core.Components.IFrame;

namespace Blashing.Core.Tests;

public class IFrameWidgetTest : TestContext
{
    [Fact]
    public void IFramekWidgetMarkupShouldContainPassedInValues()
    {
        var url = "https://www.alexhedley.com/";

        var cut = RenderComponent<IFrameWidget>(parameters => parameters
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
    public void IFramekWidgetShouldContainPassedInValues()
    {
        var url = "https://www.alexhedley.com/";

        var cut = RenderComponent<IFrameWidget>(parameters => parameters
                .Add(p => p.Url, url)
            );

        var IFrameWidget = cut.Instance;
        Assert.Equal(IFrameWidget.Url, url);
    }
}