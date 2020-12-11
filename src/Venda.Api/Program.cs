using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elastic.CommonSchema.Serilog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace Venda.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog((ctx, config) =>
                {
                    config.ReadFrom.Configuration(ctx.Configuration);

                    // Ensure HttpContextAccessor is accessible
                    var httpAccessor = ctx.Configuration.Get<HttpContextAccessor>();

                    // Create a formatter configuration to se this accessor
                    var formatterConfig = new EcsTextFormatterConfiguration();
                    formatterConfig.MapHttpContext(httpAccessor);

                    // Write events to the console using this configration
                    var formatter = new EcsTextFormatter(formatterConfig);

                    config.WriteTo.Console(formatter);


                    config.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(ctx.Configuration["ElasticConfiguration:Uri"]))
                    {
                        CustomFormatter = formatter
                    });
                });
    }
}
