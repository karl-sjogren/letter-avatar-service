using System.IO;
using System.Threading;
using System.Threading.Tasks;
using SixLabors.Fonts;
using SixLabors.ImageSharp.PixelFormats;

namespace LetterAvatars.Generator {
    public class DefaultFontProvider : IFontProvider {
        private readonly FontCollection _fontCollection;

        public DefaultFontProvider() {
            _fontCollection = new FontCollection();
        }

        public Task<FontFamily> GetFont(CancellationToken cancellationToken) {
            if(_fontCollection.TryFind("Roboto", out var fontFamily))
                return Task.FromResult(fontFamily);

            fontFamily = _fontCollection.Install(Path.Combine("Resources", "Roboto-Regular.ttf"));

            return Task.FromResult(fontFamily);
        }
    }
}
