using System;

namespace Venda.Api.Dto.Result
{
    public class ProdutoResult
    {
        public Guid ProdutoId { get; set;}
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
    }
}