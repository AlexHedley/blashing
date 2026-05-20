using Bunit;
using Xunit;

using Blashing.Widgets.Timeline;

namespace Blashing.Widgets.Tests;

public class TimelineWidgetTest : BunitContext
{
    [Fact]
    public void TimelineWidgetMarkupShouldContainPassedInValues()
    {
        var title = "Timeline Title";
        var moreInfo = "More Info";
        var updatedAtMessage = "Updated At Message";
        var items = new List<TimelineItem>()
        {
            new TimelineItem("10:00", "Event One"),
            new TimelineItem("11:30", "Event Two")
        };

        var cut = Render<TimelineWidget>(parameters => parameters
            .Add(p => p.Title, title)
            .Add(p => p.MoreInfo, moreInfo)
            .Add(p => p.UpdatedAtMessage, updatedAtMessage)
            .Add(p => p.Items, items)
        );

        var expectedTitleMarkup = $"<h1 class=\"title\">{title}</h1>";
        cut.FindAll("h1")[0].MarkupMatches(expectedTitleMarkup);

        var expectedMoreInfoMarkup = $"<p class=\"more-info\">{moreInfo}</p>";
        cut.FindAll("p")[0].MarkupMatches(expectedMoreInfoMarkup);

        var expectedUpdatedAtMessageMarkup = $"<p class=\"updated-at\">{updatedAtMessage}</p>";
        cut.FindAll("p")[1].MarkupMatches(expectedUpdatedAtMessageMarkup);
    }

    [Fact]
    public void TimelineWidgetShouldContainPassedInValues()
    {
        var title = "Timeline Title";
        var moreInfo = "More Info";
        var updatedAtMessage = "Updated At Message";
        var items = new List<TimelineItem>()
        {
            new TimelineItem("10:00", "Event One"),
            new TimelineItem("11:30", "Event Two")
        };

        var cut = Render<TimelineWidget>(parameters => parameters
            .Add(p => p.Title, title)
            .Add(p => p.MoreInfo, moreInfo)
            .Add(p => p.UpdatedAtMessage, updatedAtMessage)
            .Add(p => p.Items, items)
        );

        var timelineWidget = cut.Instance;
        Assert.Equal(timelineWidget.Title, title);
        Assert.Equal(timelineWidget.MoreInfo, moreInfo);
        Assert.Equal(timelineWidget.UpdatedAtMessage, updatedAtMessage);
        Assert.Equal(timelineWidget.Items, items);
    }
}
