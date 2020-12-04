using System;

namespace Venda.Api.Dto.Result
{
    public class ProdutoResult
    {
        public Guid produtoId { get; set;}
        public string descricao { get; set; }
        public decimal preco { get; set; }
        public string nome { get; set; }
        public int quantidade { get; set; }
    }
}