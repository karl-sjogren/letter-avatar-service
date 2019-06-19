using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<byte[]> GenerateAvatar(string name, string formatExtension, Int32 squareSize, CancellationToken cancellationToken) {
            name = AvatarHelpers.CleanName(name);

            await _statisticsService.TrackHit(name, squareSize, cancellationToken);

            var backgroundColor = await _paletteProvider.GetColorForString(name, cancellationToken);

            var cacheKey = GetCacheKey(name, formatExtension, squareSize, backgroundColor);

            var cachedBlob = await _cacheService.GetBlob(cacheKey, cancellationToken);
            if(cachedBlob != null)
                return cachedBlob;

            var generator = _avatarGenerators.FirstOrDefault(p => p.Extension.Equals(formatExtension, StringComparison.OrdinalIgnoreCase));
            if(generator == null)
                throw new InvalidOperationException("No generator found for extension " + formatExtension);

            var buffer = await generator.GenerateAvatar(name, squareSize, Rgba32.White, backgroundColor, cancellationToken);
            
            await _cacheService.StoreBlob(cacheKey, buffer, cancellationToken);
            return buffer;
        }

        private string GetCacheKey(string name, string formatExtension, Int32 size, Rgba32 backgroundColor) {
            var letters = AvatarHelpers.GetAvatarLetters(name);
            return $"{letters}|{formatExtension}|{size}|{backgroundColor.ToHex()}";
        }
    }
}
