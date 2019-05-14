using System.Threading;
using System.Threading.Tasks;

namespace LetterAvatarService.Contracts {
    public interface IBlobCacheService {
        Task<byte[]> GetBlob(string key, CancellationToken cancellationToken);
        Task StoreBlob(string key, byte[] buffer, CancellationToken cancellationToken);
    }
}
