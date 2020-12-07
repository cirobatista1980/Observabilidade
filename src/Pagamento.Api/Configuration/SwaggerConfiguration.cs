using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Pagamento.Api.Configuration
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection IntegrateSswagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API de Pagamentos",
                    Version = "v1",
                    Description = "API de Pagamentos",
                    Contact = new OpenApiContact
                    {
                        Email = @"ciro.batista.1980@gmail.com",
                        Name = "Ciro Batista",
                        Url = new Uri(@"https://www.linkedin.com/in/ciro-batista-33b97235/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Ciro Batista",
                        Url = new Uri(@"https://github.com/cirobatista1980/Observabilidade")
                    }
                });
            });

            return services;
        }
    }
}