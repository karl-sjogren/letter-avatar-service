using System.Threading;
using System.Threading.Tasks;
using LetterAvatars.Service.Contracts;
using Microsoft.Extensions.Logging;

namespace LetterAvatars.Service.Services {
    public class DefaultStatisticsService : IStatisticsService {
        private readonly ILogger<DefaultStatisticsService> _log;

        public DefaultStatisticsService(ILogger<DefaultStatisticsService> log) {
            _log = log;
        }

        public Task TrackHit(string name, int size, CancellationToken cancellationToken) {
            return Task.CompletedTask;
        }
    }
}
