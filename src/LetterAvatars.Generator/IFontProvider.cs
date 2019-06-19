using System.Threading;
using System.Threading.Tasks;
using SixLabors.Fonts;

namespace LetterAvatars.Generator {
    public interface IFontProvider {
        Task<FontFamily> GetFont(CancellationToken cancellationToken = default);
    }
}
