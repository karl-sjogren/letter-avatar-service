using System.Threading;
using System.Threading.Tasks;
using LetterAvatars.Service.Contracts;
using Microsoft.Extensions.Logging;

namespace LetterAvatars.Service.Services {
    public class DefaultBlobCacheService : IBlobCacheService {
        private readonly ILogger<DefaultBlobCacheService> _log;

        public DefaultBlobCacheService(ILogger<DefaultBlobCacheService> log) {
            _log = log;
        }

        public Task<byte[]> GetBlob(string key, CancellationToken cancellationToken) {
            return Task.FromResult((byte[])null);
        }

        public Task StoreBlob(string key, byte[] buffer, CancellationToken cancellationToken) {
            return Task.CompletedTask;
        }
    }
}
