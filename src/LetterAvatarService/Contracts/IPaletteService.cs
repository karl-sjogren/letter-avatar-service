using System;
using System.Security.Cryptography;
using System.Text;
using SixLabors.ImageSharp.PixelFormats;

namespace LetterAvatarService.Contracts {
    public interface IPaletteService {
        Rgba32[] GetPalette();

        Rgba32 GetColorForString(string input) {
            using(var md5Hash = MD5.Create()) {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                var value = Math.Abs(BitConverter.ToInt32(data, 0));
                var palette = GetPalette();

                return palette[value % palette.Length];

            }
        }
    }
}
