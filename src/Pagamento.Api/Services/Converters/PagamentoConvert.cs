using Pagamento.Api.Dto.Result;

namespace Pagamento.Api.Services.Converters
{
    public static class PagamentoConvert
    {
        public static PagamentoResult ToResult(this Models.Pagamento result)
        {
            return new PagamentoResult()
            {
                NumeroCartao = result.NumeroCartao,
                NumeroParcelas = result.NumeroParcelas,
                PagamentoId = result.PagamentoId,
                Total = result.Total,
                ValorParcelas = result.ValorParcelas
            };
        }
    }
}