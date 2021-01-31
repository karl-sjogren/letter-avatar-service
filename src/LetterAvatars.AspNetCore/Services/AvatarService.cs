using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LetterAvatars.Generator;
using LetterAvatars.AspNetCore.Contracts;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp.PixelFormats;

namespace LetterAvatars.AspNetCore.Services {
    public class AvatarService : IAvatarService {
        private readonly IEnumerable<IAvatarGenerator> _avatarGenerators;
        private readonly IPaletteProvider _paletteProvider;
        private readonly ILogger<AvatarService> _log;

        public AvatarService(IEnumerable<IAvatarGenerator> avatarGenerators,
                             IPaletteProvider paletteProvider,
                             ILogger<AvatarService> log) {
            _avatarGenerators = avatarGenerators;
            _paletteProvider = paletteProvider;
            _log = log;
        }

        public async Task<byte[]> GenerateAvatar(string name, string formatExtension, Int32 squareSize, CancellationToken cancellationToken) {
            name = AvatarHelpers.CleanName(name);

            var backgroundColor = await _paletteProvider.GetColorForString(name, cancellationToken);

            var generator = _avatarGenerators.FirstOrDefault(p => p.Extension.Equals(formatExtension, StringComparison.OrdinalIgnoreCase));
            if(generator == null)
                throw new InvalidOperationException("No generator found for extension " + formatExtension);

            var buffer = await generator.GenerateAvatar(name, squareSize, Rgba32.ParseHex("fff"), backgroundColor, cancellationToken);
            return buffer;
        }
    }
}
