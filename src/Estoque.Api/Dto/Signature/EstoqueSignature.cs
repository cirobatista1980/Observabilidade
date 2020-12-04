using System;

namespace Estoque.Api.Dto.Signature
{
    public class EstoqueSignature
    {
        public Guid EstoqueId {get;set;}
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}