using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace PunishmentPointsApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration(loadConfiguration)
                .UseStartup<Startup>()
                .Build()
                .Run();
        }

        private static void loadConfiguration(WebHostBuilderContext builderContext, IConfigurationBuilder config)
        {
            IHostingEnvironment env = builderContext.HostingEnvironment;
            config
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
        }
    }
}