using Microsoft.AspNetCore.Mvc;
using PottencialApi.Application.Interfaces;
using PottencialApi.Application.DTOs;

namespace PottencialApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : Controller
    {
        private readonly IProdutoService _produtoService;
        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProdutoDTO>> GetByIdAsync(int id)
        {
            var produto = await _produtoService.GetByIdAsync(id);
            if (produto is null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoDTO>> CreateAsync(ProdutoDTO produto)
        {
            await _produtoService.CreateAsync(produto);
            return Created("api/produtos/id", produto);
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

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProdutoDTO>> RemoveAsync(int id)
        {
            var produtoBanco = await _produtoService.GetByIdAsync(id);
            if(produtoBanco is null)
            {
                return NotFound();
            }

            await _produtoService.RemoveAsync(id);

            return Ok(produtoBanco);
        }
        
    }
}
