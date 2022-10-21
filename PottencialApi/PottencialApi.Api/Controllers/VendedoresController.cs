using Microsoft.AspNetCore.Mvc;
using PottencialApi.Application.Interfaces;
using PottencialApi.Application.DTOs;

namespace PottencialApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class VendedoresController : Controller
    {
        private readonly IVendedorService _vendedorService;
        public VendedoresController(IVendedorService vendedorService)
        {
            _vendedorService = vendedorService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<VendedorDTO>> GetByIdAsync(int id)
        {
            var vendedor = await _vendedorService.GetByIdAsync(id);
            if(vendedor is null)
            {
                return NotFound();
            }

            return Ok(vendedor);
        }

        /// <summary>
        /// Cria um vendedor.
        /// </summary>
        /// <param name="vendedor"></param>
        /// <returns></returns>
        /// <response code="201">Sucesso ao criar o vendedor!</response>
        /// <response code="500">Erro interno do servidor!</response>
        /// <response code="400">Falha na validação dos dados enviados!</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VendedorDTO>> CreateAsync(VendedorDTO vendedor)
        {
            var vendedorBanco = await _vendedorService.CreateAsync(vendedor);
            return Created($"api/vendedores/{vendedorBanco.Id}", vendedorBanco);
        }

        /// <summary>
        /// Deleta um vendedor através do seu id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="204">Vendedor removido!</response>
        /// <response code="404">Vendedor não encontrado!</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> RemoveAsync(int id)
        {
            var vendedor = await _vendedorService.GetByIdAsync(id);
            if(vendedor is null)
            {
                return NotFound();
            }

            await _vendedorService.RemoveAsync(id);

            return NoContent();
        }
    }
}
