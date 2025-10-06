using Microsoft.AspNetCore.Components;

namespace Blashing.Core.Components.Number;

public partial class NumberWidget : BaseWidget
{
    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public string? Current { get; set; }
    
    [Parameter]
    public string? Difference { get; set; }

    [Parameter]
    public string? MoreInfo { get; set; }

    [Parameter]
    public string? UpdatedAtMessage { get; set; }
    
    protected override void OnParametersSet()
    {
        BackgroundColor ??= "#47bbb3";
    }
}