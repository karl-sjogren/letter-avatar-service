using System.Globalization;
using System.Text;
using System.Xml.Linq;
using LetterAvatars.Generator.Extensions;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.PixelFormats;

namespace LetterAvatars.Generator;

public class SvgAvatarGenerator : ImageAvatarGeneratorBase {
    public SvgAvatarGenerator(IFontProvider fontProvider)
        : base(fontProvider) { }

    public override string Extension => "svg";

    public override string MimeType => "image/svg+xml";

    protected override async Task<byte[]> RenderGlyphsAsync(IPathCollection glyphs, Int32 squareSize, Rgba32 foregroundColor, Rgba32 backgroundColor, CancellationToken cancellationToken) {
        XNamespace ns = "http://www.w3.org/2000/svg";
        var root = new XElement(ns + "svg");
        root.SetAttributeValue("width", squareSize);
        root.SetAttributeValue("height", squareSize);

        var background = new XElement(ns + "rect");
        background.SetAttributeValue("width", "100%");
        background.SetAttributeValue("height", "100%");
        background.SetAttributeValue("fill", "#" + backgroundColor.ToRgbHex());
        root.Add(background);

        foreach(var glyph in glyphs) {
            if(glyph is Polygon polygon) {
                var path = RenderPath(polygon, foregroundColor);
                root.Add(path);
            } else if(glyph is ComplexPolygon complexPolygon) {
                var first = true;
                foreach(var polygonPart in complexPolygon.Paths.Cast<Polygon>()) {
                    var path = RenderPath(polygonPart, first ? foregroundColor : backgroundColor);
                    root.Add(path);
                    first = false;
                }
            }
        }

        await using var ms = new MemoryStream();
        await root.SaveAsync(ms, SaveOptions.DisableFormatting, cancellationToken);
        ms.Seek(0, SeekOrigin.Begin);
        return ms.ToArray();
    }

    private static XElement RenderPath(Polygon polygon, Rgba32 color) {
        XNamespace ns = "http://www.w3.org/2000/svg";
        var sb = new StringBuilder();
        var first = true;
        foreach(var segment in polygon.LineSegments) {
            if(first) {
                first = false;
                sb.Append($"M{segment.EndPoint.X.ToString(CultureInfo.InvariantCulture)} {segment.EndPoint.Y.ToString(CultureInfo.InvariantCulture)}");
                continue;
            }

            /*
            if(segment is LinearLineSegment lineSegment) {
                sb.Append($"L {lineSegment.EndPoint.X.ToString(CultureInfo.InvariantCulture)} {lineSegment.EndPoint.Y.ToString(CultureInfo.InvariantCulture)}");
            } else if(segment is CubicBezierLineSegment bezierSegment) {
                var fieldInfo = typeof(CubicBezierLineSegment).GetField("controlPoints", BindingFlags.NonPublic | BindingFlags.Instance);
                var points = (PointF[])fieldInfo.GetValue(bezierSegment);

                var p1 = points[1];
                var p2 = points[2];
                var p3 = points[3];
                sb.Append($"C {p1.X.ToString(CultureInfo.InvariantCulture)} {p1.Y.ToString(CultureInfo.InvariantCulture)} {p2.X.ToString(CultureInfo.InvariantCulture)} {p2.Y.ToString(CultureInfo.InvariantCulture)} {p3.X.ToString(CultureInfo.InvariantCulture)} {p3.Y.ToString(CultureInfo.InvariantCulture)}");
            }
*/
        }

        var path = new XElement(ns + "path");
        path.SetAttributeValue("stroke", "#" + color.ToRgbHex());
        path.SetAttributeValue("fill", "#" + color.ToRgbHex());
        path.SetAttributeValue("d", sb.ToString());
        return path;
    }
}
