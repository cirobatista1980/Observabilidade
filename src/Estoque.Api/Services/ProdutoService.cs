using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Estoque.Api.Dto.Result;
using Estoque.Api.Dto.Signature;
using Estoque.Api.Models;
using Estoque.Api.Repository.Interfaces;
using Estoque.Api.Services.Converters;
using Estoque.Api.Services.Interfaces;

namespace Estoque.Api.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        protected readonly IEstoqueRepository _estoqueRepository;
        public ProdutoService(IProdutoRepository produtoRepository, IEstoqueRepository estoqueRepository)
        {
            _produtoRepository = produtoRepository;
            _estoqueRepository = estoqueRepository;
        }

        public async Task AtualizarAsync(ProdutoSignature signature)
        {
            var produto = new Models.Produto(signature.Nome, signature.Descricao, signature.Preco, signature.Quantidade);

            await _produtoRepository.AtualizarAsync(produto);
        }

        public async Task InserirAsync(ProdutoSignature signature)
        {
            var produto = new Models.Produto(signature.Nome, signature.Descricao, signature.Preco, signature.Quantidade);

            await _produtoRepository.InserirAsync(produto).ConfigureAwait(false);

            var estoque = await _estoqueRepository.ObterPorIdAsync(produto.Id);

            if (estoque == null)
            {
                if (produto.Quantidade <= 0)
                    throw new ArgumentNullException("Quantidade de estoque necessita ser maior que zero");

                estoque = new Models.Estoque(Guid.NewGuid(), produto.Id, produto.Quantidade);

                await _estoqueRepository.InserirAsync(estoque).ConfigureAwait(false);
            }
            else
            {
                estoque.Aumentar(produto.Quantidade);
                await _estoqueRepository.AtualizarAsync(estoque);
            }

        }

        public async Task<ProdutoResult> ObterPorIdAsync(Guid produtoId)
        {
            var retorno = await _produtoRepository.ObterPorIdAsync(produtoId);
            return retorno.ToResult();
        }

        public async Task<List<ProdutoResult>> ObterTodosAsync()
        {
            var retorno =  await _produtoRepository.ObterTodosAsync();
            return retorno.ToResult();
        }
    }
}