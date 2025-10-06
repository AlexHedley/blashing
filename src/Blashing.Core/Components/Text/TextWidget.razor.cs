using Microsoft.AspNetCore.Components;

namespace Blashing.Core.Components.Text;

public partial class TextWidget: BaseWidget
{
    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public string? Text { get; set; }

    [Parameter]
    public string? MoreInfo { get; set; }

    [Parameter]
    public string? UpdatedAtMessage { get; set; }
    
    // protected override void OnInitialized()
    // {
    //     BackgroundColor = "#ec663c";
    // }
    
    protected override void OnParametersSet()
    {
        BackgroundColor ??= "#ec663c";
    }
}