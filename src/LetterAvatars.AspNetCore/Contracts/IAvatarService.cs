using System;
using System.Threading;
using System.Threading.Tasks;

namespace LetterAvatars.AspNetCore.Contracts {
    public interface IAvatarService {
        Task<byte[]> GenerateAvatar(string name, string formatExtension, Int32 squareSize, CancellationToken cancellationToken = default);
    }
}
