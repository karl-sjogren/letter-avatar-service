using LetterAvatars.Service.Contracts;
using LetterAvatars.Service.Factories;

namespace LetterAvatars.Service.Extensions;

public static class ServiceCollectionExtensions {
    public static IServiceCollection AddAvatarFactories(this IServiceCollection services) {
        services.AddSingleton<IBlobCacheService>(CacheServiceFactory.CreateInstance);
        services.AddSingleton<IStatisticsService>(StatisticsServiceFactory.CreateInstance);
        return services;
    }
}
