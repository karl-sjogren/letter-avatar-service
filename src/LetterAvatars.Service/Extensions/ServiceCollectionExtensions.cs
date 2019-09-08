using System.IO;
using LetterAvatars.Generator;
using LetterAvatars.Service.Contracts;
using LetterAvatars.Service.Factories;
using LetterAvatars.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using SixLabors.ImageSharp.PixelFormats;

namespace LetterAvatars.Service.Extensions {
    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddAvatarPalette(this IServiceCollection services) {
            services.AddSingleton<IPaletteProvider>(new DefaultPaletteProvider());
            return services;
        }

        public static IServiceCollection AddAvatarPalette(this IServiceCollection services, Rgba32[] palette) {
            services.AddSingleton<IPaletteProvider>(new DefaultPaletteProvider(palette));
            return services;
        }

        public static IServiceCollection AddAvatarFont(this IServiceCollection services) {
            services.AddSingleton<IFontProvider>(new DefaultFontProvider());
            return services;
        }

        public static IServiceCollection AddAvatarFont(this IServiceCollection services, string fontName, Stream fontData) {
            services.AddSingleton<IFontProvider>(new DefaultFontProvider(fontName, fontData));
            return services;
        }

        public static IServiceCollection AddAvatarGenerators(this IServiceCollection services) {
            services.AddScoped<IAvatarGenerator, SvgAvatarGenerator>();
            services.AddScoped<IAvatarGenerator, PngAvatarGenerator>();
            services.AddScoped<IAvatarGenerator, WebPAvatarGenerator>();
            return services;
        }
        public static IServiceCollection AddAvatarService(this IServiceCollection services) {
            services.AddScoped<IAvatarService, AvatarService>();
            services.AddScoped<IBlobCacheService>(CacheServiceFactory.CreateInstance);
            services.AddScoped<IStatisticsService>(StatisticsServiceFactory.CreateInstance);
            return services;
        }
    }
}
