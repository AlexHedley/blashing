using Blashing.Core.Components;
using Microsoft.AspNetCore.Components;

namespace Blashing.Widgets.ServerStatusSquares;

public partial class ServerStatusSquareWidget : BaseWidget
{
    [Parameter]
    public string? Title { get; set; }
    
    [Parameter]
    public string? UpdatedAtMessage { get; set; }

    [Parameter]
    public bool? Result { get; set; }

    protected override void OnParametersSet()
    {
        if (Result.HasValue && BackgroundColor == null)
        {
            BackgroundColor = Result.Value ? "#96BF48" : "#BF4848";
        }
        BackgroundColor ??= "#12b0c5";
    }
}