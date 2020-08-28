using Microsoft.Extensions.Configuration;
using System;

namespace environment.net.core
{
    public class EnvironmentManager : IEnvironmentManager
    {
        private static EnvironmentManager _environmentManager;

        private EnvironmentManager()
        {
            GetEnvironment();
        }
        private static object _lock = new object();
        public static EnvironmentManager Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_environmentManager == null)
                        _environmentManager = new EnvironmentManager();
                    return _environmentManager;
                }                
            }
        }

        private string environment { get; set; }
        private IConfiguration configuration { get; set; }

        public IConfiguration GetConfiguration()
        {
            if (configuration == null)
            {
                var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.{environment}.json", true, true);
                configuration = builder.Build();
            }
            return configuration;
        }

        public string GetEnvironment()
        {
            if (String.IsNullOrEmpty(environment))
            {
                try
                {
                    environment = Environment.GetEnvironmentVariable("MODE").ToLower();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return environment;
        }

        public bool IsDevelopment() => environment == "development" ? true : false;

        public bool IsProduction() => environment == "production" ? true : false;

        public bool IsStaging() => environment == "staging" ? true : false;        
    }
}
