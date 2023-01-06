using SearchName.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchName.Application
{
    public interface IRequests
    {
        string Request1(string key);
        string Request2();
        public List<Table> RedisTop();
    }
}
