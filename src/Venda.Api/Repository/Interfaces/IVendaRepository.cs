using System.Threading.Tasks;

namespace Venda.Api.Repository.Interfaces
{
    public interface IVendaRepository
    {
         Task InserirAsync(Models.Venda venda);
    }
}