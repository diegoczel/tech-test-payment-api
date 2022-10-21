using Microsoft.AspNetCore.Mvc;
using PottencialApi.Application.Interfaces;
using PottencialApi.Application.DTOs;
using FluentValidation;

namespace PottencialApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ProdutosController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly IValidator<ProdutoDTO> _validator;

        public ProdutosController(IProdutoService produtoService, IValidator<ProdutoDTO> validator)
        {
            _produtoService = produtoService;
            _validator = validator;
        }

        #region DocGetProduto
        /// <summary>
        /// Busca um produto pelo seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Sucesso ao buscar o produto pelo seu id.</response>
        /// <response code="404">Id do produto não existe.</response>
        /// <response code="500">Erro interno do servidor!</response>
        #endregion
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProdutoDTO>> GetByIdAsync(int id)
        {
            var produto = await _produtoService.GetByIdAsync(id);
            if (produto is null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        /// <summary>
        /// Cria um novo Produto.
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        /// <response code="201">Sucesso ao criar o Produto!</response>
        /// <response code="400">Falha na validação dos dados do post!</response>
        /// <response code="500">Erro interno do servidor!</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProdutoDTO>> CreateAsync(ProdutoDTO produto)
        {
            var result = await _validator.ValidateAsync(produto);
            if(!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var produtoBanco = await _produtoService.CreateAsync(produto);
            return Created($"api/produtos/{produtoBanco.Id}", produtoBanco);
        }

        /*
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProdutoDTO>> UpdateAsync(int id, ProdutoDTO produtoDto)
        {
            var produtoBanco = await _produtoService.GetByIdAsync(id);
            if(produtoBanco is null)
            {
                return BadRequest();
            }

            await _produtoService.UpdateAsync(produtoDto);
            return Ok(produtoDto);
        }
        */

        /// <summary>
        /// Remove um produto pelo seu id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="204">Sucesso ao remover o Produto.</response>
        /// <response code="404">Id do produto inválido!</response>
        /// <response code="500">Erro interno do servidor!</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> RemoveAsync(int id)
        {
            var produtoBanco = await _produtoService.GetByIdAsync(id);
            if(produtoBanco is null)
            {
                return NotFound();
            }

            await _produtoService.RemoveAsync(id);

            return NoContent();
        }
        
    }
}
