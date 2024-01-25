using Microsoft.Extensions.Configuration;

namespace GrpcClient
{
    class Configuration
    {
        public string ServerAddress { get; }

        public Configuration()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = configBuilder.Build();
            ServerAddress = configuration["ServerAddress"];
        }
    }
}
