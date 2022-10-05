using Microsoft.AspNetCore.Mvc;
using PottencialApi.Application.Interfaces;
using PottencialApi.Application.DTOs;

namespace PottencialApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
                return BadRequest();
            }

            return Ok(vendedor);
        }

        [HttpPost]
        public async Task<ActionResult<VendedorDTO>> CreateAsync(VendedorDTO vendedor)
        {
            await _vendedorService.CreateAsync(vendedor);
            return Created("api/vendedores/id", vendedor);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<VendedorDTO>> RemoveAsync(int id)
        {
            var vendedor = await _vendedorService.GetByIdAsync(id);
            if(vendedor is null)
            {
                return NotFound();
            }

            await _vendedorService.RemoveAsync(id);

            return Ok(vendedor);
        }
    }
}
