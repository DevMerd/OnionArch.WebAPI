using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OnionArch.Application.Interfaces.RedisCache;
using StackExchange.Redis;

namespace OnionArch.Infrastructure.RedisCache
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly ConnectionMultiplexer _redisConnection;
        private readonly RedisCacheSettings _redisCacheSettings;
        private readonly IDatabase _database;

        public RedisCacheService(IOptions<RedisCacheSettings> options, IDatabase database, RedisCacheSettings redisCacheSettings, ConnectionMultiplexer connectionMultiplexer)
        {
            _redisCacheSettings = options.Value;
            var opt = ConfigurationOptions.Parse(_redisCacheSettings.ConnectionString);
            _redisConnection = ConnectionMultiplexer.Connect(opt);
            _database = _redisConnection.GetDatabase();

            _database = database;
            _redisCacheSettings = redisCacheSettings;
            _redisConnection = connectionMultiplexer;
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var value = await _database.StringGetAsync(key);
            if (value.HasValue)
                return JsonConvert.DeserializeObject<T>(value);

            return default;
        }

        public async Task SetAsync<T>(string key, T value, DateTime? expirationTime = null)
        {
            TimeSpan timeUnitExpiration = expirationTime.Value - DateTime.Now;
            await _database.StringSetAsync(key, JsonConvert.SerializeObject(value), timeUnitExpiration);
        }
    }
}
