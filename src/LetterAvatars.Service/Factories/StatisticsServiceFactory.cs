using System;
using LetterAvatars.Service.Contracts;
using LetterAvatars.Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LetterAvatars.Service.Factories {
    public static class StatisticsServiceFactory {
        public static IStatisticsService CreateInstance(IServiceProvider serviceProvider) {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

            if(!string.IsNullOrWhiteSpace(configuration["MongoDb:ConnectionString"])) {
                return new MongoDbStatisticsService(configuration, loggerFactory.CreateLogger<MongoDbStatisticsService>());
            }

            return new DefaultStatisticsService(loggerFactory.CreateLogger<DefaultStatisticsService>());
        }
    }
}