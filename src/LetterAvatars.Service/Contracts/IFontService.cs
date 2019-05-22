using System.Threading;
using SixLabors.Fonts;

namespace LetterAvatars.Service.Contracts {
    public interface IFontService {
        FontFamily GetFont(CancellationToken cancellationToken);
    }
}
