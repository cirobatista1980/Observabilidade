namespace Pagamento.Api.Dto.Signature
{
    public class PagamentoSignature
    {
        public string NumeroCartao { get; set; }
        public int NumeroParcelas { get; set; }
        public decimal Total { get; set; }
    }
}