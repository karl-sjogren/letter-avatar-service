using System.IO;
using System.Threading;
using LetterAvatars.Service.Contracts;
using Microsoft.Extensions.Logging;
using SixLabors.Fonts;
using SixLabors.ImageSharp.PixelFormats;

namespace LetterAvatars.Service.Services {
    public class DefaultFontService : IFontService {
        private readonly ILogger<DefaultFontService> _log;
        private readonly FontCollection _fontCollection;

        public DefaultFontService(ILogger<DefaultFontService> log) {
            _log = log;

            _fontCollection = new FontCollection();
        }

        public FontFamily GetFont(CancellationToken cancellationToken) {
            if(_fontCollection.TryFind("Roboto", out var fontFamily))
                return fontFamily;

            fontFamily = _fontCollection.Install(Path.Combine("Resources", "Roboto-Regular.ttf"));

            return fontFamily;
        }
    }
}
