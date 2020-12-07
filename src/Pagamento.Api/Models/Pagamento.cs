using System;

namespace Pagamento.Api.Models
{
    public class Pagamento
    {
        public Guid PagamentoId { get; private set; }
        public string NumeroCartao { get; private set; }
        public int NumeroParcelas { get; private set; }
        public decimal Total { get; private set; }
        public decimal ValorParcelas { get; private set; }

        public Pagamento(Guid pagamentoId, string numeroCartao, int numeroParcelas, decimal total)
        {
            this.PagamentoId = pagamentoId;
            this.NumeroCartao = numeroCartao;
            this.NumeroParcelas = numeroParcelas;
            this.Total = total;
            CalcularParcelas();
        }
        public Pagamento(string numeroCartao, int numeroParcelas, decimal total)
        {
            this.PagamentoId = Guid.NewGuid();
            this.NumeroCartao = numeroCartao;
            this.NumeroParcelas = numeroParcelas;
            this.Total = total;
            CalcularParcelas();
        }
        public bool ValidarCartao()
        {
            var valido = true;

            if (NumeroCartao.Equals("1234567890123456") || NumeroCartao.Length < 16)
                valido = false;

            return valido;
        }

        private void CalcularParcelas()
        {
            ValorParcelas = Total;

            //if (NumeroParcelas > 0)
                ValorParcelas = Total / NumeroParcelas;

        }
    }
}