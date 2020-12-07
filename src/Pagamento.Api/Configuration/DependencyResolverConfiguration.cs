using Microsoft.Extensions.DependencyInjection;
using Pagamento.Api.Repository;
using Pagamento.Api.Repository.Interfaces;
using Pagamento.Api.Services;
using Pagamento.Api.Services.Interfaces;

namespace Pagamento.Api.Configuration
{
    public static class DependencyResolverConfiguration
    {
        public static IServiceCollection IntegrateDependencyResolver(this IServiceCollection services)
        {
            services.AddScoped<IPagamentoService, PagamentoService>();
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            
            return services;
        }
    }
}