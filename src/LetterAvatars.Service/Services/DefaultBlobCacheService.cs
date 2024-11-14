using LetterAvatars.Service.Contracts;

namespace LetterAvatars.Service.Services;

public class DefaultBlobCacheService : IBlobCacheService {
    private readonly ILogger<DefaultBlobCacheService> _log;

    public DefaultBlobCacheService(ILogger<DefaultBlobCacheService> log) {
        _log = log;
    }

    public Task<byte[]?> GetBlobAsync(string key, CancellationToken cancellationToken) {
        return Task.FromResult((byte[]?)null);
    }

    public Task StoreBlobAsync(string key, byte[] buffer, CancellationToken cancellationToken) {
        return Task.CompletedTask;
    }
}
