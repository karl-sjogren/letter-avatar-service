using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SixLabors.ImageSharp.PixelFormats;

namespace LetterAvatars.Generator {
    public interface IPaletteProvider {
        Task<Rgba32[]> GetPalette(CancellationToken cancellationToken = default(CancellationToken));

        Task<Rgba32> GetColorForString(string input, CancellationToken cancellationToken = default);
    }
}
