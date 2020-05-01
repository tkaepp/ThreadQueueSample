using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ThreadQueueSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            Console.WriteLine("https://github.com/dotnet/diagnostics/blob/master/documentation/dotnet-counters-instructions.");
            Console.WriteLine($"dotnet-counters monitor -p {Process.GetCurrentProcess().Id} System.Runtime Microsoft.AspNetCore.Hosting");
            Console.WriteLine($"dotnet-counters collect --process-id {Process.GetCurrentProcess().Id} --output mycounter --format csv System.Runtime Microsoft.AspNetCore.Hosting");

            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}