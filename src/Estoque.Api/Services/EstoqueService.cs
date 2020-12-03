using System;
using System.Threading.Tasks;
using Estoque.Api.Dto.Result;
using Estoque.Api.Dto.Signature;
using Estoque.Api.Repository.Interfaces;
using Estoque.Api.Services.Converters;
using Estoque.Api.Services.Interfaces;

namespace Estoque.Api.Services
{
    public class EstoqueService : IEstoqueService
    {
        protected readonly IEstoqueRepository _estoqueRepository;

        public EstoqueService(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }

        public async Task<EstoqueResult> AtualizarAsync(EstoqueSignature signature)
        {
            var itemEstoque = await _estoqueRepository.ObterPorIdAsync(signature.ProdutoId);

            if (itemEstoque == null)
                return null;

            var estoque = new Models.Estoque(itemEstoque.EstoqueId, signature.ProdutoId, signature.Quantidade);

            estoque.Aumentar(signature.Quantidade);

            await _estoqueRepository.AtualizarAsync(estoque);

            return estoque.ToResult();
        }

        public async Task InserirAsync(EstoqueSignature signature)
        {
            var estoque = new Models.Estoque(signature.ProdutoId, signature.Quantidade);

            var existe = await _estoqueRepository.ObterPorIdAsync(estoque.ProdutoId);

            if (existe == null)
                throw new ArgumentNullException("Já existe este produto em estoque. Você deve atualiar o estoque.");

            await _estoqueRepository.InserirAsync(estoque);
        }

        public async Task<EstoqueResult> ObterPorIdAsync(Guid produtoId)
        {
            var retorno = await _estoqueRepository.ObterPorIdAsync(produtoId);
            return retorno.ToResult();
        }
    }
}