using System;
using System.Threading;
using System.Threading.Tasks;

namespace LetterAvatars.Service.Contracts {
    public interface IAvatarService {
        Task<byte[]> GenerateAvatar(string name, AvatarFormat format, Int32 squareSize, CancellationToken cancellationToken = default);
    }

    public enum AvatarFormat {
        Png,
        WebP,
        Svg
    }
}
