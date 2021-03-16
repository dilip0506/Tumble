using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NLog.Web;
using Microsoft.Extensions.Logging;

namespace Tumble.Api
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var logger = NLogBuilder.ConfigureNLog($"nlog.{environment}.config").GetCurrentClassLogger();
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                //NLog: catch setup errors
                logger.Error(ex, "Stopped program because of exception");
                throw ex;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
               .ConfigureAppConfiguration((hostingContext, config) =>
               {
                   config.Sources.Clear();

                   var env = hostingContext.HostingEnvironment;

                   config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                         .AddJsonFile($"appsettings.{env.EnvironmentName}.json",
                                        optional: true, reloadOnChange: true);
                   config.AddEnvironmentVariables();
               })
               .ConfigureWebHostDefaults((webBuilder) =>
               {
                    webBuilder.UseStartup<Startup>()
#if !DEBUG
                            .UseKestrel()
#endif
                            .UseContentRoot(Directory.GetCurrentDirectory())
                            .UseIISIntegration();
               })
               .ConfigureLogging(logging =>
               {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Trace);
               })
               .UseNLog();
    }
}
