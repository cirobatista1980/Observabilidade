using System;

namespace Estoque.Api.Dto.Signature
{
    public class EstoqueSignature
    {
        public Guid EstoqueId {get;set;}
        public Guid ProdutoId { get; private set; }
        public int Quantidade { get; private set; }
    }
}