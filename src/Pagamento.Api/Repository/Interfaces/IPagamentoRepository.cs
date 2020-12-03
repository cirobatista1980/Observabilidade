using System.Threading.Tasks;

namespace Pagamento.Api.Repository.Interfaces
{
    public interface IPagamentoRepository
    {
         Task InserirAsync(Models.Pagamento pagamento);
    }
}