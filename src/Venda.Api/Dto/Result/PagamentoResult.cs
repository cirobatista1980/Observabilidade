using System;

namespace Venda.Api.Dto.Result
{
    public class PagamentoResult
    {
        public Guid PagamentoId { get;  set; }
        public string NumeroCartao { get;  set; }
        public int NumeroParcelas { get;  set; }
        public decimal Total { get;  set; }
        public decimal ValorParcelas { get;  set; }
    }
}