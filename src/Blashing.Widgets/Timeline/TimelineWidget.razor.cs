using Blashing.Core.Components;
using Microsoft.AspNetCore.Components;

namespace Blashing.Widgets.Timeline;

public partial class TimelineWidget : BaseWidget
{
    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public string? MoreInfo { get; set; }

    [Parameter]
    public string? UpdatedAtMessage { get; set; }

    [Parameter]
    public List<TimelineItem>? Items { get; set; } = new();

    protected override void OnParametersSet()
    {
        BackgroundColor ??= "#4b4b4b";
    }
}
