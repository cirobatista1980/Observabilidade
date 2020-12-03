using System;
using System.Threading.Tasks;
using Estoque.Api.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Estoque.Api.Repository
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly Contexto _contexto;
        public EstoqueRepository(IConfiguration configuration)
        {
            _contexto = new Contexto(configuration);
        }
        public async Task AtualizarAsync(Models.Estoque estoque)
        {
            var filtro = Builders<Models.Estoque>.Filter.Eq(x => x.ProdutoId, estoque.ProdutoId);

            var updateDefinition = Builders<Models.Estoque>.Update.Set(x => x.Quantidade, estoque.Quantidade);

            await _contexto.Estoque.UpdateOneAsync(filtro, updateDefinition);
        }

        public async Task InserirAsync(Models.Estoque estoque)
        {
            await _contexto.Estoque.InsertOneAsync(estoque);
        }

        public async Task<Models.Estoque> ObterPorIdAsync(Guid produtoId)
        {
            return await _contexto.Estoque.AsQueryable().Where(item => item.ProdutoId == produtoId).FirstOrDefaultAsync();
        }
    }
}