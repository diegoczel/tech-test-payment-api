using Microsoft.AspNetCore.Mvc;
using PottencialApi.Application.DTOs;
using PottencialApi.Application.Interfaces;

namespace PottencialApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendasController : Controller
    {
        private readonly IVendaService _vendaService;
        public VendasController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpPost]
        public async Task<ActionResult<VendaDTO>> Create(VendaDTO venda)
        {
            await _vendaService.CreateAsync(venda);
            return Created("api/vendas/id", venda);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<VendaDTO>> Get(int id)
        {
            var venda = await _vendaService.GetById(id);
            
            if(venda is null)
            {
                return NotFound();
            }

            return Ok(venda);
        }
    }
}
