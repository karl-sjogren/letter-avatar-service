using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using LetterAvatarService.Contracts;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LetterAvatarService.Services {
    public class AzureBlobCacherService : IBlobCacheService {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AzureBlobCacherService> _log;

        public AzureBlobCacherService(IConfiguration configuration, ILogger<AzureBlobCacherService> log) {
            _configuration = configuration;
            _log = log;
        }

        private async Task<CloudBlobContainer> CreateContainer() {
            var sw = Stopwatch.StartNew();
            try {
                var connectionString = _configuration["AzureStorage:ConnectionString"];

                if(!CloudStorageAccount.TryParse(connectionString, out var storageAccount))
                    throw new InvalidOperationException("Configuration for AzureStorage:ConnectionString is missing.");
                
                var client = storageAccount.CreateCloudBlobClient();
                var container = client.GetContainerReference("letter-avatar-cache");
                if(await container.ExistsAsync() == true)
                    return container;

                await container.CreateAsync();

                var permissions = new BlobContainerPermissions {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                };
                await container.SetPermissionsAsync(permissions);

                return container;
            } finally {
                sw.Stop();
                _log.LogDebug($"Initializing the Azure CloudBlobContainer took {sw.Elapsed}");
            }
        }

        public async Task<byte[]> GetBlob(string key) {
            var sw = Stopwatch.StartNew();
            try {
                var container = await CreateContainer();

                var blockBlob = container.GetBlockBlobReference(key);
                if(await blockBlob.ExistsAsync() == false)
                    return null;

                using(var ms = new MemoryStream()) {
                    await blockBlob.DownloadToStreamAsync(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    return ms.ToArray();
                }
            } finally {
                sw.Stop();
                _log.LogDebug($"Fetching the Azure CloudBlobContainer for key {key} took {sw.Elapsed}");
            }
        }

        public async Task StoreBlob(string key, byte[] buffer) {
            var sw = Stopwatch.StartNew();
            try {
                var container = await CreateContainer();

                var blockBlob = container.GetBlockBlobReference(key);
                if(await blockBlob.ExistsAsync() == true)
                    return;
                
                await blockBlob.UploadFromByteArrayAsync(buffer, 0, buffer.Length);
            } finally {
                sw.Stop();
                _log.LogDebug($"Storing the Azure CloudBlobContainer for key {key} took {sw.Elapsed}");
            }
        }
    }
}
