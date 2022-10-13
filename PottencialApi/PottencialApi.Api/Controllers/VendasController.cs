using Microsoft.AspNetCore.Mvc;
using PottencialApi.Application.DTOs;
using PottencialApi.Application.Interfaces;

namespace PottencialApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class VendasController : Controller
    {
        private readonly IVendaService _vendaService;
        public VendasController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        /// <summary>
        /// Cria uma Venda com seus Itens
        /// </summary>
        /// <param name="venda"></param>
        /// <remarks>
        /// Exemplo de request:
        ///     
        ///     POST /Vendas
        ///     {
        ///         "vendedorId": 5,
        ///         "vendaDetalhe": [
        ///             {
        ///                 "quantidade": 3,
        ///                 "precoUnitario": 2,
        ///                 "desconto": 0,
        ///                 "acrescimo": 0,
        ///                 "produtoId": 6
        ///             }
        ///         ]
        ///     }
        ///     
        /// </remarks>
        /// <returns></returns>
        /// <response code="201">Retorna a venda e seus itens recém criados</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
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

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, VendaStatusDTO vendaStatus)
        {
            if(await _vendaService.UpdateAsync(id, vendaStatus))
            {
                return NoContent();
            }

            return BadRequest();     
        }
    }
}
