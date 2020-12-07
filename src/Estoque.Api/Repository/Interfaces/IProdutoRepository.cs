using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estoque.Api.Repository.Interfaces
{
    public interface IProdutoRepository
    {
        Task InserirAsync(Models.Produto produto);
        Task AtualizarAsync(Models.Produto produto);
        Task<Models.Produto> ObterPorIdAsync(Guid produtoId);
        Task<List<Models.Produto>> ObterTodosAsync();
    }
}