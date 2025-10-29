using Microsoft.AspNetCore.Authorization;
using backend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using backend.DTOs;
using backend.Exxceptions;

namespace backend.Controllers
{
    /// <summary>
    /// Controller responsible for operations related to cliente entity
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ICliente _cliente;
        private readonly IUserStatus _userStatus;

        /// <summary>
        /// Initializes a new instance to cliente controller with necessarie services
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="userStatus"></param>
        public ClienteController(ICliente cliente, IUserStatus userStatus)
        {
            _cliente = cliente;
            _userStatus = userStatus;
        }

        /// <summary>
        /// Gets all estafetas registered
        /// </summary>
        /// <returns>List of estafetas or error message</returns>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var estafetas = _cliente.GetAll();
                return Ok(estafetas);
            }
            catch (Exception e)
            {
                return BadRequest(new { Messsage = e.Message });
            }
        }

        /// <summary>
        /// Gets a specific cliente by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Cliente details or error message</returns>
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var cliente = _cliente.GetById(id);
                if (cliente == null)
                    return NotFound(new { Message = "Cliente não encontrado" });

                return Ok(cliente);

            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Cliente não encontrado", Detail = e.Message });
            }
        }

        /// <summary>
        /// Creates a new cliente into the system
        /// </summary>
        /// <param name="clienteCreateDto">Data to create a new cliente</param>
        /// <returns>Cliente criado or error message</returns>
        [Authorize(Roles = "Cliente")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteCreateDTO clienteCreateDto)
        {
            try
            {
                var createdCliente = await _cliente.CreateAsync(clienteCreateDto);
                return CreatedAtAction(nameof(Get), new { id = createdCliente.Id });
            }
            catch (AppExceeption e)
            {
                return BadRequest(new { Message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Erro ao registar cliente no sistema", Detail = e.Message });
            }
        }

        /// <summary>
        /// Updates data of a specific cliente
        /// </summary>
        /// <param name="id">Id of cliente to be updated</param>
        /// <param name="clienteUpdateDTO">Data for cliente update</param>
        /// <returns>Updated cliente or error message</returns>
        [Authorize(Roles = "Cliente")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ClienteUpdateDTO clienteUpdateDTO)
        {
            try
            {
                var updateCliente = await _cliente.UpdateAsync(id, clienteUpdateDTO);
                return Ok(updateCliente);
            }
            catch (AppExceeption e)
            {
                return BadRequest(new { Message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Erro ao atualizar dados cliente", Detail = e.Message });
            }

        }

        /// <summary>
        /// Activates a specific Cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Success message or eeror message</returns>
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/ Activate")]
        public async Task<IActionResult> Activate(int id)
        {
            try
            {
                await _userStatus.ActivateAsync(id);
                return Ok(new { Message = "Cliente ativado com sucesso." });
            }
            catch (AppExceeption e)
            {
                return BadRequest(new { Message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Erro do siistema ao ativar cliente", Detail = e.Message });
            }
        }

        /// <summary>
        /// Inactivates a specific Cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Success message or eeror message</returns>
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/ Inactivate")]
        public async Task<IActionResult> Inactivate(int id)
        {
            try
            {
                await _userStatus.InactivateAsync(id);
                return Ok(new { Message = "Cliente ativado com sucesso." });
            }
            catch (AppExceeption e)
            {
                return BadRequest(new { Message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Erro do siistema ao inativar cliente", Detail = e.Message });
            }
        }
    }
}