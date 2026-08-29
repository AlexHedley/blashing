using Blashing.Widgets.CircleCIList;

namespace Blashing.Shared.Pages;

public partial class AdditionalWidgets
{
    // Circle CI List
    List<CircleCIDetails> Items { get; set; } =
    [
        new CircleCIDetails
        {
            Repo = "gocardless", 
            Branch = "dev",
            AvatarUrl = "https://gravatar.com/avatar/3184635da54b04bd362f09bad9aced67?s=200&d=robohash",
            BackgroundColor = "#a31f1f"
        },
        new CircleCIDetails
        {
            Repo = "dashboard", 
            Branch = "main",
            AvatarUrl = "https://gravatar.com/avatar/3184635da54b04bd362f09bad9aced67?s=200&d=retro",
            BackgroundColor = "#47bbb3"
        },
        new CircleCIDetails
        {
            Repo = "payments-client", 
            Branch = "feature",
            AvatarUrl = "https://gravatar.com/avatar/3184635da54b04bd362f09bad9aced67?s=200&d=wavatar",
            BackgroundColor = "#8fb347"
        }
    ];
}