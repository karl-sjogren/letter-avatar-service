using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace LetterAvatars.Service.Contracts {
    public interface IStatisticsService : IHostedService {
        Task TrackHit(string name, Int32 size, CancellationToken cancellationToken = default);
    }
}
