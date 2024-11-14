namespace LetterAvatars.Service.Contracts;

public interface IStatisticsService : IHostedService {
    Task TrackHitAsync(string name, Int32 size, CancellationToken cancellationToken);
}
