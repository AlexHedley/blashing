using Microsoft.AspNetCore.Components;

namespace Blashing.Core.Components.List;

public partial class ListWidget : BaseWidget
{
    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public string? MoreInfo { get; set; }

    [Parameter]
    public string? UpdatedAtMessage { get; set; }

    [Parameter]
    public List<(string label, string value)>? Items { get; set; } = new();

    [Parameter] public bool Ordered { get; set; }
    
    protected override void OnParametersSet()
    {
        BackgroundColor ??= "#12b0c5";
    }
}