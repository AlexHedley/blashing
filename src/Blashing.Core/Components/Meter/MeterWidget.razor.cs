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
    public long AngleOffset { get; set; } = -125;

    [Parameter]
    public long AngleArc { get; set; } = 250;

    [Parameter]
    public long Height { get; set; } = 200;

    [Parameter]
    public long Width { get; set; } = 200;

    [Parameter]
    public bool ReadOnly { get; set; } = true;

    [Parameter]
    public long Value { get; set; }

    [Parameter]
    public long Min { get; set; }

    [Parameter]
    public long Max { get; set; } = 100;

    [Parameter]
    public bool DisplayInput { get; set; } = true;

    [Parameter]
    public string? Prefix { get; set; }

    [Parameter]
    public string? Suffix { get; set; }

    protected override void OnParametersSet()
    {
        BackgroundColor ??= "#9c4274";
    }

    internal double Radius => Math.Min(Width, Height) / 2.0 * 0.8;

    internal string CenterX =>
        (Width / 2.0).ToString("F2", System.Globalization.CultureInfo.InvariantCulture);

    internal string CenterY =>
        (Height / 2.0).ToString("F2", System.Globalization.CultureInfo.InvariantCulture);

    internal string StrokeWidth =>
        (Math.Min(Width, Height) * 0.1).ToString("F2", System.Globalization.CultureInfo.InvariantCulture);

    internal string FontSize =>
        (Math.Min(Width, Height) * 0.2).ToString("F2", System.Globalization.CultureInfo.InvariantCulture);

    internal string GetBackgroundArcPath()
    {
        double cx = Width / 2.0;
        double cy = Height / 2.0;
        return GetArcPath(cx, cy, Radius, AngleOffset, AngleOffset + AngleArc);
    }

    internal string GetValueArcPath()
    {
        double cx = Width / 2.0;
        double cy = Height / 2.0;
        double ratio = Max > Min
            ? Math.Clamp((double)(Value - Min) / (Max - Min), 0.0, 1.0)
            : 0.0;
        double valueAngle = AngleOffset + ratio * AngleArc;
        return GetArcPath(cx, cy, Radius, AngleOffset, valueAngle);
    }

    internal MarkupString GetCenterTextMarkup()
    {
        string encodedPrefix = System.Net.WebUtility.HtmlEncode(Prefix ?? string.Empty);
        string encodedSuffix = System.Net.WebUtility.HtmlEncode(Suffix ?? string.Empty);
        return (MarkupString)FormattableString.Invariant(
            $"<text class=\"meter-text\" x=\"{CenterX}\" y=\"{CenterY}\" text-anchor=\"middle\" dominant-baseline=\"middle\" font-size=\"{FontSize}\">{encodedPrefix}{Value}{encodedSuffix}</text>");
    }

    internal static string GetArcPath(double cx, double cy, double r, double startDeg, double endDeg)
    {
        double startRad = (startDeg - 90.0) * Math.PI / 180.0;
        double endRad = (endDeg - 90.0) * Math.PI / 180.0;

        double x1 = cx + r * Math.Cos(startRad);
        double y1 = cy + r * Math.Sin(startRad);
        double x2 = cx + r * Math.Cos(endRad);
        double y2 = cy + r * Math.Sin(endRad);

        int largeArcFlag = Math.Abs(endDeg - startDeg) > 180 ? 1 : 0;

        return FormattableString.Invariant(
            $"M {x1:F2},{y1:F2} A {r:F2},{r:F2} 0 {largeArcFlag} 1 {x2:F2},{y2:F2}");
    }
}