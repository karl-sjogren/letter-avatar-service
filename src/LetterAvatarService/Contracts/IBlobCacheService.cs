using System.Threading.Tasks;

namespace LetterAvatarService.Contracts {
    public interface IBlobCacheService {
        Task<byte[]> GetBlob(string key);
        Task StoreBlob(string key, byte[] buffer);
    }
}
