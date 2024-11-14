using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.PixelFormats;

namespace LetterAvatars.Generator;

public abstract class ImageAvatarGeneratorBase : IAvatarGenerator {
    private readonly IFontProvider _fontProvider;

    protected ImageAvatarGeneratorBase(IFontProvider fontProvider) {
        _fontProvider = fontProvider;
    }

    public abstract string Extension { get; }
    public abstract string MimeType { get; }

    protected abstract Task<byte[]> RenderGlyphsAsync(IPathCollection glyphs, Int32 squareSize, Rgba32 foregroundColor, Rgba32 backgroundColor, CancellationToken cancellationToken = default(CancellationToken));

    public async Task<byte[]?> GenerateAvatarAsync(string name, Int32 squareSize, Rgba32 foregroundColor, Rgba32 backgroundColor, CancellationToken cancellationToken = default(CancellationToken)) {
        var text = AvatarHelpers.GetAvatarLetters(name);
        if(string.IsNullOrWhiteSpace(text)) {
            return null;
        }

        var fontFamily = await _fontProvider.GetFontAsync(cancellationToken);
        var fontSize = squareSize * .55f;
        var font = new Font(fontFamily, fontSize, FontStyle.Regular);

        var glyphs = TextBuilder.GenerateGlyphs(text, new TextOptions(font));
        glyphs = glyphs.Translate(-glyphs.Bounds.Location);

        var textPosition = new PointF(squareSize / 2f - glyphs.Bounds.Width / 2, squareSize / 2f - glyphs.Bounds.Height / 2f);
        glyphs = glyphs.Translate(textPosition);

        return await RenderGlyphsAsync(glyphs, squareSize, foregroundColor, backgroundColor, cancellationToken);
    }
}
