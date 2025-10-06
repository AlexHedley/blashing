using Microsoft.AspNetCore.Components;

namespace Blashing.Core.Components.Comments;

public partial class CommentsWidget : BaseWidget
{
    [Parameter] public string? Title { get; set; }

    [Parameter] public string? Quote { get; set; }

    [Parameter] public string? MoreInfo { get; set; }

    protected override void OnParametersSet()
    {
        BackgroundColor ??= "#eb9c3c";
    }
}