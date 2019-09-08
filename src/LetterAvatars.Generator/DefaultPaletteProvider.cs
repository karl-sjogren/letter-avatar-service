using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SixLabors.ImageSharp.PixelFormats;

namespace LetterAvatars.Generator {
    public class DefaultPaletteProvider : PaletteProviderBase {
        private readonly Rgba32[] _palette;

        public DefaultPaletteProvider() {
            _palette = new[] {
                new Rgba32(171, 197, 191),
                new Rgba32(198, 167, 215),
                new Rgba32(198, 227, 179),
                new Rgba32(136, 174, 225),
                new Rgba32(233, 209, 167),
                new Rgba32(136, 174, 225),
                new Rgba32(216, 177, 148),
                new Rgba32(136, 174, 225),
                new Rgba32(237, 233, 201),
                new Rgba32(136, 174, 225),
                new Rgba32(190, 186, 148),
                new Rgba32(136, 174, 225),
                new Rgba32(230, 171, 158),
                new Rgba32(128, 208, 225),
                new Rgba32(233, 180, 203),
                new Rgba32(154, 194, 161),
                new Rgba32(222, 199, 245),
                new Rgba32(188, 237, 216),
                new Rgba32(136, 174, 225),
                new Rgba32(173, 190, 166),
                new Rgba32(136, 174, 225),
                new Rgba32(210, 232, 217),
                new Rgba32(136, 174, 225),
                new Rgba32(206, 198, 180),
                new Rgba32(136, 174, 225),
                new Rgba32(228, 199, 196),
                new Rgba32(136, 174, 225),
                new Rgba32(135, 196, 184),
                new Rgba32(185, 180, 221),
                new Rgba32(162, 231, 237),
                new Rgba32(136, 174, 225),
                new Rgba32(151, 177, 171),
                new Rgba32(136, 174, 225),
                new Rgba32(214, 213, 234),
                new Rgba32(136, 174, 225),
                new Rgba32(195, 179, 203),
                new Rgba32(136, 174, 225),
                new Rgba32(165, 209, 228),
                new Rgba32(136, 174, 225),
                new Rgba32(184, 207, 242),
                new Rgba32(136, 174, 225),
                new Rgba32(163, 179, 205),
                new Rgba32(136, 174, 225)
            };
        }

        public DefaultPaletteProvider(Rgba32[] palette) {
            _palette = palette ?? throw new ArgumentNullException(nameof(palette));
        }

        public override Task<Rgba32[]> GetPalette(CancellationToken cancellationToken) => Task.FromResult(_palette);
    }
}
