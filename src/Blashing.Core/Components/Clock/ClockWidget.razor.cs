using Microsoft.AspNetCore.Components;

namespace Blashing.Core.Components.Clock;

public partial class ClockWidget : BaseWidget
{
    [Parameter]
    public string? Date { get; set; }

    [Parameter]
    public string? Time { get; set; }
    
    protected override void OnParametersSet()
    {
        BackgroundColor ??= "#dc5945";
    }
}