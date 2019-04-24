using System;
using System.Security.Cryptography;
using System.Text;
using SixLabors.Fonts;
using SixLabors.ImageSharp.PixelFormats;

namespace LetterAvatarService.Contracts {
    public interface IFontService {
        FontFamily GetFont();
    }
}
