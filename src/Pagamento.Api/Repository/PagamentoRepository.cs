using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Pagamento.Api.Repository.Interfaces;

namespace Pagamento.Api.Repository
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly Contexto _contexto;

        public PagamentoRepository(IConfiguration configuration)
        {
            _contexto = new Contexto(configuration);
        }
        public async Task InserirAsync(Models.Pagamento pagamento)
        {
            await _contexto.Pagamento.InsertOneAsync(pagamento);
        }
    }
}