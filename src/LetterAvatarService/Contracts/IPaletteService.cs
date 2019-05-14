using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using SixLabors.ImageSharp.PixelFormats;

namespace LetterAvatarService.Contracts {
    public interface IPaletteService {
        Rgba32[] GetPalette(CancellationToken cancellationToken);

        Rgba32 GetColorForString(string input, CancellationToken cancellationToken) {
            using(var md5Hash = MD5.Create()) {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                var value = Math.Abs(BitConverter.ToInt32(data, 0));
                var palette = GetPalette(cancellationToken);

                return palette[value % palette.Length];
            }
        }
    }
}
