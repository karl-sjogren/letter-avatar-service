using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace LetterAvatars.Generator;

public class PngAvatarGenerator : ImageAvatarGeneratorBase {
    public PngAvatarGenerator(IFontProvider fontProvider)
        : base(fontProvider) { }

    public override string Extension => "png";

    public override string MimeType => "image/png";

    protected override async Task<byte[]> RenderGlyphsAsync(IPathCollection glyphs, Int32 squareSize, Rgba32 foregroundColor, Rgba32 backgroundColor, CancellationToken cancellationToken) {
        using var img = new Image<Rgba32>(squareSize, squareSize);
        var brush = new SolidBrush(foregroundColor);

        img.Mutate(ctx => ctx
            .Fill(backgroundColor)
            .Fill(brush, glyphs));

        await using var ms = new MemoryStream();
        await img.SaveAsPngAsync(ms, cancellationToken);
        ms.Seek(0, SeekOrigin.Begin);
        return ms.ToArray();
    }
}
