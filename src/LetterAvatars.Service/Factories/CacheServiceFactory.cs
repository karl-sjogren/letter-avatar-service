using System.IO.Abstractions;
using Amazon.S3;
using LetterAvatars.Service.Contracts;
using LetterAvatars.Service.Services;

namespace LetterAvatars.Service.Factories;

public static class CacheServiceFactory {
    public static IBlobCacheService CreateInstance(IServiceProvider serviceProvider) {
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

        if(!string.IsNullOrWhiteSpace(configuration["FileCache:Path"])) {
            var fileSystem = serviceProvider.GetRequiredService<IFileSystem>();
            return new FileSystemBlobCacheService(fileSystem, configuration, loggerFactory.CreateLogger<FileSystemBlobCacheService>());
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
