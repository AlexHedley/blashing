using Blashing.Core.Components;
using Microsoft.AspNetCore.Components;

namespace Blashing.Widgets.CircleCIBuildStatus;

public enum CircleCIWidgetClass
{
    Failed,
    Pending,
    Passed
}

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

    [Parameter]
    public CircleCIWidgetClass? WidgetClass { get; set; }
    
    protected override void OnParametersSet()
    {
        if (WidgetClass.HasValue && BackgroundColor == null)
        {
            BackgroundColor = WidgetClass.Value switch
            {
                CircleCIWidgetClass.Failed => "#a31f1f",
                CircleCIWidgetClass.Pending => "#47bbb3",
                CircleCIWidgetClass.Passed => "#8fb347",
                _ => null
            };
        }
        BackgroundColor ??= "#8fb347";
    }
}