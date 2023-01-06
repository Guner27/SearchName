using Microsoft.Extensions.DependencyInjection;
using SearchName.Application;
using SearchName.Application.Configurations;
using SearchName.Application.Redis;
using SearchName.Application.WebRequests;
using SearchNameInfrastructure.Configurations;
using SearchNameInfrastructure.Redis;
using SearchNameInfrastructure.WebRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchNameInfrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<IRedisConnectionFactory, RedisConnectionFactory>();
            services.AddSingleton<ICacheSevice, RedisCacheManager>();
            services.AddSingleton<IWebRequestName,WebRequestName>();
            services.AddSingleton<IRequests,Requests>();
        }
    }
}
