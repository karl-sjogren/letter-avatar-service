using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LetterAvatarService.Contracts;
using Microsoft.Extensions.Logging;
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

        public async Task<byte[]> GenerateAvatar(string name, Int32 squareSize, Int32 fontSize) {
            name = CleanName(name);
            if(string.IsNullOrWhiteSpace(name))
                return null;
            
            var text = GetText(name);
            if(string.IsNullOrWhiteSpace(text))
                return null;

            await _statisticsService.TrackHit(name, squareSize);

            var cacheKey = GetCacheKey(name, squareSize, fontSize);

            var cachedBlob = await _cacheService.GetBlob(cacheKey);
            if(cachedBlob != null)
                return cachedBlob;

            var backgroundColor = _paletteService.GetColorForString(name);

            var fontFamily = _fontService.GetFont();
            var font = fontFamily.CreateFont(fontSize, FontStyle.Regular);

            var glyphs = TextBuilder.GenerateGlyphs(text, new RendererOptions(font, 72));
            glyphs = glyphs.Translate(-glyphs.Bounds.Location);

            var textPosition = new PointF(squareSize / 2f - glyphs.Bounds.Width / 2, squareSize / 2f - glyphs.Bounds.Height / 2f);
            glyphs = glyphs.Translate(textPosition);

            byte[] buffer;
            using(var img = new Image<Rgba32>(squareSize, squareSize)) {
                var graphicsOptions = new GraphicsOptions(true);

                img.Mutate(ctx => ctx
                    .Fill(backgroundColor)
                    .Fill(graphicsOptions, Rgba32.White, glyphs));

                using(var ms = new MemoryStream()) {
                    img.SaveAsPng(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    buffer = ms.ToArray();
                }
            }

            await _cacheService.StoreBlob(cacheKey, buffer);
            return buffer;
        }

        private string GetCacheKey(string name, Int32 size, Int32 fontSize) {
            return $"{name}|{size}|{fontSize}";
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
