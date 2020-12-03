using System;
using System.Threading.Tasks;
using Estoque.Api.Dto.Result;
using Estoque.Api.Dto.Signature;

namespace Estoque.Api.Services.Interfaces
{
    public interface IEstoqueService
    {
        Task InserirAsync(EstoqueSignature signature);
        Task<EstoqueResult> AtualizarAsync(EstoqueSignature signature);
        Task<EstoqueResult> ObterPorIdAsync(Guid produtoId);
    }
}