using System.Threading;
using System.Threading.Tasks;
using SixLabors.ImageSharp.PixelFormats;

namespace LetterAvatars.Generator {
    public interface IAvatarGenerator {
        string MimeType { get; }
        Task<byte[]> GenerateAvatar(string name, int squareSize, Rgba32 foregroundColor, Rgba32 backgroundColor, CancellationToken cancellationToken = default);
    }
}