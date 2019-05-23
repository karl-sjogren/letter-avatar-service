
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Shorthand.ImageSharp.WebP;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Shapes;

namespace LetterAvatars.Generator {
    public class WebPAvatarGenerator : ImageAvatarGeneratorBase {
        public WebPAvatarGenerator(IFontProvider fontProvider, IPaletteProvider paletteProvider)
            : base(fontProvider, paletteProvider) { }

        public override string MimeType => "image/webp";

        protected override Task<byte[]> RenderGlyphs(IPathCollection glyphs, int squareSize, Rgba32 foregroundColor, Rgba32 backgroundColor, CancellationToken cancellationToken) {
            using(var img = new Image<Rgba32>(squareSize, squareSize)) {
                var graphicsOptions = new GraphicsOptions(true);

                img.Mutate(ctx => ctx
                    .Fill(backgroundColor)
                    .Fill(graphicsOptions, foregroundColor, glyphs));

                using(var ms = new MemoryStream()) {
                    img.SaveAsWebP(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    return Task.FromResult(ms.ToArray());
                }
            }
        }
    }
}