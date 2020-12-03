using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pagamento.Api.Dto.Result;
using Pagamento.Api.Dto.Signature;
using Pagamento.Api.Services.Interfaces;

namespace Pagamento.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoService _pagamentoService;
        public PagamentoController(IPagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PagamentoResult), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] PagamentoSignature signature)
        {
            try
            {
                var pagamento = await _pagamentoService.InserirAsync(signature);
                return Created("", pagamento);
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Pagamento => {ex.Message}");
            }
        }
    }
}
