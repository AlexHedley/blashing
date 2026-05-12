using Blashing.Core.Components;
using Microsoft.AspNetCore.Components;

namespace Blashing.Widgets.CircleCIList;

public partial class CircleCIBuildStatusListWidget //: BaseWidget
{
    [Parameter]
    public string? Title { get; set; }

    [Parameter] public List<CircleCIDetails> Items { get; set; } = new();
    
    // protected override void OnParametersSet()
    // {
    //     BackgroundColor ??= "#8fb347";
    // }
}

public record CircleCIDetails
{
    public required string Repo { get; init; }
    public required string Branch { get; init; }
    public required string AvatarUrl { get; init; }
    
    public string? BackgroundColor { get; init; }
}