using Estoque.Api.Dto.Result;

namespace Estoque.Api.Services.Converters
{
    public static class EstoqueConvert
    {
        public static EstoqueResult ToResult(this Models.Estoque result)
        {
            return new EstoqueResult()
            {
                EstoqueId = result.Id,
                ProdutoId = result.ProdutoId,
                Quantidade = result.Quantidade
            };
        }
    }
}