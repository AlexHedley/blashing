using Bunit;


using Blashing.Core.Components.Clock;

namespace Blashing.Core.Tests;

public class ClockWidgetTest : TestContext
{
    [Fact]
    public void ClockWidgetMarkupShouldContainPassedInValues()
    {
        var date = "23/06/2023";
        var time = "20:53";

        var cut = RenderComponent<ClockWidget>(parameters => parameters
                .Add(p => p.Date, date)
                .Add(p => p.Time, time)
            );

        //var widget = @"
        //    <div class=""widget-clock"">
        //        <h1>23/06/2023</h1>
        //        <h1>20:53</h1>
        //    </div>";

        var expectedDateMarkup = $"<h1>{date}</h1>";
        cut.FindAll("h1")[0].MarkupMatches(expectedDateMarkup);

        var expectedTimeMarkup = $"<h2>{time}</h2>";
        cut.FindAll("h2")[0].MarkupMatches(expectedTimeMarkup);
    }

    [Fact]
    public void ClockWidgetShouldContainPassedInValues()
    {
        var date = "23/06/2023";
        var time = "20:53";

        var cut = RenderComponent<ClockWidget>(parameters => parameters
                .Add(p => p.Date, date)
                .Add(p => p.Time, time)
            );

        var clockWidget = cut.Instance;
        Assert.Equal(clockWidget.Date, date);
        Assert.Equal(clockWidget.Time, time);
    }
}