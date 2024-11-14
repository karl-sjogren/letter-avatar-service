using System.Diagnostics;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using LetterAvatars.Service.Contracts;

namespace LetterAvatars.Service.Services;

public class AzureBlobCacherService : IBlobCacheService {
    private readonly IConfiguration _configuration;
    private readonly ILogger<AzureBlobCacherService> _log;

    private static readonly string _containerName = "letter-avatar-cache";

    public AzureBlobCacherService(IConfiguration configuration, ILogger<AzureBlobCacherService> log) {
        _configuration = configuration;
        _log = log;
    }

    private async Task<BlobContainerClient> CreateContainerAsync(CancellationToken cancellationToken) {
        var sw = Stopwatch.StartNew();
        try {
            var connectionString = _configuration["AzureStorage:ConnectionString"];

            var _blobServiceClient = new BlobServiceClient(connectionString);

            var client = _blobServiceClient.GetBlobContainerClient(_containerName);

            await client.CreateIfNotExistsAsync(PublicAccessType.Blob, cancellationToken: cancellationToken);

            return client;
        } finally {
            sw.Stop();
            _log.LogDebug("Initializing the Azure BlobContainerClient took {Elapsed}", sw.Elapsed);
        }
    }

    public async Task<byte[]?> GetBlobAsync(string key, CancellationToken cancellationToken) {
        var sw = Stopwatch.StartNew();
        try {
            var client = await CreateContainerAsync(cancellationToken);

            var blobClient = client.GetBlobClient(key);
            if(!await blobClient.ExistsAsync(cancellationToken))
                return null;

            var result = await blobClient.DownloadContentAsync(cancellationToken: cancellationToken);
            return result.Value.Content.ToArray();
        } finally {
            sw.Stop();
            _log.LogDebug("Fetching the Azure BlobContainerClient for key {Key} took {Elapsed}", key, sw.Elapsed);
        }
    }

    public async Task StoreBlobAsync(string key, byte[] buffer, CancellationToken cancellationToken) {
        var sw = Stopwatch.StartNew();
        try {
            var client = await CreateContainerAsync(cancellationToken);

            var blobClient = client.GetBlobClient(key);
            if(!await blobClient.ExistsAsync(cancellationToken))
                return;

            await using var ms = new MemoryStream(buffer);
            await blobClient.UploadAsync(ms, cancellationToken);
        } finally {
            sw.Stop();
            _log.LogDebug("Storing the Azure BlobContainerClient for key {key} took {Elapsed}", key, sw.Elapsed);
        }
    }
}
