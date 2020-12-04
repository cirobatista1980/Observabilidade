using System.Collections.Generic;
using System.Linq;
using Estoque.Api.Dto.Result;

namespace Estoque.Api.Services.Converters
{
    public static class ProdutoConvert
    {
        public static ProdutoResult ToResult(this Models.Produto result)
        {
            return new ProdutoResult()
            {
                ProdutoId = result.Id,
                Descricao = result.Descricao,
                Nome = result.Nome,
                Preco = result.Preco,
                Quantidade = result.Quantidade
            };
        }

        public static List<ProdutoResult> ToResult(this List<Models.Produto> result)
        {
            return result.Select(x => new ProdutoResult()
            {
                ProdutoId = x.Id,
                Descricao = x.Descricao,
                Nome = x.Nome,
                Preco = x.Preco,
                Quantidade = x.Quantidade
            }).ToList();
        }
    }
}