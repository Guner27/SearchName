using Newtonsoft.Json;
using SearchName.Application.Configurations;
using SearchName.Application.Redis;
using SearchName.Domain.Model;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SearchNameInfrastructure.Redis
{
    public class RedisCacheManager : ICacheSevice
    {
        private readonly IRedisConnectionFactory _connection;
        private readonly IDatabase _database;

        public RedisCacheManager(IRedisConnectionFactory connection)
        {
            _connection = connection;
            _database = _connection.Connection().GetDatabase();
        }
        public void Add(string key, object data)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            _database.StringSet(key, jsonData);
        }
        public bool Any(string key)
        {
            return _database.KeyExists(key);
        }
        public T Get<T>(string key)
        {
            if (!Any(key))
                return default;
            string stringData = _database.StringGet(key);
            var result = JsonConvert.DeserializeObject<T>(stringData);
            return result;
        }
        public List<Table> GetAllDatas()
        {
            List<string> listKeys = new List<string>();
            List<Table> list = new List<Table>();
            listKeys.AddRange(_connection.GetKeys().Select(key => (string)key).ToList());
            foreach (var item in listKeys)
            {
                list.Add(Get<Table>(item));
            }
            return list;
        }
        public void Remove(string key)
        {
            _database.KeyDelete(key);
        }
        public int AverageAge()
        {
            List<Table> list = GetAllDatas();
            int top = 0;
            foreach (var table in list)
            {
                top = top + table.age;
            }
            int avarege = top / list.Count;
            return avarege;
        }
        public string StageOfLife()
        {
            int average = AverageAge();
            return StageOfLifeCalculate.Calculate(average);
        }
    }
}
