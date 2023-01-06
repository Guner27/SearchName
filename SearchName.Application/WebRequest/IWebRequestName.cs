using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchName.Application.WebRequests
{
    public interface IWebRequestName
    {
        T Get<T>(string key);
        int Count(string key);
        string StageOfLife(string key);
    }
}
