using System;

namespace Venda.Api.Dto.Result
{
    public class EstoqueResult
    {
        public Guid EstoqueId {get; set;}
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}