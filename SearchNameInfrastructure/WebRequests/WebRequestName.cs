using Newtonsoft.Json;
using SearchName.Application.WebRequests;
using SearchName.Domain.Model;
using SearchNameInfrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SearchNameInfrastructure.WebRequests
{
    public class WebRequestName : IWebRequestName
    {

        public Table Get<Table>(string key)
        {
            string apiURL = Configuration.WebRequestURL + key;
            WebRequest request = WebRequest.Create(apiURL);
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();
            Table earthData = JsonConvert.DeserializeObject<Table>(json);
            return earthData;
        }
        public string StageOfLife(string key)
        {
            Table table = Get<Table>(key);
            return StageOfLifeCalculate.Calculate(table.age);
        }
        public int Count(string key)
        {
            Table table = Get<Table>(key) as Table;
            return table.count;
        }
    }
}
