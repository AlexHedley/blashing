using Microsoft.AspNetCore.Components;

namespace Blashing.Core.Components.Graph;

public partial class GraphWidget : BaseWidget
{
    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public string? MoreInfo { get; set; }
    
    protected override void OnParametersSet()
    {
        BackgroundColor ??= "#ff9618";
    }
}