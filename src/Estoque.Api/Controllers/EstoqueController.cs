using System;
using System.Threading.Tasks;
using Estoque.Api.Dto.Result;
using Estoque.Api.Dto.Signature;
using Estoque.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService _estoqueService;

        public EstoqueController(IEstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
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

                if(retorno == null)
                    return NotFound();

                return Accepted("",retorno);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro => {ex.Message}");
            }
        }
    }
}