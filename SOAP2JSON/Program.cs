using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Web;
using SOAP2JSON.Data;
using SOAP2JSON.Model;

namespace SOAP2JSON
{
    public class Program
    {
       

        public static void Main(string[] args)
        {
          
            var WebHostBuilder = CreateWebHostBuilder(args).Build();
            using (var scope = WebHostBuilder.Services.CreateScope())
            {
                using (var codb = scope.ServiceProvider.GetRequiredService<ValuesContext>())
                {
                    var transaction = codb.Database.BeginTransaction();

                    try
                    {

                        for (int i = 1; i <= 4; i++)
                        {
                            if (!codb.LogData1s.Any(m => m.Id == i))
                            {
                                codb.LogData1s.Add(new LogData1
                                {
                                    Id = i,
                                    InsertDate = DateTime.Now,
                                });
                            }
                        }

                        codb.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw e;
                    }
                    finally
                    {
                        transaction.Dispose();
                    }
                }
            }
            WebHostBuilder.Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
         WebHost.CreateDefaultBuilder(args)
             .UseStartup<Startup>()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Trace);
                })
                  .UseNLog();


    }

       
    }

