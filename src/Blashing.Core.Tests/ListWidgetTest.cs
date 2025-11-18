using Bunit;

using Blashing.Core.Components.List;

namespace Blashing.Core.Tests;

public class ListWidgetTest : BunitContext
{
    [Fact]
    public void TextWidgetMarkupShouldContainPassedInValues()
    {
        var title = "a";
        var moreInfo = "c";
        var updatedAtMessage = "d";
        var items = new List<(string label, string value)>() { ("a", "b"), ("c", "d") };

        var cut = Render<ListWidget>(parameters => parameters
                .Add(p => p.Title, title)
                .Add(p => p.MoreInfo, moreInfo)
                .Add(p => p.UpdatedAtMessage, updatedAtMessage)
                .Add(p => p.Items, items)
            );
        
        // var widget = @"
        //     <div class=""widget-list"">
        //     <h1 class=""title"">List Title</h1>
        //         <ol>
        //             <li>
        //                 <span class=""label"">a</span>
        //                 <span class=""value"">b</span>
        //             </li>
        //             <li>
        //                 <span class=""label"">c</span>
        //                 <span class=""value"">d</span>
        //             </li>
        //         </ol>
        //         <ul class=""list-nostyle"">
        //             <li>
        //                 <span class=""label"">a</span>
        //                 <span class=""value"">b</span>
        //             </li>
        //             <li>
        //                 <span class=""label"">c</span>
        //                 <span class=""value"">d</span>
        //             </li>
        //         </ul>
        //         <p class=""more-info"">List Title More Info</p>
        //         <p class=""updated-at"">24 June 2023</p>
        //     </div>";

        var expectedTitleMarkup = $"<h1 class=\"title\">{title}</h1>";
        cut.FindAll("h1")[0].MarkupMatches(expectedTitleMarkup);

        var expectedMoreInfoMarkup = $"<p class=\"more-info\">{moreInfo}</p>";
        cut.FindAll("p")[0].MarkupMatches(expectedMoreInfoMarkup);

        var expectedUpdatedAtMessageMarkup = $"<p class=\"updated-at\">{updatedAtMessage}</p>";
        cut.FindAll("p")[1].MarkupMatches(expectedUpdatedAtMessageMarkup);
    }

    [Fact]
    public void TextWidgetShouldContainPassedInValues()
    {
        var title = "a";
        var moreInfo = "c";
        var updatedAtMessage = "d";
        var items = new List<(string label, string value)>() { ("a", "b"), ("c", "d") };

        var cut = Render<ListWidget>(parameters => parameters
            .Add(p => p.Title, title)
            .Add(p => p.MoreInfo, moreInfo)
            .Add(p => p.UpdatedAtMessage, updatedAtMessage)
            .Add(p => p.Items, items)
        );

        var textWidget = cut.Instance;
        Assert.Equal(textWidget.Title, title);
        Assert.Equal(textWidget.MoreInfo, moreInfo);
        Assert.Equal(textWidget.UpdatedAtMessage, updatedAtMessage);
        Assert.Equal(textWidget.Items, items);
    }
}