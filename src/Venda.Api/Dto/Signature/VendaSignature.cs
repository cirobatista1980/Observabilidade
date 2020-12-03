using System;
using System.Collections.Generic;

namespace Venda.Api.Dto.Signature
{
    public class VendaSignature
    {
        public List<Guid> ProdutosId { get; set; }
        public PagamentoSignature Pagamento { get; set; }
    }
}