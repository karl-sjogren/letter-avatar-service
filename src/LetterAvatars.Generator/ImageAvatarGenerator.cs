using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using SixLabors.Fonts;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.Primitives;
using SixLabors.Shapes;

namespace LetterAvatars.Generator {
    public abstract class ImageAvatarGeneratorBase : IAvatarGenerator {
        private readonly IFontProvider _fontProvider;
        private readonly IPaletteProvider _paletteProvider;

        protected ImageAvatarGeneratorBase(IFontProvider fontProvider, IPaletteProvider paletteProvider) {
            _fontProvider = fontProvider;
            _paletteProvider = paletteProvider;
        }

        public abstract string MimeType { get; }

        protected abstract Task<byte[]> RenderGlyphs(IPathCollection glyphs, Int32 squareSize, Rgba32 foregroundColor, Rgba32 backgroundColor, CancellationToken cancellationToken = default(CancellationToken));

        public async Task<byte[]> GenerateAvatar(string name, Int32 squareSize, Rgba32 foregroundColor, Rgba32 backgroundColor, CancellationToken cancellationToken = default(CancellationToken)) {
            var text = GetText(name);
            if(string.IsNullOrWhiteSpace(text))
                return null;

            var fontFamily = await _fontProvider.GetFont(cancellationToken);
            var fontSize = squareSize * .55f;
            var font = fontFamily.CreateFont(fontSize, FontStyle.Regular);

            var glyphs = TextBuilder.GenerateGlyphs(text, new RendererOptions(font, 72));
            glyphs = glyphs.Translate(-glyphs.Bounds.Location);

            var textPosition = new PointF(squareSize / 2f - glyphs.Bounds.Width / 2, squareSize / 2f - glyphs.Bounds.Height / 2f);
            glyphs = glyphs.Translate(textPosition);

            return await RenderGlyphs(glyphs, squareSize, foregroundColor, backgroundColor, cancellationToken);
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
            var first = split[0][0];
            var last = '-';
            if(split.Length > 1)
                last = split[split.Length - 1][0];

            var text = first + (last == '-' ? string.Empty : last.ToString());

            return text;
        }
    }
}