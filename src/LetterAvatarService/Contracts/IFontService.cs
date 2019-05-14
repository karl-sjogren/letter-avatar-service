using System.Threading;
using SixLabors.Fonts;

namespace LetterAvatarService.Contracts {
    public interface IFontService {
        FontFamily GetFont(CancellationToken cancellationToken);
    }
}
