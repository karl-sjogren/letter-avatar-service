using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using LetterAvatars.Service.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LetterAvatars.Service.Services {
    public class MongoDbStatisticsService : IStatisticsService {
        private readonly ILogger<MongoDbStatisticsService> _log;
        private readonly IMongoCollection<BsonDocument> _collection;
        private readonly CancellationTokenSource _stoppingCancellationToken = new CancellationTokenSource();
        private readonly ConcurrentBag<Hit> _queue = new ConcurrentBag<Hit>();

        private Timer _timer;

        public MongoDbStatisticsService(IConfiguration configuration, ILogger<MongoDbStatisticsService> log) {
            _log = log;

            var connectionString = MongoUrl.Create(configuration["MongoDb:ConnectionString"]);

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(connectionString.DatabaseName);
            _collection = database.GetCollection<BsonDocument>("avatar-statistics");
        }


        public Task StartAsync(CancellationToken cancellationToken) {
            _timer = new Timer(PublishHits, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) {
            _timer?.Change(Timeout.Infinite, 0);
            _stoppingCancellationToken.Cancel();
            return Task.CompletedTask;
        }

        private async void PublishHits(object state) {
            var hasHit = _queue.TryTake(out var hit);
            do {
                if(_stoppingCancellationToken.IsCancellationRequested)
                    return;
    
                var filterBuilder = new FilterDefinitionBuilder<BsonDocument>();
                var filter = filterBuilder.And(
                    filterBuilder.Eq("name", hit.Name),
                    filterBuilder.Eq("size", hit.Size)
                );

                var updateBuilder = new UpdateDefinitionBuilder<BsonDocument>();
                var update = updateBuilder
                    .Inc("hits", 1)
                    .Set("last-hit", DateTime.UtcNow);

                await _collection.UpdateOneAsync(
                    filter, 
                    update,
                    new UpdateOptions { IsUpsert = true },
                    _stoppingCancellationToken.Token);
            } while((hasHit = _queue.TryTake(out hit)));
        }

        public Task TrackHit(string name, Int32 size, CancellationToken cancellationToken) {
            var hit = new Hit { Name = name, Size = size };
            _queue.Add(hit);
            return Task.CompletedTask;
        }

        private class Hit {
            public string Name { get; set; }
            public Int32 Size { get; set; }
        }
    }
}
