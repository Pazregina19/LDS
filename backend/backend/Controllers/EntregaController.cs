using Microsoft.AspNetCore.Mvc;
using backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using backend.DTOs;
using backend.Requests;
using backend.Exxceptions;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EntregaController : ControllerBase
    {
        private readonly IEntrega _entrega;

        public EntregaController(IEntrega entrega)
        {
            _entrega = entrega;
        }

        /// <summary>
        /// Choose a proposal for entrega
        /// </summary>
        /// <param name="DisponibilidadeId"></param>
        /// <returns>Entrega created details or error message </returns>
        [Authorize(Roles = "Cliente")]
        [HttpPost("EscolherProposta")]
        public async Task<IActionResult> EscolherProposta(int DisponibilidadeId)
        {
            try
            {
                var entrega = await _entrega.EscolherPropostaAsync(DisponibilidadeId);
                if (entrega == null)
                {
                    return BadRequest(new { Message = $"Proposta com Id {DisponibilidadeId} não encontrada ou dados insuficientes" });
                }

                return CreatedAtAction(nameof(GetEntregaStatus), new { id = entrega.EntregaId }, entrega);
            }
            catch (ArgumentException e)
            {
                return BadRequest(new { Message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Erro di sitema ao escolher proposta", Detail = e.Message });
            }
        }

        /// <summary>
        /// Gets the status of a specific a entrega 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entrega status or error message</returns>
        [Authorize]
        [HttpGet("{id}/Estado")]
        public async Task<IActionResult> GetEntregaStatus(int id)
        {
            try
            {
                var entrega = await _entrega.GetEntregaStatusAsync(id);
                if (entrega == null)
                {
                    return NotFound(new { Message = $"Entrega com Id{id} não encontrada." });
                }
                return Ok(entrega);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Erro do sistema ao procurar status de entrega", Detail = e.Message });
            }
        }

        /// <summary>
        /// Completes specific entrega
        /// </summary>
        /// <param name="EntregaId"></param>
        /// <returns>completed entregga or error message</returns>
        [Authorize(Roles = "Estafeta")]
        [HttpPut("FinalizarEstafeta")]
        public async Task<IActionResult> FinalizarEntrega([FromBody] int EntregaId)
        {
            try
            {
                var entrega = await _entrega.FinalizarEntregaAsync(EntregaId);
                if (entrega == null)
                {
                    return BadRequest(new { Message = $"Entrega com ID {EntregaId} não encontrada ou dados insuficientes." });
                }
                return Ok(entrega);
            }
            catch (ArgumentException e)
            {
                return BadRequest(new { Message = e.Message });
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(new { Message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Erro do sistema ao finalizar entrega", Detail = e.Message });
            }
        }

        /// <summary>
        /// Gets all entregas
        /// </summary>
        /// <returns>List of entregas or error message</returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllEntregas()
        {
            try
            {
                var entregas = await _entrega.GetAllEntregasAsync() ?? new List<EntregaDTO>();
                return Ok(entregas);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Erro do sistema ao procurar entregas", Detail = e.Message });
            }
        }

        /// <summary>
        /// Creates e new entrega
        /// </summary>
        /// <param name="entregaDto">Data to create entrega</param>
        /// <returns>Created entrega or error message</returns>
        [Authorize(Roles = "Estafeta")]
        [HttpPost]
        public async Task<IActionResult> CreateEntrega([FromBody] EntregaCreateDTO entregaDto)
        {
            try
            {
                var newEntrega = await _entrega.CreateEntregaAsync(entregaDto);
                return CreatedAtAction(nameof(GetEntregaStatus), new { id = newEntrega.EntregaId }, newEntrega);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Erro do sistema ao criar entrega", Detail = e.Message });
            }
        }

        /// <summary>
        /// Updates the status of a specific entrega
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns>Successs message or error message</returns>
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateEntregaStatus(int id, [FromBody] UpdateEntregaStatusRequest request)
        {
            try
            {
                var atualizar = await _entrega.UpdateEntregaStatusAsync(id, new EntregaUpdateDTO { Status = request.Status });
                if (!atualizar)
                {
                    return BadRequest(new { Message = "Entrega não encontrada" });
                }
                return Ok("Estado da entrega atualizado com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Erro do sistema ao atualizar o estado da entrega", Detail = e.Message });
            }
        }

        /// <summary>
        /// Confirms if entrega was deivered
        /// </summary>
        /// <param name="id">Entrega id to be confirmed</param>
        /// <param name="EstafetaId">Estafeta id associated to entrega</param>
        /// <returns>Success message or error message</returns>
        [Authorize(Roles = "Estafeta")]
        [HttpPut("{id}/ConfirmarRecolha")]
        public async Task<IActionResult> ConfirmarRecolha([FromRoute] int id, [FromBody] int EstafetaId)
        {
            try
            {
                var success = await _entrega.ConfirmarRecolhaAsync(id, EstafetaId);
                if (success == null)
                {
                    return BadRequest(new { Message = "Não foi possível confirmar a recolha da entrega." });
                }

                return Ok("Recolha confirmada com sucesso, encomenda está agora em trânsito.");
            }
            catch (ArgumentException e)
            {
                return BadRequest(new { Message = e.Message });
            }
            catch (AppExceeption e)
            {
                return BadRequest(new { Message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Erro do sistema ao confirmar recolha.", Detail = e.Message });
            }
        }

        /// <summary>
        /// Gets a cliente associated to a entrega
        /// </summary>
        /// <param name="id">Entrega Id</param>
        /// <returns>Cliente details associated or error message</returns>
        [Authorize]
        [HttpGet("{id}/Cliente")]
        public async Task<IActionResult> GetEntregaCliente(int id)
        {
            try
            {
                var estafeta = await _entrega.GetEntregaClienteAsync(id);
                if (estafeta == null)
                {
                    return NotFound(new { Message = $"Cliente com Id{id} não encontrado." });
                }
                return Ok(estafeta);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Erro do sistema ao procurar estafeta associado", Detail = e.Message });
            }
        }

        /// <summary>
        /// Gets a estafeta associated to a entrega
        /// </summary>
        /// <param name="id">Entrega Id</param>
        /// <returns>Estafeta details or error message</returns>
        [Authorize]
        [HttpGet("{id}/Estafeta")]
        public async Task<IActionResult> GetEntregaEstafeta(int id)
        {
            try
            {
                var estafeta = await _entrega.GetEntregaEstafetaAsync(id);
                if (estafeta == null)
                {
                    return NotFound(new { Message = $"Estafeta com Id{id} não encontrado." });
                }
                return Ok(estafeta);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Erro do sistema ao procurar estafeta associado", Detail = e.Message });
            }
        }

        /// <summary>
        /// Gets encomenda associatedd to entrega
        /// </summary>
        /// <param name="id">Entrega Id</param>
        /// <returns>Ecomenda details or error message</returns>
        [Authorize]
        [HttpGet("{id}/Entrega")]
        public async Task<IActionResult> GetEntregaEncomenda(int id)
        {
            try
            {
                var encomenda = await _entrega.GetEntregaEncomendaAsync(id);
                if (encomenda == null)
                {
                    return NotFound(new { Mwsssage = $"Encomenda com id {id}não esncontrada a entrega associada" });
                }
                return Ok(encomenda);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Erro do sistema a o procurar encomenda associada", Detail = e.Message });
            }
        }

        /// <summary>
        /// Endpoint to get all entregas associated to a specific estafeta
        /// </summary>
        /// <param name="id">Estafeta id to get entregas</param>
        /// <returns>
        /// A HTTP status result with the following returns:
        /// -Bad Request(400):if given id is less or equal zero
        /// -Ok(200):list of all entregas associated to estafeta
        /// -NotFound(404):if there is no entrega associated to the estafeta associated
        /// -Internal error(500):if an unexpected error occurs during execution.
        /// </returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllEntregasEstafetas(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Id do estafeta deve ser maior que zero.");
                }

                var entregas = await _entrega.GetAllEntregasEstafetaAsync(id);

                if (entregas == null || entregas.Any())
                {
                    return NotFound("Nenhuma entrega para este estafeta");
                }
                return Ok(entregas);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro ao procurar as entregas. Por favor tente novamente mais tarde");
            }



        }
    }
}