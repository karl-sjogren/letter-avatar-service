using System.Threading.Tasks;
using LetterAvatarService.Contracts;
using Microsoft.Extensions.Logging;

namespace LetterAvatarService.Services {
    public class DefaultStatisticsService : IStatisticsService {
        private readonly ILogger<DefaultStatisticsService> _log;

        public DefaultStatisticsService(ILogger<DefaultStatisticsService> log) {
            _log = log;
        }

        public Task TrackHit(string name, int size) {
            return Task.CompletedTask;
        }
    }
}
