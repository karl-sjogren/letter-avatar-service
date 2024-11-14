using System.Globalization;
using System.Reflection;
using SixLabors.Fonts;

namespace LetterAvatars.Generator;

public class DefaultFontProvider : IFontProvider {
    private readonly FontCollection _fontCollection;
    private readonly string _fontName;

    public DefaultFontProvider() {
        _fontCollection = new FontCollection();
        _fontName = "Roboto";

        var assembly = typeof(DefaultFontProvider).GetTypeInfo().Assembly;
        using var stream = assembly.GetManifestResourceStream("LetterAvatars.Generator.Resources.Roboto-Regular.ttf");
        if(stream is null) {
            throw new Exception("Default font not found.");
        }

        _fontCollection.Add(stream, CultureInfo.InvariantCulture);
    }

    public DefaultFontProvider(string fontName, Stream fontData) {
        _fontCollection = new FontCollection();
        _fontName = fontName;
        _fontCollection.Add(fontData, CultureInfo.InvariantCulture);
    }

    public Task<FontFamily> GetFontAsync(CancellationToken cancellationToken) {
        if(_fontCollection.TryGet(_fontName, out var fontFamily))
            return Task.FromResult(fontFamily);

        throw new Exception($"Font {_fontName} not found.");
    }
}
