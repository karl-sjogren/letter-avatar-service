using System;
using Amazon.S3;
using LetterAvatars.Service.Contracts;
using LetterAvatars.Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LetterAvatars.Service.Factories {
    public static class CacheServiceFactory {
        public static IBlobCacheService CreateInstance(IServiceProvider serviceProvider) {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

            if(!string.IsNullOrWhiteSpace(configuration["FileCache:Path"])) {
                return new FileSystemBlobCacheService(configuration, loggerFactory.CreateLogger<FileSystemBlobCacheService>());
            }

            if(!string.IsNullOrWhiteSpace(configuration["AWS:BucketName"])) {
                var s3Client = serviceProvider.GetRequiredService<IAmazonS3>();
                return new S3BlobCacheService(configuration, s3Client, loggerFactory.CreateLogger<S3BlobCacheService>());
            }

            if(!string.IsNullOrWhiteSpace(configuration["AzureStorage:ConnectionString"])) {
                return new AzureBlobCacherService(configuration, loggerFactory.CreateLogger<AzureBlobCacherService>());
            }

            return new DefaultBlobCacheService(loggerFactory.CreateLogger<DefaultBlobCacheService>());
        }
    }
}