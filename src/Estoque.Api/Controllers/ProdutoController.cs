using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Elastic.Apm;
using Estoque.Api.Dto.Result;
using Estoque.Api.Dto.Signature;
using Estoque.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Estoque.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly ILogger _logger;
        public ProdutoController(IProdutoService produtoService, ILogger<ProdutoController> logger)
        {
            _produtoService = produtoService;
            _logger = logger;
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
                _logger.LogError(ex, "Erro ao Salvar um Produto");
                return BadRequest($"Erro => {ex.Message}");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProdutoResult>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAll()
        {
            var transaction = Agent.Tracer.StartTransaction("Consultado todos os Produtos", "Requisição");
            try
            {
                return Ok(await _produtoService.ObterTodosAsync());
            }
            catch (Exception ex)
            {
                transaction.CaptureException(ex);
                _logger.LogError(ex, "Erro ao buscar todos os produtos");
                return BadRequest($"Erro => {ex.Message}");
            }
            finally
            {
                transaction.End();
            }


        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<ProdutoResult>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _produtoService.ObterPorIdAsync(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar todos os produtos");
                return BadRequest($"Erro => {ex.Message}");
            }

        }
    }
}