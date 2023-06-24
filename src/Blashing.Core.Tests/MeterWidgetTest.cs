using Bunit;

using Blashing.Core.Components.Meter;

namespace Blashing.Core.Tests;

public class MeterWidgetTest : TestContext
{
    [Fact]
    public void MeterWidgetMarkupShouldContainPassedInValues()
    {
        var title = "a";
        var moreInfo = "c";
        var updatedAtMessage = "d";
        var angleOffset = 125;
        var angleArc = 250;
        var height = 200;
        var width = 200;
        var readOnly = true;
        var value = 1;
        var min = 0;
        var max = 100;

        var cut = RenderComponent<MeterWidget>(parameters => parameters
                .Add(p => p.Title, title)
                .Add(p => p.MoreInfo, moreInfo)
                .Add(p => p.UpdatedAtMessage, updatedAtMessage)
                .Add(p => p.AngleOffset, angleOffset)
                .Add(p => p.AngleArc, angleArc)
                .Add(p => p.Height, height)
                .Add(p => p.Width, width)
                .Add(p => p.ReadOnly, readOnly)
                .Add(p => p.Value, value)
                .Add(p => p.Min, min)
                .Add(p => p.Max, max)
            );
        
        //var widget = @"
        //    <div class=""widget-meter"">
        //        <h1 class=""title"">a</h1>
        //        <input class="meter" >
        //        <p class=""more-info"">c</p>
        //        <p class=""updated-at"">d</p>
        //    </div>";

        var expectedTitleMarkup = $"<h1 class=\"title\">{title}</h1>";
        cut.FindAll("h1")[0].MarkupMatches(expectedTitleMarkup);

        // var expectedInputMarkup = $"<input>";
        // cut.FindAll("input")[0].MarkupMatches(expectedInputMarkup);
        
        var expectedMoreInfoMarkup = $"<p class=\"more-info\">{moreInfo}</p>";
        cut.FindAll("p")[0].MarkupMatches(expectedMoreInfoMarkup);

        var expectedUpdatedAtMessageMarkup = $"<p class=\"updated-at\">{updatedAtMessage}</p>";
        cut.FindAll("p")[1].MarkupMatches(expectedUpdatedAtMessageMarkup);
    }

    [Fact]
    public void MeterWidgetShouldContainPassedInValues()
    {
        var title = "a";
        var moreInfo = "c";
        var updatedAtMessage = "d";
        var angleOffset = 125;
        var angleArc = 250;
        var height = 200;
        var width = 200;
        var readOnly = true;
        var value = 1;
        var min = 0;
        var max = 100;

        var cut = RenderComponent<MeterWidget>(parameters => parameters
            .Add(p => p.Title, title)
            .Add(p => p.MoreInfo, moreInfo)
            .Add(p => p.UpdatedAtMessage, updatedAtMessage)
            .Add(p => p.AngleOffset, angleOffset)
            .Add(p => p.AngleArc, angleArc)
            .Add(p => p.Height, height)
            .Add(p => p.Width, width)
            .Add(p => p.ReadOnly, readOnly)
            .Add(p => p.Value, value)
            .Add(p => p.Min, min)
            .Add(p => p.Max, max)
        );

        var meterWidget = cut.Instance;
        Assert.Equal(meterWidget.Title, title);
        Assert.Equal(meterWidget.MoreInfo, moreInfo);
        Assert.Equal(meterWidget.UpdatedAtMessage, updatedAtMessage);
        Assert.Equal(meterWidget.AngleOffset, angleOffset);
        Assert.Equal(meterWidget.AngleArc, angleArc);
        Assert.Equal(meterWidget.Height, height);
        Assert.Equal(meterWidget.Width, width);
        Assert.Equal(meterWidget.ReadOnly, readOnly);
        Assert.Equal(meterWidget.Value, value);
        Assert.Equal(meterWidget.Min, min);
        Assert.Equal(meterWidget.Max, max);
    }
}