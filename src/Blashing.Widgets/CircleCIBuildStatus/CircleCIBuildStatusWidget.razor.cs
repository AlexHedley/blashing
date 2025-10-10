using Blashing.Core.Components;
using Microsoft.AspNetCore.Components;

namespace Blashing.Widgets.CircleCIBuildStatus;

public partial class CircleCIBuildStatusWidget : BaseWidget
{
    [Parameter]
    public string? Title { get; set; }
    
    [Parameter]
    public string? MoreInfo { get; set; }
    
    [Parameter]
    public string? UpdatedAtMessage { get; set; }
    
    [Parameter]
    public string? BuildId { get; set; }
    
    [Parameter]
    public string? AvatarUrl { get; set; }
    
    [Parameter]
    public string? CommitterName { get; set; }
    
    [Parameter]
    public string? CommitBody { get; set; }
    
    [Parameter]
    public string? State { get; set; }
    
    [Parameter]
    public string? Time { get; set; }
    
    protected override void OnParametersSet()
    {
        BackgroundColor ??= "#8fb347";
    }
}