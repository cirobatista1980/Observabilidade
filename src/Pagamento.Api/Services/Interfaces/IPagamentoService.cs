using System.Threading.Tasks;
using Pagamento.Api.Dto.Result;
using Pagamento.Api.Dto.Signature;

namespace Pagamento.Api.Services.Interfaces
{
    public interface IPagamentoService
    {
         Task<PagamentoResult> InserirAsync(PagamentoSignature signature);
    }
}