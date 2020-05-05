using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace PrimeAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.AzureAnalytics(workspaceId: "26ad584a-adb2-4c8a-9339-c9777999f169",
                            authenticationId: "hZlzRkQdSebh1lcIZP/wJGi5vR72XJIsFa5+FMNdB8cCx2zOtaVSccQ3JGIizQsNbQ5KJWCCmYxht77gvQwc8A==")
            .CreateLogger();
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
