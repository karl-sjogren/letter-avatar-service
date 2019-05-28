using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LetterAvatars.Generator;
using LetterAvatars.Service.Contracts;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp.PixelFormats;

namespace LetterAvatars.Service.Services {
    public class AvatarService : IAvatarService {
        private readonly IEnumerable<IAvatarGenerator> _avatarGenerators;
        private readonly IPaletteProvider _paletteProvider;
        private readonly IBlobCacheService _cacheService;
        private readonly IStatisticsService _statisticsService;
        private readonly ILogger<AvatarService> _log;

        public AvatarService(IEnumerable<IAvatarGenerator> avatarGenerators,
                             IPaletteProvider paletteProvider,
                             IBlobCacheService cacheService,
                             IStatisticsService statisticsService,
                             ILogger<AvatarService> log) {
            _avatarGenerators = avatarGenerators;
            _paletteProvider = paletteProvider;
            _cacheService = cacheService;
            _statisticsService = statisticsService;
            _log = log;
        }

        public async Task<byte[]> GenerateAvatar(string name, AvatarFormat format, Int32 squareSize, CancellationToken cancellationToken) {
            name = AvatarHelpers.CleanName(name);

            await _statisticsService.TrackHit(name, squareSize, cancellationToken);

            var backgroundColor = await _paletteProvider.GetColorForString(name, cancellationToken);

            var cacheKey = GetCacheKey(name, format, squareSize, backgroundColor);

            var cachedBlob = await _cacheService.GetBlob(cacheKey, cancellationToken);
            if(cachedBlob != null)
                return cachedBlob;

            byte[] buffer = new byte[0]; // TODO Get a suitable provider
            
            await _cacheService.StoreBlob(cacheKey, buffer, cancellationToken);
            return buffer;
        }

        private string GetCacheKey(string name, AvatarFormat format, Int32 size, Rgba32 backgroundColor) {
            var letters = AvatarHelpers.GetAvatarLetters(name);
            return $"{letters}|{format}|{size}|{backgroundColor.ToHex()}";
        }
    }
}
