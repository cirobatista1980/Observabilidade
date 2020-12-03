using System;

namespace Venda.Api.Dto.Signature
{
    public class EstoqueSignature
    {
        public int Quantidade { get; set; }
        public Guid ProdutoId{get;set;}
    }
}