using Microsoft.AspNetCore.Components;

namespace Blashing.Core.Components.Image;

public partial class ImageWidget : BaseWidget
{
    [Parameter]
    public string? Src { get; set; }
    
    [Parameter]
    public string? Width { get; set; }
    
    protected override void OnParametersSet()
    {
        BackgroundColor ??= "transparent";
    }
}