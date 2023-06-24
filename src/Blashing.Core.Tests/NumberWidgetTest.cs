using Bunit;

using Blashing.Core.Components.Number;

namespace Blashing.Core.Tests;

public class NumberWidgetTest : TestContext
{
    [Fact]
    public void NumberWidgetMarkupShouldContainPassedInValues()
    {
        var title = "Number";
        var current = "Current";
        var difference = "Difference";
        var moreInfo = "More Info";
        var updatedAtMessage = "Updated At Message";

        var cut = RenderComponent<NumberWidget>(parameters => parameters
                .Add(p => p.Title, title)
                .Add(p => p.Current, current)
                .Add(p => p.Difference, difference)
                .Add(p => p.MoreInfo, moreInfo)
                .Add(p => p.UpdatedAtMessage, updatedAtMessage)
            );
        
        // var widget = @"
        //     <div class=""widget-number"">
        //         <h1 class=""title"">Number Title</h1>
        //         <h2 class=""value"" data-bind=""current | shortenedNumber | prepend prefix | append suffix"">Number Current</h2>
        //         <p class=""change-rate"">
        //              <i data-bind-class=""arrow""></i><span>Number Difference</span>
        //         </p>
        //         <p class=""more-info"">Number More Info</p>
        //         <p class=""updated-at"">Number Updated At Message</p>
        //     </div>";

        var expectedTitleMarkup = $"<h1 class=\"title\">{title}</h1>";
        cut.FindAll("h1")[0].MarkupMatches(expectedTitleMarkup);

        var expectedCurrentMarkup = $"<h2 class=\"value\" data-bind=\"current | shortenedNumber | prepend prefix | append suffix\">{current}</h2>";
        cut.FindAll("h2")[0].MarkupMatches(expectedCurrentMarkup);

        var expectedDifferenceMarkup = $"<span>{difference}</span>";
        cut.FindAll("span")[0].MarkupMatches(expectedDifferenceMarkup);
        
        var expectedMoreInfoMarkup = $"<p class=\"more-info\">{moreInfo}</p>";
        cut.FindAll("p")[1].MarkupMatches(expectedMoreInfoMarkup);

        var expectedUpdatedAtMessageMarkup = $"<p class=\"updated-at\">{updatedAtMessage}</p>";
        cut.FindAll("p")[2].MarkupMatches(expectedUpdatedAtMessageMarkup);
    }

    [Fact]
    public void NumberWidgetShouldContainPassedInValues()
    {
        var title = "Number";
        var current = "Current";
        var difference = "Difference";
        var moreInfo = "More Info";
        var updatedAtMessage = "Updated At Message";

        var cut = RenderComponent<NumberWidget>(parameters => parameters
            .Add(p => p.Title, title)
            .Add(p => p.Current, current)
            .Add(p => p.Difference, difference)
            .Add(p => p.MoreInfo, moreInfo)
            .Add(p => p.UpdatedAtMessage, updatedAtMessage)
        );

        var numberWidget = cut.Instance;
        Assert.Equal(numberWidget.Title, title);
        Assert.Equal(numberWidget.Current, current);
        Assert.Equal(numberWidget.Difference, difference);
        Assert.Equal(numberWidget.MoreInfo, moreInfo);
        Assert.Equal(numberWidget.UpdatedAtMessage, updatedAtMessage);
    }
}