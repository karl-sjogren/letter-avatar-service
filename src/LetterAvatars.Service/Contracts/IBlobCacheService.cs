using System.Threading;
using System.Threading.Tasks;

namespace LetterAvatars.Service.Contracts {
    public interface IBlobCacheService {
        Task<byte[]> GetBlob(string key, CancellationToken cancellationToken = default);
        Task StoreBlob(string key, byte[] buffer, CancellationToken cancellationToken = default);
    }
}
