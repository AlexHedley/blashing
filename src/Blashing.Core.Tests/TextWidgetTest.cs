using Bunit;

using Blashing.Core.Components.Text;

namespace Blashing.Core.Tests;

public class TextWidgetTest : TestContext
{
    [Fact]
    public void TextWidgetMarkupShouldContainPassedInValues()
    {
        var title = "a";
        var text = "b";
        var moreInfo = "c";
        var updatedAtMessage = "d";

        var cut = RenderComponent<TextWidget>(parameters => parameters
                .Add(p => p.Title, title)
                .Add(p => p.Text, text)
                .Add(p => p.MoreInfo, moreInfo)
                .Add(p => p.UpdatedAtMessage, updatedAtMessage)
            );
        
        //var widget = @"
        //    <div class=""widget-text"">
        //        <h1 class=""title"">a</h1>
        //        <h3>b</h3>
        //        <p class=""more-info"">c</p>
        //        <p class=""updated-at"">d</p>
        //    </div>";

        var expectedTitleMarkup = $"<h1 class=\"title\">{title}</h1>";
        cut.FindAll("h1")[0].MarkupMatches(expectedTitleMarkup);

        var expectedTextMarkup = $"<h3>{text}</h3>";
        cut.FindAll("h3")[0].MarkupMatches(expectedTextMarkup);

        var expectedMoreInfoMarkup = $"<p class=\"more-info\">{moreInfo}</p>";
        cut.FindAll("p")[0].MarkupMatches(expectedMoreInfoMarkup);

        var expectedUpdatedAtMessageMarkup = $"<p class=\"updated-at\">{updatedAtMessage}</p>";
        cut.FindAll("p")[1].MarkupMatches(expectedUpdatedAtMessageMarkup);
    }

    [Fact]
    public void TextWidgetShouldContainPassedInValues()
    {
        var title = "a";
        var text = "b";
        var moreInfo = "c";
        var updatedAtMessage = "d";

        var cut = RenderComponent<TextWidget>(parameters => parameters
                .Add(p => p.Title, title)
                .Add(p => p.Text, text)
                .Add(p => p.MoreInfo, moreInfo)
                .Add(p => p.UpdatedAtMessage, updatedAtMessage)
            );

        var textWidget = cut.Instance;
        Assert.Equal(textWidget.Title, title);
        Assert.Equal(textWidget.Text, text);
        Assert.Equal(textWidget.MoreInfo, moreInfo);
        Assert.Equal(textWidget.UpdatedAtMessage, updatedAtMessage);
    }
}