using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobApplying.Models;
using JobApplying.Models.Validators;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace JobApplying
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webHost=CreateHostBuilder(args).Build();
            Migrate(webHost);
            webHost.Run();
            
        }
        private static void Migrate(IHost webHost)
        {
            using(IServiceScope scope = webHost.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                Microsoft.EntityFrameworkCore.Infrastructure.DatabaseFacade database = db.Database;
                database.Migrate();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}