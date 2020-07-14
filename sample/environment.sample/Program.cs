using environment.net.core;
using Microsoft.Extensions.Configuration;
using System;

namespace environment.sample
{
    class Program
    {
        static void Main(string[] args)
        {
            EnvironmentManager environmentManager = EnvironmentManager.Instance;
            IConfiguration configuration = environmentManager.GetConfiguration();
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));
            string ipAddress = (string)configuration.GetValue(typeof(string), "database-ip");
            Console.WriteLine($"Ip Address : {ipAddress}");
            Console.ReadKey();
        }
    }
}
