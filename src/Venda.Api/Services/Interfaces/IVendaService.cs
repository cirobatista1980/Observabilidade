using System.Threading.Tasks;
using Venda.Api.Dto.Signature;

namespace Venda.Api.Services.Interfaces
{
    public interface IVendaService
    {
         Task InserirAsync(VendaSignature signature);
    }
}