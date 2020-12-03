using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Venda.Api.Dto.Result;
using Venda.Api.Dto.Signature;
using Venda.Api.Gateway.Interfaces;
using Venda.Api.Models;
using Venda.Api.Repository.Interfaces;
using Venda.Api.Services.Interfaces;

namespace Venda.Api.Services
{
    public class VendaService : IVendaService
    {
        private string urlPagamento = string.Empty;
        private string urlEstoque = string.Empty;
        private string urlProduto = string.Empty;
        private readonly IVendaRepository _vendaRepository;
        private readonly IHttpGateway<PagamentoSignature, PagamentoResult> _pagamentoGateway;
        private readonly IHttpGateway<EstoqueSignature, EstoqueResult> _estoqueGateway;
        private readonly IHttpGateway<ProdutoSignature, ProdutoResult> _produtoGateway;
        public VendaService(
            IConfiguration configuration,
            IVendaRepository vendaRepository,
            IHttpGateway<PagamentoSignature, PagamentoResult> pagamentoGateway,
            IHttpGateway<EstoqueSignature, EstoqueResult> estoqueGateway
        )
        {
            _vendaRepository = vendaRepository;
            _pagamentoGateway = pagamentoGateway;
            _estoqueGateway = estoqueGateway;

            urlPagamento = configuration.GetSection("Pagamento").Value;
            urlEstoque = configuration.GetSection("Estoque").Value;
            urlProduto = configuration.GetSection("Produto").Value;
            
        }

        public async Task InserirAsync(VendaSignature signature)
        {
            var produtos = new List<Produto>();
            var total = 0.00M;

            if (!signature.ProdutosId.Any())
                throw new Exception("Para a venda, é necessário ao menos informar um produto");


            foreach (var produtoId in signature.ProdutosId)
            {
                var produtoResult = await _produtoGateway.GetAsync(urlProduto, produtoId).ConfigureAwait(false);

                if (!produtoResult.Sucesso)
                    throw new Exception(produtoResult.MessagemErro);

                var estoque = new EstoqueSignature()
                {
                    ProdutoId = produtoId,
                    Quantidade = 1
                };

                var estoqueResult = await _estoqueGateway.PutAsync(urlEstoque, produtoId, estoque).ConfigureAwait(false);

                if (!estoqueResult.Sucesso)
                    throw new Exception(estoqueResult.MessagemErro);

                produtos.Add(new Produto(produtoResult.ObjectToSerialize.Descricao,produtoResult.ObjectToSerialize.Preco));

                total += produtoResult.ObjectToSerialize.Preco;
            }

            var pagamento = new PagamentoSignature()
            {
                NumeroCartao = signature.Pagamento.NumeroCartao,
                NumeroParcelas = signature.Pagamento.NumeroParcelas,
                Total = total
            };

            var response = await _pagamentoGateway.PostAsync(urlPagamento, pagamento).ConfigureAwait(false);

            if (!response.Sucesso)
                throw new Exception(response.MessagemErro);


            var venda = new Models.Venda(new Pagamento(response.ObjectToSerialize.PagamentoId,
                                                response.ObjectToSerialize.NumeroCartao,
                                                response.ObjectToSerialize.NumeroParcelas,
                                                response.ObjectToSerialize.Total));
            venda.AdicionarProdutos(produtos);

            await _vendaRepository.InserirAsync(venda).ConfigureAwait(false);
        }
    }
}