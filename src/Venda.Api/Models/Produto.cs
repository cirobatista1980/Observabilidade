using System;

namespace Venda.Api.Models
{
    public class Produto
    {
        public Guid ProdutoId { get; }
        public string Descricao { get; private set; }
        public decimal Preco { get; set; }
        public Produto(string _descricao, decimal _preco)
        {
            ProdutoId = Guid.NewGuid();
            Descricao = _descricao;
            Preco = _preco;
            Validar();
        }
        private void Validar()
        {
            if (string.IsNullOrEmpty(Descricao))
                throw new ArgumentNullException("Descrição do produto é obrigatório");

            if (Preco < 0)
                throw new ArgumentNullException("O preço não pode ser negativo");

        }
    }
}