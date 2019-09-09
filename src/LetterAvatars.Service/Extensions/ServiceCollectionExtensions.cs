using System.IO;
using LetterAvatars.Generator;
using LetterAvatars.Service.Contracts;
using LetterAvatars.Service.Factories;
using LetterAvatars.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using SixLabors.ImageSharp.PixelFormats;

namespace LetterAvatars.Service.Extensions {
    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddAvatarFactories(this IServiceCollection services) {
            services.AddSingleton<IBlobCacheService>(CacheServiceFactory.CreateInstance);
            services.AddSingleton<IStatisticsService>(StatisticsServiceFactory.CreateInstance);
            return services;
        }
    }
}
