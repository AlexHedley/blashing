using Microsoft.AspNetCore.Components;

namespace Blashing.Core.Components.Meter;

public partial class MeterWidget : BaseWidget
{
    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public string? MoreInfo { get; set; }

    [Parameter]
    public string? UpdatedAtMessage { get; set; }
    
    [Parameter]
    public long AngleOffset { get; set; }
    
    [Parameter]
    public long AngleArc { get; set; }
    
    [Parameter]
    public long Height { get; set; }
    
    [Parameter]
    public long Width { get; set; }
    
    [Parameter]
    public bool ReadOnly { get; set; }
    
    [Parameter]
    public long Value { get; set; }
    
    [Parameter]
    public long Min { get; set; }
    
    [Parameter]
    public long Max { get; set; }
    
    protected override void OnParametersSet()
    {
        BackgroundColor ??= "#9c4274";
    }
}