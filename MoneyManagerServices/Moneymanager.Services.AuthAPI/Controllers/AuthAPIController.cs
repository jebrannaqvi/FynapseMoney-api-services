using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moneymanager.Services.AuthAPI.Modal.DTO;
using Moneymanager.Services.AuthAPI.Models.DTO;
using Moneymanager.Services.AuthAPI.Services.IService;

namespace Moneymanager.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {

        private readonly IAuthService _authService;
        protected ResponseDTO _responseDTO;

        public AuthAPIController(IAuthService authService)
        {
            _authService = authService;
            this._responseDTO = new ResponseDTO();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
        {
            var errorMessage = await _authService.Register(model);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = errorMessage;
                return BadRequest(_responseDTO);
            }
            
            return Ok(_responseDTO);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            var loginResponse = await _authService.Login(model);
            if (loginResponse == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = "Username or password is incorrect";
                return BadRequest(_responseDTO);
            }

            _responseDTO.Result = loginResponse;
            return Ok(_responseDTO);

        }

        [HttpPost("assignRole")]
        public async Task<IActionResult> AssignRole([FromBody] UserRoleDTO model)
        {
            var assignRoleSuccessful = await _authService.AssignRole(model.UserName, model.Role.ToUpper());
            if (!assignRoleSuccessful)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = "Error encountered";
                return BadRequest(_responseDTO);
            }

            return Ok(_responseDTO);

        }
    }
}
