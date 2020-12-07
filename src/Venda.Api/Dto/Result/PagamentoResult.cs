using System;

namespace Venda.Api.Dto.Result
{
    public class PagamentoResult
    {
        public Guid pagamentoId { get;  set; }
        public string numeroCartao { get;  set; }
        public int numeroParcelas { get;  set; }
        public decimal total { get;  set; }
        public decimal valorParcelas { get;  set; }
    }
}