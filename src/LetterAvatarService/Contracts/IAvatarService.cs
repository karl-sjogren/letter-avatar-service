using System;
using System.Threading;
using System.Threading.Tasks;

namespace LetterAvatarService.Contracts {
    public interface IAvatarService {
        Task<byte[]> GenerateAvatar(string name, AvatarFormat format, Int32 squareSize, Int32 fontSize, CancellationToken cancellationToken);
    }

    public enum AvatarFormat {
        Png,
        WebP,
        Svg
    }
}
