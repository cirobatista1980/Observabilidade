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
    [Route("api/[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _vendaService;
        private readonly ILogger _logger;
        public VendaController(IVendaService vendaService, ILogger<VendaController> logger)
        {
            _vendaService = vendaService;
            _logger = logger;
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
                _logger.LogError(ex.ToString());
                return BadRequest($"Erro => {ex.Message}");
            }
            finally
            {
                transaction.End();
            }
        }
    }
}
