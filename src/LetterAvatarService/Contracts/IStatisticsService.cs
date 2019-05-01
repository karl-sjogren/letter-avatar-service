using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SixLabors.Fonts;
using SixLabors.ImageSharp.PixelFormats;

namespace LetterAvatarService.Contracts {
    public interface IStatisticsService {
        Task TrackHit(string name, Int32 size);
    }
}
