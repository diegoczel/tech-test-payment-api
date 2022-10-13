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

        #region DocPostVenda
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
        #endregion
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<VendaDTO>> Create(VendaDTO venda)
        {
            await _vendaService.CreateAsync(venda);
            return Created("api/vendas/id", venda);
        }

        #region DocGetVendaById
        /// <summary>
        /// Busca uma venda com seus itens através do ID da venda.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// 
        ///     GET /Vendas/id
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Retorna uma venda com seus itens.</response>
        /// <response code="404">Id da venda inválido!</response>
        #endregion
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VendaDTO>> Get(int id)
        {
            var venda = await _vendaService.GetById(id);
            
            if(venda is null)
            {
                return NotFound();
            }

            return Ok(venda);
        }

        #region DocPutStatusVenda
        /// <summary>
        /// Atualiza o Status de uma venda.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vendaStatus"></param>
        /// <returns></returns>
        /// <response code="204">Status da venda atualizado com sucesso.</response>
        /// <response code="400">Falha na atualização do status da venda.</response>
        #endregion
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
