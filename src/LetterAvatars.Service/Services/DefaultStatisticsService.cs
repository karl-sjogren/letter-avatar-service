using LetterAvatars.Service.Contracts;

namespace LetterAvatars.Service.Services;

public class DefaultStatisticsService : IStatisticsService {
    private readonly ILogger<DefaultStatisticsService> _log;

    public DefaultStatisticsService(ILogger<DefaultStatisticsService> log) {
        _log = log;
    }

    public Task StartAsync(CancellationToken cancellationToken) {
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) {
        return Task.CompletedTask;
    }

    public Task TrackHitAsync(string name, Int32 size, CancellationToken cancellationToken) {
        return Task.CompletedTask;
    }
}
