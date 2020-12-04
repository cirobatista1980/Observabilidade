using Estoque.Api.Repository;
using Estoque.Api.Repository.Interfaces;
using Estoque.Api.Services;
using Estoque.Api.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Estoque.Api.Configuration
{
    public static class DependencyResolverConfiguration
    {
        public static IServiceCollection IntegrateDependencyResolver(this IServiceCollection services)
        {
            services.AddScoped<IEstoqueRepository, EstoqueRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            
            return services;
        }
    }
}