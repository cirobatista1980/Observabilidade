using System;
using System.Collections.Generic;

namespace Venda.Api.Models
{
    public class Venda
    {
        public Guid Id { get; private set; }
        public List<Produto> Produtos { get; private set; } = new List<Produto>();
        public Pagamento Pagamento { get; private set; }

        public void AdicionarProdutos(List<Produto> _produtos)
        {
            Produtos = _produtos;
        }
    }
}