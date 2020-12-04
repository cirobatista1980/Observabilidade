using Microsoft.Extensions.DependencyInjection;
using Venda.Api.Gateway;
using Venda.Api.Gateway.Interfaces;
using Venda.Api.Repository;
using Venda.Api.Repository.Interfaces;
using Venda.Api.Services;
using Venda.Api.Services.Interfaces;

namespace Venda.Api.Configuration
{
    public static class DependencyResolverConfiguration
    {
        public static IServiceCollection IntegrateDependencyResolver(this IServiceCollection services)
        {
            services.AddScoped<IVendaService, VendaService>();
            services.AddScoped<IVendaRepository, VendaRepository>();
            services.AddScoped(typeof(IHttpGateway<,>), typeof(HttpGateway<,>));
            return services;
        }
    }
}