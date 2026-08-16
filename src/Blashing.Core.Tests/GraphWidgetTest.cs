using Bunit;

using Blashing.Core.Components.Graph;

namespace Blashing.Core.Tests;

public class GraphWidgetTest : BunitContext
{
    [Fact]
    public void GraphWidgetMarkupShouldContainPassedInValues()
    {
        var title = "Graph 1";
        var moreInfo = "This graph contains lots of useful data";

        var cut = Render<GraphWidget>(parameters => parameters
                .Add(p => p.Title, title)
                .Add(p => p.MoreInfo, moreInfo)
            );

        var expectedTitleMarkup = $"<h1 class=\"title\">{title}</h1>";
        cut.FindAll("h1")[0].MarkupMatches(expectedTitleMarkup);

        var expectedMoreInfoMarkup = $"<p class=\"more-info\">{moreInfo}</p>";
        cut.FindAll("p")[0].MarkupMatches(expectedMoreInfoMarkup);
    }

    [Fact]
    public void GraphWidgetShouldContainPassedInValues()
    {
        var title = "Graph 1";
        var moreInfo = "This graph contains lots of useful data";
        
        var cut = Render<GraphWidget>(parameters => parameters
                .Add(p => p.Title, title)
                .Add(p => p.MoreInfo, moreInfo)
            );

        var graphWidget = cut.Instance;
        Assert.Equal(graphWidget.Title, title);
        Assert.Equal(graphWidget.MoreInfo, moreInfo);
    }

    [Fact]
    public void GraphWidgetWithCurrentValueShouldRenderValue()
    {
        var title = "Graph 1";
        var current = "42";
        var prefix = "$";
        var suffix = "k";

        var cut = Render<GraphWidget>(parameters => parameters
                .Add(p => p.Title, title)
                .Add(p => p.Current, current)
                .Add(p => p.Prefix, prefix)
                .Add(p => p.Suffix, suffix)
            );

        var graphWidget = cut.Instance;
        Assert.Equal(graphWidget.Current, current);
        Assert.Equal(graphWidget.Prefix, prefix);
        Assert.Equal(graphWidget.Suffix, suffix);

        var h2 = cut.FindAll("h2")[0];
        h2.MarkupMatches($"<h2 class=\"value\">{prefix}{current}{suffix}</h2>");
    }

    [Fact]
    public void GraphWidgetWithPointsShouldRenderSvg()
    {
        var points = new List<double> { 10, 20, 15, 30, 25 };

        var cut = Render<GraphWidget>(parameters => parameters
                .Add(p => p.Title, "Graph")
                .Add(p => p.Points, points)
            );

        var graphWidget = cut.Instance;
        Assert.Equal(graphWidget.Points, points);

        var svgs = cut.FindAll("svg");
        Assert.Single(svgs);
    }

    [Fact]
    public void GraphWidgetWithoutPointsShouldNotRenderSvg()
    {
        var cut = Render<GraphWidget>(parameters => parameters
                .Add(p => p.Title, "Graph")
            );

        var svgs = cut.FindAll("svg");
        Assert.Empty(svgs);
    }

    [Fact]
    public void GenerateSvgPathShouldReturnEmptyForFewerThanTwoPoints()
    {
        var cut = Render<GraphWidget>(parameters => parameters
                .Add(p => p.Points, new List<double> { 42 })
            );

        var path = cut.Instance.GenerateSvgPath();
        Assert.Equal(string.Empty, path);
    }

    [Fact]
    public void GenerateSvgPathShouldReturnValidPathForTwoPoints()
    {
        var cut = Render<GraphWidget>(parameters => parameters
                .Add(p => p.Points, new List<double> { 10, 20 })
            );

        var path = cut.Instance.GenerateSvgPath();
        Assert.NotEmpty(path);
        Assert.StartsWith("M ", path);
        Assert.Contains(" C ", path);
        Assert.EndsWith(" Z", path);
    }
}