using System;
using System.Threading.Tasks;
using Estoque.Api.Dto.Result;
using Estoque.Api.Dto.Signature;
using Estoque.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace Estoque.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService _estoqueService;
        private readonly ILogger _logger;
        public EstoqueController(IEstoqueService estoqueService, ILogger<EstoqueController> logger)
        {
            _estoqueService = estoqueService;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] EstoqueSignature signature)
        {
            try
            {
                await _estoqueService.InserirAsync(signature);
                return Created("", "");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Erro ao adicionar estoque");
                return BadRequest($"Erro => {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(EstoqueResult), 202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Put(Guid id, [FromBody] EstoqueSignature signature)
        {
            try
            {
                var retorno = await _estoqueService.AtualizarAsync(signature);

                if (retorno == null)
                    return NotFound();

                return Accepted("", retorno);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Erro ao alterar estoque");
                return BadRequest($"Erro => {ex.Message}");
            }
        }
    }
}