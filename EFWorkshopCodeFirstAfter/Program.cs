using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EFWorkshopCodeFirstConfigurations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var appRunner = ActivatorUtilities.CreateInstance<AppRunner>(host.Services);

            appRunner.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<AppRunner>();
                });
    }
}
