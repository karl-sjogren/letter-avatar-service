using SixLabors.Fonts;

namespace LetterAvatars.Generator;

public interface IFontProvider {
    Task<FontFamily> GetFontAsync(CancellationToken cancellationToken);
}
