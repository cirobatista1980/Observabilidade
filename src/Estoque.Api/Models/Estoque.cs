using System;

namespace Estoque.Api.Models
{
    public class Estoque
    {
        public Guid Id {get;private set;}
        public Guid ProdutoId { get; private set; }
        public int Quantidade { get; private set; }
        public void Reduzir(int _quantidade)
        {
            if(Quantidade == 0)
               throw new Exception("Estoque zerado");
            
            Quantidade -= _quantidade;
        }
        public void Aumentar(int _quantidade) => Quantidade += _quantidade;
        public Estoque(Guid _produtoId, int _quantidade)
        {
            Id = Guid.NewGuid();
            ProdutoId = _produtoId;
            Quantidade = _quantidade;
            Validar();
        }
        public Estoque(Guid _id, Guid _produtoId, int _quantidade)
        {
            Id = _id;
            ProdutoId = _produtoId;
            Quantidade = _quantidade;
            Validar();
        }

        private void Validar(){
            if (Quantidade <= 0)
                throw new ArgumentNullException("A quantidade deve ser maior que zero");
        }
    }
}