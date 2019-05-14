using System.IO;
using System.Threading.Tasks;
using LetterAvatarService.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;

namespace LetterAvatarService.Services {
    public class FileSystemBlobCacheService : IBlobCacheService {
        private readonly PhysicalFileProvider _fileProvider;
        private readonly ILogger<FileSystemBlobCacheService> _log;

        public FileSystemBlobCacheService(IConfiguration configuration, ILogger<FileSystemBlobCacheService> log) {
            var path = Path.GetFullPath(configuration["FileCache:Path"]);
            if(!Directory.Exists(path))
                Directory.CreateDirectory(path);

            _fileProvider = new PhysicalFileProvider(path);
            _log = log;
        }

        public async Task<byte[]> GetBlob(string key) {
            var path = GetCachePath(key);

            var fileInfo = _fileProvider.GetFileInfo(path);
            if(!fileInfo.Exists)
                return null;
            
            using var stream = fileInfo.CreateReadStream();
            using var ms = new MemoryStream();

            await stream.CopyToAsync(ms);
            return ms.ToArray();
        }

        public async Task StoreBlob(string key, byte[] buffer) {
            var path = GetCachePath(key);

            var fileInfo = _fileProvider.GetFileInfo(path);
            if(fileInfo.Exists)
                File.Delete(fileInfo.PhysicalPath);

            await File.WriteAllBytesAsync(fileInfo.PhysicalPath, buffer);
        }

        private string GetCachePath(string key) {
            if(key.Length < 6) {
                // This shouldn't really happen since the metadata alone is more then six chars
                return key;
            }

            var directory = key.Substring(0, 6).Trim();
            var fileInfo = _fileProvider.GetFileInfo(directory);
            if(!fileInfo.Exists)
                Directory.CreateDirectory(fileInfo.PhysicalPath);

            return Path.Join(directory, key);
        }
    }
}
