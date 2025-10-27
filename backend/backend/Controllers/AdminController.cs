using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using backend.DTOs;
using backend.Interfaces;
using backend.Exxceptions;
using System.Threading.Tasks;

namespace backend.Controllers
{
    /// <summary>
    /// Controller responsible for management operations related to admins
    /// Only users authenticated as admin can access their endpoints
    /// </summary>
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin _admin;

        /// <summary>
        /// Initialize new instance of controller with admin service injection
        /// </summary>
        /// <param name="admin"></param>
        public AdminController(IAdmin admin)
        {
            _admin = admin;
        }

        /// <summary>
        /// Gets a list of all admins in the system
        /// </summary>
        /// <returns>
        /// HTTP response with an admin list(status 200) or message admin not found(status 400)
        /// If system error, returns status 500
        /// </returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var admins = _admin.GetAll();
                if (admins == null || !admins.Any())
                    return NotFound(new { Message = "Nenhum admin encontrado" });

                return Ok(admins);

            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Erro no sistema", Detail = e.Message });
            }
        }

        /// <summary>
        /// Gets a specific admin based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// HTTP response with admin data(status 200)
        /// A message that indicates admin not found(status 400)
        /// system error message(status 500)
        /// </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest(new { Message = "ID inválido" });

                var admin = _admin.GetById(id);
                if (admin == null)
                    return NotFound(new { Message = "Admin não encontrado" });

                return Ok(admin);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Erro no sistema", Detail = e.Message });
            }
        }

        
    }
}