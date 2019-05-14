using System;
using System.Threading;
using System.Threading.Tasks;

namespace LetterAvatarService.Contracts {
    public interface IStatisticsService {
        Task TrackHit(string name, Int32 size, CancellationToken cancellationToken);
    }
}
