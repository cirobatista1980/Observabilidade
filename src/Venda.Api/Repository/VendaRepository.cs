using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Venda.Api.Repository.Interfaces;

namespace Venda.Api.Repository
{
    public class VendaRepository : IVendaRepository
    {
        private readonly Contexto _contexto;
        public VendaRepository(IConfiguration configuration)
        {
            _contexto = new Contexto(configuration);
        }
        public async Task InserirAsync(Models.Venda venda)
        {
            await _contexto.Venda.InsertOneAsync(venda);
        }
    }
}