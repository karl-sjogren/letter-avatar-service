using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SixLabors.ImageSharp.PixelFormats;

namespace LetterAvatars.Generator {
    public abstract class PaletteProviderBase : IPaletteProvider {
        public abstract Task<Rgba32[]> GetPalette(CancellationToken cancellationToken);

        public virtual async Task<Rgba32> GetColorForString(string input, CancellationToken cancellationToken) {
            using(var md5Hash = MD5.Create()) {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                var value = Math.Abs(BitConverter.ToInt32(data, 0));
                var palette = await GetPalette(cancellationToken);

                return palette[value % palette.Length];
            }
        }
    }
}
