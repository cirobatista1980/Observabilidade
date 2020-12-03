using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Estoque.Api.Dto.Result;
using Estoque.Api.Dto.Signature;

namespace Estoque.Api.Services.Interfaces
{
    public interface IProdutoService
    {
        Task InserirAsync(ProdutoSignature signature);
        Task AtualizarAsync(ProdutoSignature signature);
        Task<ProdutoResult> ObterPorIdAsync(Guid produtoId);
        Task<List<ProdutoResult>> ObterTodosAsync();
    }
}