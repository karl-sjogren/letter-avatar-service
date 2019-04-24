using System;
using System.Security.Cryptography;
using System.Text;
using SixLabors.Fonts;
using SixLabors.ImageSharp.PixelFormats;

namespace LetterAvatarService.Contracts {
    public interface IAvatarService {
        byte[] GenerateAvatar(string name, Int32 squareSize, float fontSize);
    }
}
