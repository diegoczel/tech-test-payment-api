using Microsoft.AspNetCore.Mvc;
using PottencialApi.Application.Interfaces;
using PottencialApi.Application.DTOs;

namespace PottencialApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : Controller
    {
        private readonly IProdutoService _produtoService;
        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet("id:int")]
        public async Task<ActionResult<ProdutoDTO>> GetByIdAsync(int id)
        {
            var produto = await _produtoService.GetByIdAsync(id);
            if(produto is null)
            {
                return NotFound();
            }

            return Ok(produto);
        }
    }
}
