using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using LetterAvatars.Service.Contracts;
using Microsoft.Extensions.Logging;

namespace LetterAvatars.Service.Services {
    public class AvatarService : IAvatarService {
        private readonly IBlobCacheService _cacheService;
        private readonly IStatisticsService _statisticsService;
        private readonly ILogger<AvatarService> _log;

        public AvatarService(IBlobCacheService cacheService,
                             IStatisticsService statisticsService,
                             ILogger<AvatarService> log) {
            _cacheService = cacheService;
            _statisticsService = statisticsService;
            _log = log;
        }

        public async Task<byte[]> GenerateAvatar(string name, AvatarFormat format, Int32 squareSize, Int32 fontSize, CancellationToken cancellationToken) {
            await _statisticsService.TrackHit(name, squareSize, cancellationToken);

            var cacheKey = GetCacheKey(name, format, squareSize, fontSize);

            var cachedBlob = await _cacheService.GetBlob(cacheKey, cancellationToken);
            if(cachedBlob != null)
                return cachedBlob;

            byte[] buffer = new byte[0]; // TODO Get a suitable provider
            
            await _cacheService.StoreBlob(cacheKey, buffer, cancellationToken);
            return buffer;
        }

        private string GetCacheKey(string name, AvatarFormat format, Int32 size, Int32 fontSize) {
            return $"{name}|{format}|{size}|{fontSize}";
        }
    }
}
