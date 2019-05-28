using System.IO;
using System.Reflection;
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

            var assembly = typeof(DefaultFontProvider).GetTypeInfo().Assembly;
            using(var stream = assembly.GetManifestResourceStream("LetterAvatars.Generator.Resources.Roboto-Regular.ttf"))
                fontFamily = _fontCollection.Install(stream);

            return Task.FromResult(fontFamily);
        }
    }
}
