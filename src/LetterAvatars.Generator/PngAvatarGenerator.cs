
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Shapes;

namespace LetterAvatars.Generator {
    public class PngAvatarGenerator : ImageAvatarGeneratorBase {
        public PngAvatarGenerator(IFontProvider fontProvider)
            : base(fontProvider) { }

        public override string Extension => "png";

        public override string MimeType => "image/png";

        protected override Task<byte[]> RenderGlyphs(IPathCollection glyphs, Int32 squareSize, Rgba32 foregroundColor, Rgba32 backgroundColor, CancellationToken cancellationToken) {
            using(var img = new Image<Rgba32>(squareSize, squareSize)) {
                var graphicsOptions = new GraphicsOptions(true);

                img.Mutate(ctx => ctx
                    .Fill(backgroundColor)
                    .Fill(graphicsOptions, foregroundColor, glyphs));

                using(var ms = new MemoryStream()) {
                    img.SaveAsPng(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    return Task.FromResult(ms.ToArray());
                }
            }
        }
    }
}