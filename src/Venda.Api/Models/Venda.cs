using System;
using System.Collections.Generic;

namespace Venda.Api.Models
{
    public class Venda
    {
        public Guid VendaId { get; private set; }
        public List<Produto> Produtos { get; private set; } = new List<Produto>();
        public Pagamento Pagamento { get; private set; }
        public Venda(Pagamento _pagamento)
        {
            Pagamento = _pagamento;
            VendaId = Guid.NewGuid();
        }
        public void AdicionarProdutos(List<Produto> _produtos)
        {
            Produtos = _produtos;
        }
    }
}