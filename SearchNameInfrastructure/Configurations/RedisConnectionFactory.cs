using SearchName.Application.Configurations;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchNameInfrastructure.Configurations
{
    public class RedisConnectionFactory : IRedisConnectionFactory
    {
        private readonly Lazy<ConnectionMultiplexer> _connection;
        public RedisConnectionFactory()
        {
            _connection = new Lazy<ConnectionMultiplexer>(() =>ConnectionMultiplexer.Connect(Configuration.RedisConnectionString));            
        }
        public ConnectionMultiplexer Connection()
        {
            return _connection.Value;
        }
        public IEnumerable<RedisKey> GetKeys()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(Configuration.RedisConnectionString);
            IEnumerable<RedisKey> keys = redis.GetServer(Configuration.RedisHost, Int16.Parse(Configuration.RedisPort)).Keys();
            return keys;
        }
    }
}
