
﻿using Microsoft.AspNetCore.Authorization;
using backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using backend.DTOs;
using backend.Exxceptions;

namespace backend.Controllers
{
    /// <summary>
    /// Controller responsible for operations related to estafeta entity
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EstafetaController : ControllerBase
    {
        private readonly IEstafeta _estafeta;
        private readonly IUserStatus _userStatus;

        public EstafetaController(IEstafeta estafeta, IUserStatus userStatus)
        {
            _estafeta = estafeta;
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
                var estafetas = _estafeta.GetAll();
                return Ok(estafetas);
            }
            catch (Exception e)
            {
                return BadRequest(new { Messsage = e.Message });
            }
        }

        /// <summary>
        /// Gets a specific estafeta by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Estafeta details or error message</returns>
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var estafeta = _estafeta.GetById(id);
                if (estafeta == null)
                    return NotFound(new { Message = "Estafeta não encontrado" });

                return Ok(estafeta);

            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Estafeta não encontrado", Detail = e.Message });
            }
        }

        /// <summary>
        /// Creates a new estafeta into the system
        /// </summary>
        /// <param name="estafetaCreateDto">Data to create a new estafeta</param>
        /// <returns>Estafeta criado or error message</returns>
        [Authorize(Roles = "Estafeta")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EstafetaCreateDTO estafetaCreateDto)
        {
            try
            {
                var createdEstafeta = await _estafeta.CreateAsync(estafetaCreateDto);
                return CreatedAtAction(nameof(Get), new { id = createdEstafeta.Id });
            }
            catch (AppExceeption e)
            {
                return BadRequest(new { Message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Erro ao registar estafeta no sistema", Detail = e.Message });
            }
        }

        /// <summary>
        /// Updates data of a specific estafeta
        /// </summary>
        /// <param name="id">Id of estafeta to be updated</param>
        /// <param name="estafetaUpdateDTO">Data for estafeta update</param>
        /// <returns>Updated estafeta or error message</returns>
        [Authorize(Roles = "Estafeta")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EstafetaUpdateDTO estafetaUpdateDTO)
        {
            try
            {
                var updateEstafeta = await _estafeta.UpdateAsync(id, estafetaUpdateDTO);
                return Ok(updateEstafeta);
            }
            catch (AppExceeption e)
            {
                return BadRequest(new { Message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Erro ao atualizar dados estafeta", Detail = e.Message });
            }

        }

         /// <summary>
        /// Activates a specific Estafeta
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
                return Ok(new { Message = "Estafeta ativado com sucesso." });
            }
            catch (AppExceeption e)
            {
                return BadRequest(new { Message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Erro do siistema ao ativar estafeta", Detail = e.Message });
            }
        }
        
        /// <summary>
        /// Inactivates a specific Estafeta
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
                return Ok(new { Message = "Estafeta ativado com sucesso." });
            }
            catch (AppExceeption e)
            {
                return BadRequest(new { Message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Erro do siistema ao inativar estafeta", Detail = e.Message });
            }
        }
    }
}