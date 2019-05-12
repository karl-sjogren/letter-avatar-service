using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using LetterAvatarService.Contracts;
using Microsoft.Extensions.Logging;
using Shorthand.ImageSharp.WebP;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;
using SixLabors.Shapes;

namespace LetterAvatarService.Services {
    public class AvatarService : IAvatarService {
        private readonly IPaletteService _paletteService;
        private readonly IFontService _fontService;
        private readonly IBlobCacheService _cacheService;
        private readonly IStatisticsService _statisticsService;
        private readonly ILogger<AvatarService> _log;

        public AvatarService(IPaletteService paletteService,
                             IFontService fontService,
                             IBlobCacheService cacheService,
                             IStatisticsService statisticsService,
                             ILogger<AvatarService> log) {
            _paletteService = paletteService;
            _fontService = fontService;
            _cacheService = cacheService;
            _statisticsService = statisticsService;
            _log = log;
        }

        public async Task<byte[]> GenerateAvatar(string name, AvatarFormat format, Int32 squareSize, Int32 fontSize) {
            name = CleanName(name);
            if (string.IsNullOrWhiteSpace(name))
                return null;

            var text = GetText(name);
            if (string.IsNullOrWhiteSpace(text))
                return null;

            await _statisticsService.TrackHit(name, squareSize);

            var cacheKey = GetCacheKey(name, format, squareSize, fontSize);

            var cachedBlob = await _cacheService.GetBlob(cacheKey);
            if (cachedBlob != null)
                return cachedBlob;

            var backgroundColor = _paletteService.GetColorForString(name);

            var fontFamily = _fontService.GetFont();
            var font = fontFamily.CreateFont(fontSize, FontStyle.Regular);

            var glyphs = TextBuilder.GenerateGlyphs(text, new RendererOptions(font, 72));
            glyphs = glyphs.Translate(-glyphs.Bounds.Location);

            var textPosition = new PointF(squareSize / 2f - glyphs.Bounds.Width / 2, squareSize / 2f - glyphs.Bounds.Height / 2f);
            glyphs = glyphs.Translate(textPosition);

            byte[] buffer;
            switch(format) {
                case AvatarFormat.Png:
                    buffer = GeneratePNG(squareSize, Rgba32.White, backgroundColor, glyphs);
                    break;
                case AvatarFormat.WebP:
                    buffer = GenerateWebP(squareSize, Rgba32.White, backgroundColor, glyphs);
                    break;
                case AvatarFormat.Svg:
                    buffer = GenerateSVG(squareSize, Rgba32.White, backgroundColor, glyphs);
                    break;
                default:
                    throw new InvalidOperationException("Invalid AvatarFormat specified.");
            }

            await _cacheService.StoreBlob(cacheKey, buffer);
            return buffer;
        }

        private static byte[] GeneratePNG(int squareSize, Rgba32 foregroundColor, Rgba32 backgroundColor, IPathCollection glyphs) {
            using (var img = new Image<Rgba32>(squareSize, squareSize)) {
                var graphicsOptions = new GraphicsOptions(true);

                img.Mutate(ctx => ctx
                    .Fill(backgroundColor)
                    .Fill(graphicsOptions, foregroundColor, glyphs));

                using (var ms = new MemoryStream()) {
                    img.SaveAsPng(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    return ms.ToArray();
                }
            }
        }

        private static byte[] GenerateWebP(int squareSize, Rgba32 foregroundColor, Rgba32 backgroundColor, IPathCollection glyphs) {
            using (var img = new Image<Rgba32>(squareSize, squareSize)) {
                var graphicsOptions = new GraphicsOptions(true);

                img.Mutate(ctx => ctx
                    .Fill(backgroundColor)
                    .Fill(graphicsOptions, foregroundColor, glyphs));

                using (var ms = new MemoryStream()) {
                    img.Save(ms, new WebPEncoder());
                    ms.Seek(0, SeekOrigin.Begin);
                    return ms.ToArray();
                }
            }
        }

        private static byte[] GenerateSVG(int squareSize, Rgba32 foregroundColor, Rgba32 backgroundColor, IPathCollection glyphs) {
            XNamespace ns = "http://www.w3.org/2000/svg";
            var root = new XElement(ns + "svg");
            root.SetAttributeValue("width", squareSize);
            root.SetAttributeValue("height", squareSize);

            var background = new XElement(ns + "rect");
            background.SetAttributeValue("width", "100%");
            background.SetAttributeValue("height", "100%");
            background.SetAttributeValue("fill", "#" + backgroundColor.ToHex());
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

            using (var ms = new MemoryStream()) {
                root.SaveAsync(ms, SaveOptions.DisableFormatting, CancellationToken.None);
                ms.Seek(0, SeekOrigin.Begin);
                return ms.ToArray();
            }
        }

        private static XElement RenderPath(Polygon polygon, Rgba32 color) {
            XNamespace ns = "http://www.w3.org/2000/svg";
            var sb = new StringBuilder();
            var first = true;
            foreach (var segment in polygon.LineSegments) {
                if (first) {
                    first = false;
                    sb.Append($"M{segment.EndPoint.X} {segment.EndPoint.Y}");
                    continue;
                }

                if (segment is LinearLineSegment lineSegment) {
                    sb.Append($"L {lineSegment.EndPoint.X} {lineSegment.EndPoint.Y}");
                } else if (segment is CubicBezierLineSegment bezierSegment) {
                    var fieldInfo = typeof(CubicBezierLineSegment).GetField("controlPoints", BindingFlags.NonPublic | BindingFlags.Instance);
                    var points = (PointF[])fieldInfo.GetValue(bezierSegment);

                    var p1 = points[1];
                    var p2 = points[2];
                    var p3 = points[3];
                    sb.Append($"C {p1.X} {p1.Y} {p2.X} {p2.Y} {p3.X} {p3.Y}");
                }
            }

            var path = new XElement(ns + "path");
            path.SetAttributeValue("stroke", "#" + color.ToHex());
            path.SetAttributeValue("fill", "#" + color.ToHex());
            path.SetAttributeValue("d", sb.ToString());
            return path;
        }

        private string GetCacheKey(string name, AvatarFormat format, Int32 size, Int32 fontSize) {
            return $"{name}|{format}|{size}|{fontSize}";
        }

        private string CleanName(string name) {
            if(string.IsNullOrWhiteSpace(name))
                return null;

            name = name.ToUpperInvariant();
            name = name.Trim(',', '!', ';', '"', '\'', '#', '%', '&', '(', ')', '=', '?');
            name = Regex.Replace(name, @"\p{Cs}", string.Empty); // Remove emojis
            name = name.Trim();

            var invalidChars = System.IO.Path.GetInvalidFileNameChars();
            foreach(var invalidChar in invalidChars)
                name = name.Replace(invalidChar, '-');

            while(name.Contains("--"))
                name = name.Replace("--", "-");

            return name;
        }

        private string GetText(string name) {
            name = CleanName(name);
            if(string.IsNullOrWhiteSpace(name))
                return null;

            var split = name.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var first = split.First().First();
            var last = '-';
            if(split.Length > 1)
                last = split.Last().First();

            var text = (first + string.Empty + (last == '-' ? string.Empty : last.ToString()));

            return text;
        }
    }
}
