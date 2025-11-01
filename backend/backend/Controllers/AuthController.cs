using backend.Interfaces;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using backend.DTOs;
using Microsoft.AspNetCore.Authorization;
using backend.Models.Enums;
using Microsoft.Extensions.Configuration;
using backend.Services;
using backend.Exxceptions;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;



namespace backend.Controllers
{
   /// <summary>
   /// Controller responsible for authentication operations and users register
   /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ICliente _cliente;
        private readonly IAdmin _admin;
        private readonly IEstafeta _estafeta;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a  new instance of auth controller with the necessary service
        /// </summary>
        /// <param name="_cliente"></param>
        /// <param name="_admin"></param>
        /// <param name="_estafeta"></param>
        /// <param name="_configuration"></param>
        public AuthController(
            ICliente cliente,
            IAdmin admin,
            IEstafeta estafeta,
            IConfiguration _configuration
            )
        {
            _cliente = cliente;
            _admin = admin;
            _estafeta = estafeta;
        }

        /// <summary>
        /// Authenticates a user based on its role, email and password
        /// </summary>
        /// <param name="logInDto"></param>
        /// <returns>
        /// A JWT token if authentication succeeds(status 200)
        /// Error message if fails (status 400/403/500)
        /// </returns>
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate ([FromBody]LogInDto logInDto)
        {
            try
            {
                object user = null;
                UserType? detectedRole = null;

                //Trys authentication as cliente
                user = TryAuthenticate(_cliente, logInDto);
                if (user != null)
                {
                    detectedRole = UserType.Cliente;
                }

                //Trys authentication as estafeta, if not cliente
                if (user == null)
                {
                    user = TryAuthenticate(_estafeta, logInDto);
                    if (user != null)
                    {
                        detectedRole = UserType.Estafeta;
                    }
                }

                //Trys to authenticate as admin if not cliente or estafeta
                if (user == null)
                {
                    user = TryAuthenticate(_admin, logInDto);
                    if (user != null)
                    {
                        detectedRole = UserType.Admin;
                    }
                }

                //Returns eeror if user not found
                if (user == null)
                {
                    return BadRequest(new { Message = "Email ou password incorretos" });
                }

                ///Generates a JWT token
                var tokenString = GenerateJwtToken(user, detectedRole.Value);

                return Ok(new AuthDTO
                {
                    Id = GetUserId(user),
                    Nome = GetUserName(user),
                    Email = GetUserEmail(user),
                    Role = detectedRole.ToString(),
                    Token = tokenString

                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Erro do sistema", Detail = e.Message });
            }
        }

        private object TryAuthenticate<TCreateDTO, TUpdateDTO, TDTO>(
            IUser<TCreateDTO, TUpdateDTO, TDTO> service,
            LogInDto logInDto) where TDTO : class
        {
            try
            {
                return service.Authenticate(logInDto.Email, logInDto.password);
            }
            catch (AppExceeption)
            {
                //returns null if authentication fails
                return null;
            }

        }

        /// <summary>
        /// Register a new user based on its role and data
        /// </summary>
        /// <param name="registarDto"></param>
        /// <param name="role"></param>
        /// <returns>
        /// Success message if succeds status 200
        /// if fails error message status 400/500
        /// </returns>
        [AllowAnonymous]
        [HttpPost("Registar")]
        public async Task<IActionResult> Registar([FromBody]RegistarDto registarDto, [FromQuery]UserType? role)
        {
            if (role == null || !Enum.IsDefined(typeof(UserType), role))
                return BadRequest(new { Message = "O user type (role) é obrigatório ou está inválido" });

            try
            {
                switch (role)
                {
                    case UserType.Cliente:
                        var clienteDto = new ClienteCreateDTO
                        {
                            Nome = registarDto.Nome,
                            Email = registarDto.Email,
                            Password = registarDto.Password,
                            Contacto = registarDto.Contacto,
                            Morada = registarDto.Morada,
                            CodigoPostal = registarDto.CodigoPostal
                        };
                        await _cliente.CreateAsync(clienteDto);
                        break;

                    case UserType.Admin:
                        var adminDto = new AdminCreateDTO
                        {
                            Nome = registarDto.Nome,
                            Email = registarDto.Email,
                            Password = registarDto.Password

                        };
                        await _admin.CreateAsync(adminDto);
                        break;

                    case UserType.Estafeta:
                        var estafetaDto = new EstafetaCreateDTO
                        {
                            Nome = registarDto.Nome,
                            Email = registarDto.Email,
                            Password = registarDto.Password,
                            Contacto = registarDto.Contacto,
                            Morada = registarDto.Morada,
                            CodigoPostal = registarDto.CodigoPostal
                        };
                        await _estafeta.CreateAsync(estafetaDto);
                        break;

                    default:
                        return BadRequest(new { Message = "Role inválida." });
                }
                return Ok(new { Message = $"{role} registrado com sucesso." });
            }
            catch (AppExceeption e)
            {
                return BadRequest(new { Message = e.Message });
            }
             catch (Exception e)
            {
                return StatusCode(500, new { Message = "Erro ao processar a requisição.", Detail = e.Message });
            }
        }

        /// <summary>
        /// Generates a JWT token for authenticated user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        /// <exception cref="AppExceeption"></exception>
        private string GenerateJwtToken(object user, UserType role)
        {
            var secretKey = _configuration["AppSettings:Secre"];
            if (string.IsNullOrEmpty(secretKey))
                throw new AppExceeption("JWT secret key não está configuarado");

            var key = Encoding.ASCII.GetBytes(secretKey);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, GetUserId(user).ToString()),
                new Claim(ClaimTypes.Name, GetUserName(user)),
                new Claim(ClaimTypes.Email, GetUserEmail(user)),
                new Claim(ClaimTypes.Role, role.ToString())
            };

             var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// Verifies if user is active
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private bool IsUserActive(object user)
        {
            return user switch
            {
                ClienteDTO cliente => cliente.Status == UserStatus.Active,
                EstafetaDTO estafeta => estafeta.Status == UserStatus.Inactive,
                AdminDTO _ => true, // Admins are always active
                _ => false
            };
        }

        /// <summary>
        /// Gets user email
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string GetUserEmail(object user) => user switch
        {
            ClienteDTO cliente => cliente.Email,
            AdminDTO admin => admin.Email,
            EstafetaDTO estafeta => estafeta.Email,
            _ => string.Empty
        };
            
        private string GetUserName(object user)=> user switch
        {
            ClienteDTO cliente => cliente.Nome,
            AdminDTO admin => admin.Nome,
            EstafetaDTO estafeta => estafeta.Nome,
            _ => string.Empty
        };

        private int GetUserId(object user)=> user switch
        {
            ClienteDTO cliente => cliente.Id,
            AdminDTO admin => admin.Id,
            EstafetaDTO estafeta => estafeta.Id,
            _ => 0
        };
    }
    
}