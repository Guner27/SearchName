using SearchName.Application;
using SearchName.Application.Redis;
using SearchName.Application.WebRequests;
using SearchName.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SearchNameInfrastructure
{
    public class Requests : IRequests
    {
        private readonly ICacheSevice _cacheService;
        private readonly IWebRequestName _webReques;

        public Requests(ICacheSevice cacheService,IWebRequestName webReques)
        {
            _cacheService = cacheService;
            _webReques = webReques;
        }

        public string Request1(string key) {
            string response = key + Environment.NewLine;
            string colomn2 = "Bizim sitemde isim vardır. \n";
            bool isThere = _cacheService.Any(key);

            if (!isThere)
            {
                colomn2 = "Bizim sistemde isim yok.(Ama Eklendi) \n";
                Table addTable = _webReques.Get<Table>(key);
                _cacheService.Add(key, addTable);
            }
            response = response + colomn2;

            int count = _webReques.Count(key);
            string piece = "Dünyada " + count + " adet bulunmaktadır.\n";
            response = response + piece;

            string stageOfLide = _webReques.StageOfLife(key);
            response = response + "Adınızdaki kişiler dünyada hayatın " + stageOfLide + " bölümündedir.\n";

            int localAverage = _cacheService.AverageAge();
            response = response + "Sistemdeki kişilerin ortalama yaşı: " + localAverage;
            
            return response;
        }

        public string Request2()
        {
            string response = "";
            int localAverage = _cacheService.AverageAge();
            response = response + "Sistemdeki kişilerin ortalama yaşı: " + localAverage + Environment.NewLine;

            string localStageOfLife = _cacheService.StageOfLife();
            response = response + "sistemdeki kişiler hayatın, " + localStageOfLife + " evresindeler.";
            return response;
        }
        public List<Table> RedisTop()
        {
            return _cacheService.GetAllDatas();
        }
    }
}
