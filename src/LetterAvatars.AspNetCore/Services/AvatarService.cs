using LetterAvatars.Generator;
using LetterAvatars.AspNetCore.Contracts;
using SixLabors.ImageSharp.PixelFormats;
using Microsoft.Extensions.Logging;

namespace LetterAvatars.AspNetCore.Services;

public class AvatarService : IAvatarService {
    private readonly IEnumerable<IAvatarGenerator> _avatarGenerators;
    private readonly IPaletteProvider _paletteProvider;
    private readonly ILogger<AvatarService> _log;

    public AvatarService(
            IEnumerable<IAvatarGenerator> avatarGenerators,
            IPaletteProvider paletteProvider,
            ILogger<AvatarService> log) {
        _avatarGenerators = avatarGenerators;
        _paletteProvider = paletteProvider;
        _log = log;
    }

    public async Task<byte[]?> GenerateAvatarAsync(string name, string formatExtension, Int32 squareSize, CancellationToken cancellationToken) {
        var cleanedName = AvatarHelpers.CleanName(name);
        if(string.IsNullOrWhiteSpace(cleanedName)) {
            return null;
        }

        var backgroundColor = await _paletteProvider.GetColorForStringAsync(cleanedName, cancellationToken);

        var generator = _avatarGenerators.FirstOrDefault(p => p.Extension.Equals(formatExtension, StringComparison.OrdinalIgnoreCase));
        if(generator == null)
            throw new InvalidOperationException("No generator found for extension " + formatExtension);

        var buffer = await generator.GenerateAvatarAsync(cleanedName, squareSize, Rgba32.ParseHex("fff"), backgroundColor, cancellationToken);
        return buffer;
    }
}
