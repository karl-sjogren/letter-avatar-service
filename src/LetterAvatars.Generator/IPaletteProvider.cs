using SixLabors.ImageSharp.PixelFormats;

namespace LetterAvatars.Generator;

public interface IPaletteProvider {
    Task<Rgba32[]> GetPaletteAsync(CancellationToken cancellationToken);

    Task<Rgba32> GetColorForStringAsync(string input, CancellationToken cancellationToken);
}
