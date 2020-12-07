using System;
using System.Threading.Tasks;

namespace Estoque.Api.Repository.Interfaces
{
    public interface IEstoqueRepository
    {
        Task InserirAsync(Models.Estoque estoque);
        Task AtualizarAsync(Models.Estoque estoque);
        Task<Models.Estoque> ObterPorIdAsync(Guid produtoId);
    }
}