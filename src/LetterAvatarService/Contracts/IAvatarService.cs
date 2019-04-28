using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SixLabors.Fonts;
using SixLabors.ImageSharp.PixelFormats;

namespace LetterAvatarService.Contracts {
    public interface IAvatarService {
        Task<byte[]> GenerateAvatar(string name, Int32 squareSize, Int32 fontSize);
    }
}
