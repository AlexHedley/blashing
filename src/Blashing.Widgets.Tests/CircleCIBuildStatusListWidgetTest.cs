using Bunit;
using Xunit;

using Blashing.Widgets.CircleCIList;

namespace Blashing.Widgets.Tests;

public class CircleCIBuildStatusListWidgetTest : TestContext
{
    [Fact]
    public void CircleCIBuildStatusListWidgetMarkupShouldContainPassedInValues()
    {
    var title = "Circle CI List Title";
    var items = new CircleCIDetails
    {
        Repo = "Repo Name",
        Branch = "branch",
        AvatarUrl = "https://gravatar.com/avatar/3184635da54b04bd362f09bad9aced67?s=200&d=mp",
        BackgroundColor = "#a31f1f"
    };

    var cut = RenderComponent<CircleCIBuildStatusListWidget>(parameters => parameters
        .Add(p => p.Title, title)
        .Add(p => p.Items, items)
    );
    
//     var widget = @"
//         <h1 class=""title"">@Title</h1>
//
//         <img class=""background"" src=""_content/Blashing.Widgets/images/logo-circle-ci.png"">
//
//         <ul class=""items list-nostyle"">
//             @foreach (var item in Items)
//             {
//             <li class=""item"" style=""background-color:@item.BackgroundColor"">
//                 <span class=""label repo"" data-bind=""item.repo"">@item.Repo</span>
//                 <span class=""label branch"" data-bind=""item.branch"">@item.Branch</span>
//                 <img class=""avatar"" src=""@item.AvatarUrl"" />
//                 <div class=""clearfix""/>
//             </li>
//             }
//         </ul>";
    //
    //     var expectedTitleMarkup = $"<h1 class=\"title\">{title}</h1>";
    //     cut.FindAll("h1")[0].MarkupMatches(expectedTitleMarkup);
    //     
    //     var expectedBuildIdMarkup = $"<span class=\"label small\">{buildId}</span>";
    //     cut.FindAll("span")[0].MarkupMatches(expectedBuildIdMarkup);
    //
    //     var expectedAvatarUrlMarkup = $"<img src=\"{avatarUrl}\" />";
    //     cut.FindAll("img")[1].MarkupMatches(expectedAvatarUrlMarkup);
    //     
    //     var expectedCommitterNameMarkup = $"<span class=\"label committer-name\">{committerName}</span>";
    //     cut.FindAll("span")[1].MarkupMatches(expectedCommitterNameMarkup);
    //     
    //     var expectedCommitBodyMarkup = $"<span class=\"label small commit-body\">{commitBody}</span>";
    //     cut.FindAll("span")[2].MarkupMatches(expectedCommitBodyMarkup);
    //     
    //     var expectedStateMarkup = $"<h2 class=\"state\">{state}</h1>";
    //     cut.FindAll("h2")[0].MarkupMatches(expectedStateMarkup);
    //     
    //     var expectedTimeMarkup = $"<span class=\"label small\">{time}</span>";
    //     cut.FindAll("span")[3].MarkupMatches(expectedTimeMarkup);
    //     
    //     var expectedMoreInfoMarkup = $"<p class=\"more-info\">{moreInfo}</p>";
    //     cut.FindAll("p")[0].MarkupMatches(expectedMoreInfoMarkup);
    //
    //     var expectedUpdatedAtMessageMarkup = $"<p class=\"updated-at\">{updatedAtMessage}</p>";
    //     cut.FindAll("p")[1].MarkupMatches(expectedUpdatedAtMessageMarkup);
    // }

    // [Fact]
    // public void CircleCIBuildStatusListWidgetShouldContainPassedInValues()
    // {
    //     var title = "Circle CI Build Status Title";
    //     var moreInfo = "More Info";
    //     var updatedAtMessage = "Updated At Message";
    //     var buildId = "Build Id";
    //     var avatarUrl = "Avatar Url";
    //     var committerName = "Committer Name";
    //     var commitBody = "CommitBody";
    //     var state = "State";
    //     var time = "Time";
    //
    //     var cut = RenderComponent<CircleCIBuildStatusWidget>(parameters => parameters
    //         .Add(p => p.Title, title)
    //         .Add(p => p.MoreInfo, moreInfo)
    //         .Add(p => p.UpdatedAtMessage, updatedAtMessage)
    //         .Add(p => p.BuildId, buildId)
    //         .Add(p => p.AvatarUrl, avatarUrl)
    //         .Add(p => p.CommitterName, committerName)
    //         .Add(p => p.CommitBody, commitBody)
    //         .Add(p => p.State, state)
    //         .Add(p => p.Time, time)
    //     );
    //
    //     var circleCIBuildStatusWidget = cut.Instance;
    //     Assert.Equal(circleCIBuildStatusWidget.Title, title);
    //     Assert.Equal(circleCIBuildStatusWidget.MoreInfo, moreInfo);
    //     Assert.Equal(circleCIBuildStatusWidget.UpdatedAtMessage, updatedAtMessage);
    //     Assert.Equal(circleCIBuildStatusWidget.BuildId, buildId);
    //     Assert.Equal(circleCIBuildStatusWidget.AvatarUrl, avatarUrl);
    //     Assert.Equal(circleCIBuildStatusWidget.CommitterName, committerName);
    //     Assert.Equal(circleCIBuildStatusWidget.CommitBody, commitBody);
    //     Assert.Equal(circleCIBuildStatusWidget.State, state);
    //     Assert.Equal(circleCIBuildStatusWidget.Time, time);
    // }
}