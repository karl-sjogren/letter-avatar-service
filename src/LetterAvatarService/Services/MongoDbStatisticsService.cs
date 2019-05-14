using System;
using System.Threading;
using System.Threading.Tasks;
using LetterAvatarService.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LetterAvatarService.Services {
    public class MongoDbStatisticsService : IStatisticsService {
        private readonly ILogger<MongoDbStatisticsService> _log;
        private readonly IMongoCollection<BsonDocument> _collection;

        public MongoDbStatisticsService(IConfiguration configuration, ILogger<MongoDbStatisticsService> log) {
            _log = log;

            var connectionString = MongoUrl.Create(configuration["MongoDb:ConnectionString"]);

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(connectionString.DatabaseName);
            _collection = database.GetCollection<BsonDocument>("avatar-statistics");
        }

        public async Task TrackHit(string name, int size, CancellationToken cancellationToken) {
            var filterBuilder = new FilterDefinitionBuilder<BsonDocument>();
            var filter = filterBuilder.And(
                filterBuilder.Eq("name", name),
                filterBuilder.Eq("size", size)
            );

            var updateBuilder = new UpdateDefinitionBuilder<BsonDocument>();
            var update = updateBuilder
                .Inc("hits", 1)
                .Set("last-hit", DateTime.UtcNow);

            await _collection.UpdateOneAsync(
                filter, 
                update,
                new UpdateOptions { IsUpsert = true },
                cancellationToken);
        }
    }
}
