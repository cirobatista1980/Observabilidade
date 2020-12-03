using System;

namespace Estoque.Api.Models
{
    public class Produto
    {
        public Guid ProdutoId { get; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public string Nome { get; private set; }
        public int Quantidade { get; private set; }
        public Produto(string _nome, string _descricao, decimal _preco, int _qtd)
        {
            ProdutoId = Guid.NewGuid();
            Descricao = _descricao;
            Preco = _preco;
            Nome = _nome;
            Quantidade = _qtd;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Descricao))
                throw new ArgumentNullException("Descrição do produto é obrigatório");

            if (Preco < 0)
                throw new ArgumentNullException("O preço não pode ser negativo");

            if (Quantidade < 0)
                throw new ArgumentNullException("A quantidade não pode ser negativa");
        }
    }
}