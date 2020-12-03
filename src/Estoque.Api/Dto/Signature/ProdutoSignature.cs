using System;

namespace Estoque.Api.Dto.Signature
{
    public class ProdutoSignature
    {
        public Guid ProdutoId { get; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
    }
}