using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Amazon.S3;
using LetterAvatarService.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LetterAvatarService.Services {
    public class S3BlobCacheService : IBlobCacheService {
        private readonly IConfiguration _configuration;
        private readonly IAmazonS3 _client;
        private readonly ILogger<S3BlobCacheService> _log;

        public S3BlobCacheService(IConfiguration configuration, IAmazonS3 client, ILogger<S3BlobCacheService> log) {
            _configuration = configuration;
            _client = client;
            _log = log;
        }

        public async Task<byte[]> GetBlob(string key, CancellationToken cancellationToken) {
            var sw = Stopwatch.StartNew();
            try {
                try {
                    var bucketName = _configuration["AWS:BucketName"];
                    var result = await _client.GetObjectAsync(bucketName, key, null, cancellationToken);

                    using(var ms = new MemoryStream()) {
                        await result.ResponseStream.CopyToAsync(ms);
                        ms.Seek(0, SeekOrigin.Begin);
                        return ms.ToArray();
                    }
                } catch(AmazonS3Exception) {
                    return null;
                }
            } finally {
                sw.Stop();
                _log.LogDebug($"Fetching the S3 object for key {key} took {sw.Elapsed}");
            }
        }

        public async Task StoreBlob(string key, byte[] buffer, CancellationToken cancellationToken) {
            var sw = Stopwatch.StartNew();
            try {
                var bucketName = _configuration["AWS:BucketName"];
                using(var ms = new MemoryStream(buffer)) {
                    await _client.UploadObjectFromStreamAsync(bucketName, key, ms, null, cancellationToken);
                }
            } finally {
                sw.Stop();
                _log.LogDebug($"Storing the S3 object for key {key} took {sw.Elapsed}");
            }
        }
    }
}
