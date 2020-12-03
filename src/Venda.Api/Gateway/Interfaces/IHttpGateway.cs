using System;
using System.Threading.Tasks;
using Venda.Api.Models;

namespace Venda.Api.Gateway.Interfaces
{
    public interface IHttpGateway<TI, TR>
    {
        Task<ResponseModel<TR>> PostAsync(string url, TI signature);
        Task<ResponseModel<TR>> PutAsync(string url, Guid id, TI signature);
        Task<ResponseModel<TR>> GetAsync(string url, Guid id);
        Task<ResponseModel<TR>> GetAllAsync(string url);
    }
}