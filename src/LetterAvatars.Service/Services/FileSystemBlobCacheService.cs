using System.IO.Abstractions;
using LetterAvatars.Service.Contracts;
using Microsoft.Extensions.FileProviders;

namespace LetterAvatars.Service.Services;

public class FileSystemBlobCacheService : IBlobCacheService {
    private readonly IFileSystem _fileSystem;
    private readonly PhysicalFileProvider _fileProvider;
    private readonly ILogger<FileSystemBlobCacheService> _log;

    public FileSystemBlobCacheService(IFileSystem fileSystem, IConfiguration configuration, ILogger<FileSystemBlobCacheService> log) {
        var path = fileSystem.Path.GetFullPath(configuration["FileCache:Path"]!);
        if(!fileSystem.Directory.Exists(path)) {
            fileSystem.Directory.CreateDirectory(path);
        }

        _fileProvider = new PhysicalFileProvider(path);
        _log = log;
        _fileSystem = new FileSystem();
    }

    public async Task<byte[]?> GetBlobAsync(string key, CancellationToken cancellationToken) {
        var path = GetCachePath(key);

        var fileInfo = _fileProvider.GetFileInfo(path);
        if(!fileInfo.Exists)
            return null;

        await using var stream = fileInfo.CreateReadStream();
        await using var ms = new MemoryStream();

        await stream.CopyToAsync(ms, cancellationToken);
        return ms.ToArray();
    }

    public async Task StoreBlobAsync(string key, byte[] buffer, CancellationToken cancellationToken) {
        var path = GetCachePath(key);

        var fileInfo = _fileProvider.GetFileInfo(path);
        if(fileInfo.Exists) {
            _fileSystem.File.Delete(fileInfo.PhysicalPath!);
        }

        await _fileSystem.File.WriteAllBytesAsync(fileInfo.PhysicalPath!, buffer, cancellationToken);
    }

    private string GetCachePath(string key) {
        if(key.Length < 6) {
            // This shouldn't really happen since the metadata alone is more then six chars
            return key;
        }

        var directory = key.Substring(0, 6).Trim();
        var fileInfo = _fileProvider.GetFileInfo(directory);
        if(!fileInfo.Exists)
            _fileSystem.Directory.CreateDirectory(fileInfo.PhysicalPath!);

        return _fileSystem.Path.Join(directory, key);
    }
}
