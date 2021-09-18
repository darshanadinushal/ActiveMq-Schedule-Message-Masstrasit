using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Sample.Application.Lib.Infra.Extensions;

namespace Sample.Application.Consumer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseLogging()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
