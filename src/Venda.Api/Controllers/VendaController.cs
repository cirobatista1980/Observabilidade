using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elastic.Apm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Venda.Api.Dto.Signature;
using Venda.Api.Services.Interfaces;

namespace Venda.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _vendaService;

        public VendaController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] VendaSignature signature)
        {
            var transaction = Agent.Tracer.StartTransaction("Realizando uma venda", "Requisição");
            try
            {
                await _vendaService.InserirAsync(signature);
                return Created("", "");
            }
            catch (Exception ex)
            {
                transaction.CaptureException(ex);
                return BadRequest($"Erro => {ex.Message}");
            }
            finally
            {
                transaction.End();
            }
        }
    }
}
