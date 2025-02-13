using CabMedicalBACK.API.DTOs;
using CabMedicalBACK.API.Mappers;
using CabMedicalBACK.API.Services;
using CabMedicalBACK.BLL.Exceptions;
using CabMedicalBACK.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CabMedicalBACK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly JwtService _jwtService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, JwtService jwtService, ILogger<AuthController> logger)
        {
            this._authService = authService;
            this._jwtService = jwtService;
            this._logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult Login([FromBody] UtilisateurLoginFormDTO utilisateurLoginFormDto)
        {
            try
            {
                UtilisateurLoginDTO? utilisateurLoginDto = this._authService.Login(utilisateurLoginFormDto.ToModel())?.ToLoginDTO();
                
                if (utilisateurLoginDto != null)
                {
                    string token = this._jwtService.GenerateToken(utilisateurLoginDto);
                    return this.Ok(new {token});
                }

                return this.NotFound("les crédentials de login sont incorrect");
            }
            catch (LoginException e)
            {
                return this.BadRequest(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
