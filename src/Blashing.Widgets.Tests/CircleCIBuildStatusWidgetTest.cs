using Bunit;
using Xunit;

using Blashing.Widgets.CircleCIBuildStatus;

namespace Blashing.Widgets.Tests;

public class CircleCIBuildStatusWidgetTest : BunitContext
{
    [Fact]
    public void CircleCIBuildStatusWidgetMarkupShouldContainPassedInValues()
    {
        var title = "Circle CI Build Status Title";
        var moreInfo = "More Info";
        var updatedAtMessage = "Updated At Message";
        var buildId = "Build Id";
        var avatarUrl = "Avatar Url";
        var committerName = "Committer Name";
        var commitBody = "CommitBody";
        var state = "State";
        var time = "Time";

        var cut = Render<CircleCIBuildStatusWidget>(parameters => parameters
            .Add(p => p.Title, title)
            .Add(p => p.MoreInfo, moreInfo)
            .Add(p => p.UpdatedAtMessage, updatedAtMessage)
            .Add(p => p.BuildId, buildId)
            .Add(p => p.AvatarUrl, avatarUrl)
            .Add(p => p.CommitterName, committerName)
            .Add(p => p.CommitBody, commitBody)
            .Add(p => p.State, state)
            .Add(p => p.Time, time)
        );
        
        // var widget = @"
        //     <div class=""widget-circle-ci"" style=""background-color:@BackgroundColor"">
        //         <h1 class=""title"">@Title</h1>
        //
        //         <img class=""background"" src=""logo-circle-ci.png"">
        //
        //         <span class=""label small"">@BuildId</span>
        //         <div class=""commit-info"">
        //             <img src=""@AvatarUrl"" />
        //             <span class=""label committer-name"">@CommitterName</span>
        //             <span class=""label small commit-body"">@CommitBody</span>
        //             <div class=""clearfix""></div>
        //         </div>
        //
        //         <h2 class=""state"">@State</h2>
        //         <span class=""label small"">@Time</span>
        //
        //         <p class=""more-info"">@MoreInfo</p>
        //         <p class=""updated-at"">@UpdatedAtMessage</p>
        //     </div>";

        var expectedTitleMarkup = $"<h1 class=\"title\">{title}</h1>";
        cut.FindAll("h1")[0].MarkupMatches(expectedTitleMarkup);
        
        var expectedBuildIdMarkup = $"<span class=\"label small\">{buildId}</span>";
        cut.FindAll("span")[0].MarkupMatches(expectedBuildIdMarkup);

        var expectedAvatarUrlMarkup = $"<img src=\"{avatarUrl}\" />";
        cut.FindAll("img")[1].MarkupMatches(expectedAvatarUrlMarkup);
        
        var expectedCommitterNameMarkup = $"<span class=\"label committer-name\">{committerName}</span>";
        cut.FindAll("span")[1].MarkupMatches(expectedCommitterNameMarkup);
        
        var expectedCommitBodyMarkup = $"<span class=\"label small commit-body\">{commitBody}</span>";
        cut.FindAll("span")[2].MarkupMatches(expectedCommitBodyMarkup);
        
        var expectedStateMarkup = $"<h2 class=\"state\">{state}</h1>";
        cut.FindAll("h2")[0].MarkupMatches(expectedStateMarkup);
        
        var expectedTimeMarkup = $"<span class=\"label small\">{time}</span>";
        cut.FindAll("span")[3].MarkupMatches(expectedTimeMarkup);
        
        var expectedMoreInfoMarkup = $"<p class=\"more-info\">{moreInfo}</p>";
        cut.FindAll("p")[0].MarkupMatches(expectedMoreInfoMarkup);

        var expectedUpdatedAtMessageMarkup = $"<p class=\"updated-at\">{updatedAtMessage}</p>";
        cut.FindAll("p")[1].MarkupMatches(expectedUpdatedAtMessageMarkup);
    }

    [Fact]
    public void CircleCIBuildStatusWidgetShouldContainPassedInValues()
    {
        var title = "Circle CI Build Status Title";
        var moreInfo = "More Info";
        var updatedAtMessage = "Updated At Message";
        var buildId = "Build Id";
        var avatarUrl = "Avatar Url";
        var committerName = "Committer Name";
        var commitBody = "CommitBody";
        var state = "State";
        var time = "Time";

        var cut = Render<CircleCIBuildStatusWidget>(parameters => parameters
            .Add(p => p.Title, title)
            .Add(p => p.MoreInfo, moreInfo)
            .Add(p => p.UpdatedAtMessage, updatedAtMessage)
            .Add(p => p.BuildId, buildId)
            .Add(p => p.AvatarUrl, avatarUrl)
            .Add(p => p.CommitterName, committerName)
            .Add(p => p.CommitBody, commitBody)
            .Add(p => p.State, state)
            .Add(p => p.Time, time)
        );

        var circleCIBuildStatusWidget = cut.Instance;
        Assert.Equal(circleCIBuildStatusWidget.Title, title);
        Assert.Equal(circleCIBuildStatusWidget.MoreInfo, moreInfo);
        Assert.Equal(circleCIBuildStatusWidget.UpdatedAtMessage, updatedAtMessage);
        Assert.Equal(circleCIBuildStatusWidget.BuildId, buildId);
        Assert.Equal(circleCIBuildStatusWidget.AvatarUrl, avatarUrl);
        Assert.Equal(circleCIBuildStatusWidget.CommitterName, committerName);
        Assert.Equal(circleCIBuildStatusWidget.CommitBody, commitBody);
        Assert.Equal(circleCIBuildStatusWidget.State, state);
        Assert.Equal(circleCIBuildStatusWidget.Time, time);
    }
}