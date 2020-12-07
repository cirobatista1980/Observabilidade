using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Estoque.Api.Models;
using Estoque.Api.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Estoque.Api.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly Contexto _contexto;

        public ProdutoRepository(IConfiguration configuration)
        {
            _contexto = new Contexto(configuration);
        }

        public async Task AtualizarAsync(Produto produto)
        {
            var filtro = Builders<Models.Produto>.Filter.Eq(x => x.Id, produto.Id);

            var updateDefinition = Builders<Models.Produto>.Update.Set(x => x.Descricao, produto.Descricao);

            await _contexto.Produto.UpdateOneAsync(filtro, updateDefinition);
        }

        public async Task InserirAsync(Produto produto)
        {
            await _contexto.Produto.InsertOneAsync(produto);
        }

        public async Task<Produto> ObterPorIdAsync(Guid produtoId)
        {
            return await _contexto.Produto.AsQueryable().Where(item => item.Id == produtoId).FirstOrDefaultAsync();
        }

        public async Task<List<Produto>> ObterTodosAsync()
        {
            return await _contexto.Produto.AsQueryable().ToListAsync();
        }
    }
}