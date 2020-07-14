using Microsoft.Extensions.Configuration;

namespace environment.net.core
{
    public interface IEnvironmentManager
    {
        string GetEnvironment();
        IConfiguration GetConfiguration();
        bool IsDevelopment();
        bool IsStaging();
        bool IsProduction();
    }
}
