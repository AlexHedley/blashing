using Bunit;

using Blashing.Core.Components.Meter;

namespace Blashing.Core.Tests;

public class MeterWidgetTest : BunitContext
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

        var cut = Render<MeterWidget>(parameters => parameters
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

        var expectedTitleMarkup = $"<h1 class=\"title\">{title}</h1>";
        cut.FindAll("h1")[0].MarkupMatches(expectedTitleMarkup);

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

        var cut = Render<MeterWidget>(parameters => parameters
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

    [Fact]
    public void MeterWidgetShouldShowSvgGauge()
    {
        var cut = Render<MeterWidget>(parameters => parameters
            .Add(p => p.Title, "Test")
            .Add(p => p.Value, 50)
            .Add(p => p.Min, 0)
            .Add(p => p.Max, 100)
        );

        var svg = cut.Find("svg.meter");
        Assert.NotNull(svg);

        var backgroundPath = cut.Find("path.meter-background");
        Assert.NotNull(backgroundPath);
        Assert.False(string.IsNullOrEmpty(backgroundPath.GetAttribute("d")));

        var valuePath = cut.Find("path.meter-value");
        Assert.NotNull(valuePath);
        Assert.False(string.IsNullOrEmpty(valuePath.GetAttribute("d")));
    }

    [Fact]
    public void MeterWidgetShouldHideValueArcWhenValueEqualsMin()
    {
        var cut = Render<MeterWidget>(parameters => parameters
            .Add(p => p.Value, 0)
            .Add(p => p.Min, 0)
            .Add(p => p.Max, 100)
        );

        var valuePaths = cut.FindAll("path.meter-value");
        Assert.Empty(valuePaths);
    }

    [Fact]
    public void MeterWidgetShouldShowCenterTextWhenDisplayInputIsTrue()
    {
        var cut = Render<MeterWidget>(parameters => parameters
            .Add(p => p.Value, 42)
            .Add(p => p.Min, 0)
            .Add(p => p.Max, 100)
            .Add(p => p.DisplayInput, true)
        );

        var text = cut.Find("text.meter-text");
        Assert.NotNull(text);
        Assert.Contains("42", text.TextContent);
    }

    [Fact]
    public void MeterWidgetShouldHideCenterTextWhenDisplayInputIsFalse()
    {
        var cut = Render<MeterWidget>(parameters => parameters
            .Add(p => p.Value, 42)
            .Add(p => p.Min, 0)
            .Add(p => p.Max, 100)
            .Add(p => p.DisplayInput, false)
        );

        var texts = cut.FindAll("text.meter-text");
        Assert.Empty(texts);
    }

    [Fact]
    public void MeterWidgetShouldShowPrefixAndSuffix()
    {
        var cut = Render<MeterWidget>(parameters => parameters
            .Add(p => p.Value, 75)
            .Add(p => p.Min, 0)
            .Add(p => p.Max, 100)
            .Add(p => p.Prefix, "$")
            .Add(p => p.Suffix, "%")
            .Add(p => p.DisplayInput, true)
        );

        var text = cut.Find("text.meter-text");
        Assert.Contains("$", text.TextContent);
        Assert.Contains("75", text.TextContent);
        Assert.Contains("%", text.TextContent);
    }

    [Fact]
    public void MeterWidgetDefaultsShouldProduceValidSvgPaths()
    {
        var cut = Render<MeterWidget>(parameters => parameters
            .Add(p => p.Value, 75)
        );

        var meterWidget = cut.Instance;
        Assert.Equal(-125, meterWidget.AngleOffset);
        Assert.Equal(250, meterWidget.AngleArc);
        Assert.Equal(200, meterWidget.Width);
        Assert.Equal(200, meterWidget.Height);
        Assert.Equal(100, meterWidget.Max);

        var backgroundPath = cut.Find("path.meter-background");
        var d = backgroundPath.GetAttribute("d");
        Assert.False(string.IsNullOrEmpty(d));
        Assert.StartsWith("M ", d);

        var valuePath = cut.Find("path.meter-value");
        var vd = valuePath.GetAttribute("d");
        Assert.False(string.IsNullOrEmpty(vd));
        Assert.StartsWith("M ", vd);
    }

    [Theory]
    [InlineData(0, 0, 100)]    // at min: no value arc
    [InlineData(50, 0, 100)]   // mid value
    [InlineData(100, 0, 100)]  // at max
    public void MeterWidgetArcRendersCorrectlyForValues(long value, long min, long max)
    {
        var cut = Render<MeterWidget>(parameters => parameters
            .Add(p => p.Value, value)
            .Add(p => p.Min, min)
            .Add(p => p.Max, max)
        );

        var backgroundPath = cut.Find("path.meter-background");
        Assert.False(string.IsNullOrEmpty(backgroundPath.GetAttribute("d")));

        if (value > min)
        {
            var valuePath = cut.Find("path.meter-value");
            Assert.NotNull(valuePath);
        }
        else
        {
            var valuePaths = cut.FindAll("path.meter-value");
            Assert.Empty(valuePaths);
        }
    }
}