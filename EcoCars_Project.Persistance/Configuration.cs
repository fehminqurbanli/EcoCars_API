using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoCars_Project.Persistance
{
    public static class Configuration
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../EcoCars/EcoCars_Project.API"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
            }
        }
    }
}
