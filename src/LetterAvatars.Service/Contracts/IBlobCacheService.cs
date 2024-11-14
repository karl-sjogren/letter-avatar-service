namespace LetterAvatars.Service.Contracts;

public interface IBlobCacheService {
    Task<byte[]?> GetBlobAsync(string key, CancellationToken cancellationToken);
    Task StoreBlobAsync(string key, byte[] buffer, CancellationToken cancellationToken);
}
