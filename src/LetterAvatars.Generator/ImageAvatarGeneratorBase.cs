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

        protected ImageAvatarGeneratorBase(IFontProvider fontProvider) {
            _fontProvider = fontProvider;
        }

        public abstract string Extension { get; }
        public abstract string MimeType { get; }

        protected abstract Task<byte[]> RenderGlyphs(IPathCollection glyphs, Int32 squareSize, Rgba32 foregroundColor, Rgba32 backgroundColor, CancellationToken cancellationToken = default(CancellationToken));

        public async Task<byte[]> GenerateAvatar(string name, Int32 squareSize, Rgba32 foregroundColor, Rgba32 backgroundColor, CancellationToken cancellationToken = default(CancellationToken)) {
            var text = AvatarHelpers.GetAvatarLetters(name);
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
    }
}