using SixLabors.ImageSharp.PixelFormats;

namespace LetterAvatars.Generator.Extensions {
    public static class Rgba32Extensions {
        public static string ToRgbHex(this Rgba32 color) {
            var hex = color.ToHex();
            return hex.Substring(0, 6);
        }
    }
}