using Blashing.Core.Components;
using Microsoft.AspNetCore.Components;

namespace Blashing.Widgets.ServerStatusSquares;

public partial class ServerStatusSquareWidget : BaseWidget
{
    [Parameter]
    public string? Title { get; set; }
    
    [Parameter]
    public string? UpdatedAtMessage { get; set; }

    protected override void OnParametersSet()
    {
        BackgroundColor ??= "#12b0c5";
    }
}