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
            var vendedor = _vendedorService.GetByIdAsync(id);
            if(vendedor is null)
            {
                return BadRequest();
            }

            return Ok(vendedor);
        }
    }
}
