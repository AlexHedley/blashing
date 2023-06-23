using Bunit;

using Blashing.Core.Components.Comments;

namespace Blashing.Core.Tests;

public class CommentsWidgetTest : TestContext
{
    [Fact]
    public void CommentsWidgetMarkupShouldContainPassedInValues()
    {
        var title = "Comment 1";
        var quote = "A rose by any other name would smell as sweet.";
        var moreInfo = "William Shakespeare";

        var cut = RenderComponent<CommentsWidget>(parameters => parameters
                .Add(p => p.Title, title)
                .Add(p => p.Quote, quote)
                .Add(p => p.MoreInfo, moreInfo)
            );

        //var widget = @"
        //    <h1 class=""title"">@Title</h1>
        //    <div class=""comment-container"">
        //        <h3><img data-bind-src='current_comment.avatar' /><span data-bind='current_comment.name' class=""name""></span></h3>
        //        <p class=""comment"">@Quote</p>
        //    </div>

        //    <p class=""more-info"">@MoreInfo</p>";

        var expectedTitleMarkup = $"<h1 class=\"title\">{title}</h1>";
        cut.FindAll("h1")[0].MarkupMatches(expectedTitleMarkup);

        //.comment-container { display: none; }
        var expectedQuoteMarkup = $"<p class=\"comment\">{quote}</p>";
        cut.FindAll("p")[0].MarkupMatches(expectedQuoteMarkup);

        var expectedMoreInfoMarkup = $"<p class=\"more-info\">{moreInfo}</p>";
        cut.FindAll("p")[1].MarkupMatches(expectedMoreInfoMarkup);
    }

    [Fact]
    public void CommentsWidgetShouldContainPassedInValues()
    {
        var title = "Comment 1";
        var quote = "A rose by any other name would smell as sweet.";
        var moreInfo = "William Shakespeare";

        var cut = RenderComponent<CommentsWidget>(parameters => parameters
                .Add(p => p.Title, title)
                .Add(p => p.Quote, quote)
                .Add(p => p.MoreInfo, moreInfo)
            );

        var textWidget = cut.Instance;
        Assert.Equal(textWidget.Title, title);
        Assert.Equal(textWidget.Quote, quote);
        Assert.Equal(textWidget.MoreInfo, moreInfo);
    }
}