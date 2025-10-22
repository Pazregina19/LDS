using backend.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using backend.Exxceptions;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using backend.DTOs;
using Microsoft.AspNetCore.Authorization;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace backend.Controllers
{
    /// <summary>
    /// Controller responsible for order management
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
   
    public class EncomendaController : ControllerBase
    {
        private readonly IEncomenda i_encomenda;

        /// <summary>
        /// Initializes new instance of orders
        /// </summary>
        /// <param name="encomenda"></param>
        public EncomendaController(IEncomenda encomenda)
        {
            i_encomenda = encomenda;
        }

        /// <summary>
        /// Gets all orders of a specific client
        /// </summary>
        /// <param name="ClienteId"></param>
        /// <returns>List of orders or error message</returns>
        [Authorize]
        [HttpGet("Cliente/{idCliente}")]
        public async Task<IActionResult> GetEncomendasByCliente(int ClienteId)
        {
            try
            {
                var encomendas = await i_encomenda.GetEncomendasByClienteAsync(ClienteId);
                if (encomendas == null || encomendas.Count == 0)
                {
                    return NotFound(new { Message = "Nenhuma encomenda encontrada para o cliente solicitado" });
                }
                return Ok(encomendas);
            }
            catch (AppExceeption e)
            {
                return BadRequest(new { Message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Erro no sistema ao procurar encomendas", Detail = e.Message });
            }
        }

        /// <summary>
        /// Gets orders disponible near a delivery man
        /// </summary>
        /// <param name="EstafetaId"></param>
        /// <returns>List of orders or error message</returns>
        [Authorize(Roles = "Estafeta")]
        [HttpGet("Estafeta/{EstafetaId}")]
        public async Task<IActionResult> GetEncomendasProximoEstafetaAsync(int EstafetaId)
        {
            try
            {
                var encomendas = await i_encomenda.GetEncomendasProximoEstafetaAsync(EstafetaId);
                if (encomendas == null || encomendas.Count == 0)
                {
                    return NotFound(new { Message = "Nenhuma encomenda nas próximidades encontrada." });
                }
                return Ok(encomendas);
            }
            catch (AppExceeption e)
            {
                return BadRequest(new { Message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Erro no sistema ao procurar encomendas disponíveis", Detail = e.Message });
            }
        }

        /// <summary>
        /// Gets all orders registered into the system
        /// </summary>
        /// <returns>List of orders or error message</returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllEncomendas()
        {
            try
            {
                var encomendas = await i_encomenda.GetAllEncomendasAsync();
                return Ok(encomendas);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Erro no sistema ao procurar todas as encomendas", Detail = e.Message  });
            }
        }

        /// <summary>
        /// Gets an order by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Order found or error message</returns>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEncomendasById(int id)
        {
            try
            {
                var encomenda = await i_encomenda.GetEncomendaByIdAsync(id);
                if (encomenda == null)
                {
                    return NotFound(new { Message = "Encomenda não encontrada." });
                }
                return Ok(encomenda);
            }
            catch (AppExceeption e)
            {
                return BadRequest(new { Message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Erro no sistema ao procurar encomenda.", Detail = e.Message });
            }
                
        }
    }
    

}