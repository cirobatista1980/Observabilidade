using System.Threading.Tasks;
using Pagamento.Api.Dto.Result;
using Pagamento.Api.Dto.Signature;
using Pagamento.Api.Repository.Interfaces;
using Pagamento.Api.Services.Converters;
using Pagamento.Api.Services.Interfaces;

namespace Pagamento.Api.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IPagamentoRepository _pagamentoRepository;

        public PagamentoService(IPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }

        public async Task<PagamentoResult> InserirAsync(PagamentoSignature signature)
        {
            var pagamento = new Models.Pagamento(signature.NumeroCartao, signature.NumeroParcelas, signature.Total);
            
            if(!pagamento.ValidarCartao())
                throw new System.ArgumentException("Cartão de crédito inválido");

            await _pagamentoRepository.InserirAsync(pagamento);

            return pagamento.ToResult();
        }

        
    }
}