using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchNameInfrastructure.Configurations
{
    static class Configuration
    {
        static public string WebRequestURL
        {
            get
            {
                return GetName("WebRequestURL");
            }
        }
        static public string RedisConnectionString { get { return GetName("RedisConnectionString"); } }
        static public string RedisHost { get { return GetName("RedisHost"); } }
        static public string RedisPort { get { return GetName("RedisPort"); } }
        static private string GetName(string name)
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../SearchNameAPI"));
            configurationManager.AddJsonFile("appsettings.json");
            return configurationManager.GetConnectionString(name);
        }
    }
}
