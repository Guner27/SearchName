using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchName.Application.Configurations
{
    public interface IRedisConnectionFactory
    {
        ConnectionMultiplexer Connection();
        public IEnumerable<RedisKey> GetKeys();
    }
}
