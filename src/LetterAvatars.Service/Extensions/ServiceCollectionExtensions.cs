using LetterAvatars.Service.Factories;

namespace LetterAvatars.Service.Extensions;

public static class ServiceCollectionExtensions {
    public static IServiceCollection AddAvatarFactories(this IServiceCollection services) {
        services.AddScoped(CacheServiceFactory.CreateInstance);
        return services;
    }
}
