using Bunit;
using Xunit;

using Blashing.Widgets.ServerStatusSquares;

namespace Blashing.Widgets.Tests;

public class ServerStatusSquareWidgetTest : BunitContext
{
    [Fact]
    public void ServerStatusSquareWidgetMarkupShouldContainPassedInValues()
    {
        var title = "Server Status Square Title";
        var updatedAtMessage = "Updated At Message";

        var cut = Render<ServerStatusSquareWidget>(parameters => parameters
            .Add(p => p.Title, title)
            .Add(p => p.UpdatedAtMessage, updatedAtMessage)
        );
        
        // var widget = @"
        //     <div class=""widget-server-status-square"" style=""background-color:"">
        //         <h1 class=""title"">Server Status Square Title</h1>
        //         <p class=""updated-at"">Updated At Message</p>
        //     </div>";

        var expectedTitleMarkup = $"<h1 class=\"title\">{title}</h1>";
        cut.FindAll("h1")[0].MarkupMatches(expectedTitleMarkup);

        var expectedUpdatedAtMessageMarkup = $"<p class=\"updated-at\">{updatedAtMessage}</p>";
        cut.FindAll("p")[0].MarkupMatches(expectedUpdatedAtMessageMarkup);
    }

    [Fact]
    public void ServerStatusSquareWidgetShouldContainPassedInValues()
    {
        var title = "Server Status Square Title";
        var updatedAtMessage = "Updated At Message";

        var cut = Render<ServerStatusSquareWidget>(parameters => parameters
            .Add(p => p.Title, title)
            .Add(p => p.UpdatedAtMessage, updatedAtMessage)
        );

        var serverStatusSquareWidget = cut.Instance;
        Assert.Equal(serverStatusSquareWidget.Title, title);
        Assert.Equal(serverStatusSquareWidget.UpdatedAtMessage, updatedAtMessage);
    }

    [Fact]
    public void ServerStatusSquareWidgetResultUpShouldSetGreenBackgroundColor()
    {
        var cut = Render<ServerStatusSquareWidget>(parameters => parameters
            .Add(p => p.Title, "Server Up")
            .Add(p => p.Result, true)
        );

        var serverStatusSquareWidget = cut.Instance;
        Assert.Equal(true, serverStatusSquareWidget.Result);
        Assert.Equal("#96BF48", serverStatusSquareWidget.BackgroundColor);
    }

    [Fact]
    public void ServerStatusSquareWidgetResultDownShouldSetRedBackgroundColor()
    {
        var cut = Render<ServerStatusSquareWidget>(parameters => parameters
            .Add(p => p.Title, "Server Down")
            .Add(p => p.Result, false)
        );

        var serverStatusSquareWidget = cut.Instance;
        Assert.Equal(false, serverStatusSquareWidget.Result);
        Assert.Equal("#BF4848", serverStatusSquareWidget.BackgroundColor);
    }

    [Fact]
    public void ServerStatusSquareWidgetExplicitBackgroundColorOverridesResult()
    {
        var cut = Render<ServerStatusSquareWidget>(parameters => parameters
            .Add(p => p.Title, "Server Up")
            .Add(p => p.Result, true)
            .Add(p => p.BackgroundColor, "#123456")
        );

        var serverStatusSquareWidget = cut.Instance;
        Assert.Equal("#123456", serverStatusSquareWidget.BackgroundColor);
    }
}