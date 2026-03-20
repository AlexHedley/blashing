using System.Text;
using Microsoft.AspNetCore.Components;

namespace Blashing.Core.Components.Graph;

public partial class GraphWidget : BaseWidget
{
    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public string? Current { get; set; }

    [Parameter]
    public string? Prefix { get; set; }

    [Parameter]
    public string? Suffix { get; set; }

    [Parameter]
    public string? MoreInfo { get; set; }

    [Parameter]
    public IEnumerable<double> Points { get; set; } = [];

    protected override void OnParametersSet()
    {
        // #dc5945 matches the $background-color in GraphWidget.razor.scss
        BackgroundColor ??= "#dc5945";
    }

    private const int SvgViewBoxWidth = 300;
    private const int SvgViewBoxHeight = 200;
    private const double SvgTopPadding = 10;

    public string GenerateSvgPath()
    {
        var pointsList = Points?.ToList();
        if (pointsList == null || pointsList.Count < 2)
            return string.Empty;

        var min = pointsList.Min();
        var max = pointsList.Max();
        var range = max - min;
        if (range == 0) range = 1;

        var n = pointsList.Count;
        var coords = pointsList.Select((y, i) => (
            x: (double)i / (n - 1) * SvgViewBoxWidth,
            y: (SvgViewBoxHeight - SvgTopPadding) - ((y - min) / range) * (SvgViewBoxHeight - SvgTopPadding)
        )).ToList();

        var sb = new StringBuilder();
        sb.Append(FormattableString.Invariant($"M {coords[0].x:F1} {coords[0].y:F1}"));

        for (int i = 0; i < coords.Count - 1; i++)
        {
            double midX = (coords[i].x + coords[i + 1].x) / 2;
            sb.Append(FormattableString.Invariant(
                $" C {midX:F1} {coords[i].y:F1}, {midX:F1} {coords[i + 1].y:F1}, {coords[i + 1].x:F1} {coords[i + 1].y:F1}"));
        }

        sb.Append(FormattableString.Invariant($" L {coords[^1].x:F1} {SvgViewBoxHeight}.0"));
        sb.Append(FormattableString.Invariant($" L {coords[0].x:F1} {SvgViewBoxHeight}.0"));
        sb.Append(" Z");

        return sb.ToString();
    }
}