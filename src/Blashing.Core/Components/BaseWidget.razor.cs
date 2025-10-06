using Microsoft.AspNetCore.Components;

namespace Blashing.Core.Components;

public partial class BaseWidget : ComponentBase
{
    [Parameter]
    public string? BackgroundColor { get; set; }
}