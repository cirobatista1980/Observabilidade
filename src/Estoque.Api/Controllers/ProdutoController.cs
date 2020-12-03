using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Estoque.Api.Dto.Result;
using Estoque.Api.Dto.Signature;
using Estoque.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] ProdutoSignature produto)
        {
            try
            {
                await _produtoService.InserirAsync(produto);
                return Created("", "");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro => {ex.Message}");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProdutoResult>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _produtoService.ObterTodosAsync());
        }
    }
}