using System.Threading.Tasks;
using LetterAvatarService.Contracts;
using Microsoft.Extensions.Logging;

namespace LetterAvatarService.Services {
    public class DefaultBlobCacheService : IBlobCacheService {
        private readonly ILogger<DefaultBlobCacheService> _log;

        public DefaultBlobCacheService(ILogger<DefaultBlobCacheService> log) {
            _log = log;
        }

        public Task<byte[]> GetBlob(string key) {
            return Task.FromResult((byte[])null);
        }

        public Task StoreBlob(string key, byte[] buffer) {
            return Task.CompletedTask;
        }
    }
}
