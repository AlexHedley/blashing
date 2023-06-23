using Bunit;

using Blashing.Core.Components.Graph;

namespace Blashing.Core.Tests;

public class GraphWidgetTest : TestContext
{
    [Fact]
    public void CommentsWidgetMarkupShouldContainPassedInValues()
    {
        var title = "Graph 1";
        var moreInfo = "This graph contains lots of useful data";

        var cut = RenderComponent<GraphWidget>(parameters => parameters
                .Add(p => p.Title, title)
                .Add(p => p.MoreInfo, moreInfo)
            );

        //var widget = @"
        //    <h1 class=""title"">@Title</h1>
        //    <h2 class="value" data-bind="current | prettyNumber | prepend prefix | append suffix" b-lgoxk5ilas=""></h2>
        //    <p class=""more-info"">@MoreInfo</p>";

        var expectedTitleMarkup = $"<h1 class=\"title\">{title}</h1>";
        cut.FindAll("h1")[0].MarkupMatches(expectedTitleMarkup);

        var expectedMoreInfoMarkup = $"<p class=\"more-info\">{moreInfo}</p>";
        cut.FindAll("p")[0].MarkupMatches(expectedMoreInfoMarkup);
    }

    [Fact]
    public void CommentsWidgetShouldContainPassedInValues()
    {
        var title = "Graph 1";
        var moreInfo = "This graph contains lots of useful data";
        
        var cut = RenderComponent<GraphWidget>(parameters => parameters
                .Add(p => p.Title, title)
                .Add(p => p.MoreInfo, moreInfo)
            );

        var graphWidget = cut.Instance;
        Assert.Equal(graphWidget.Title, title);
        Assert.Equal(graphWidget.MoreInfo, moreInfo);
    }
}