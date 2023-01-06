using SearchName.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchName.Application.Redis
{
    public interface ICacheSevice
    {
        T Get<T>(string key);
        void Add(string key, object data);
        void Remove(string key);
        bool Any(string key);
        List<Table> GetAllDatas();
        int AverageAge();
        string StageOfLife();
    }
}
