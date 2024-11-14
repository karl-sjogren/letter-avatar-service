using SixLabors.ImageSharp.PixelFormats;

namespace LetterAvatars.Generator;

public interface IAvatarGenerator {
    string Extension { get; }
    string MimeType { get; }
    Task<byte[]?> GenerateAvatarAsync(string name, Int32 squareSize, Rgba32 foregroundColor, Rgba32 backgroundColor, CancellationToken cancellationToken);
}
