using Microsoft.AspNetCore.Components;

namespace Blashing.Core.Components.IFrame;

public partial class IFrameWidget : BaseWidget
{
    [Parameter]
    public string? Url { get; set; }
    
    protected override void OnParametersSet()
    {
        BackgroundColor ??= "transparent";
    }
}