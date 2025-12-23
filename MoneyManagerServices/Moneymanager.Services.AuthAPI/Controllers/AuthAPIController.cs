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
        private readonly ILogger<AuthAPIController> _logger;
        protected ResponseDTO _responseDTO;


        public AuthAPIController(IAuthService authService, ILogger<AuthAPIController> logger)
        {
            _authService = authService;
            _logger = logger;
            this._responseDTO = new ResponseDTO();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
        {
            try
            {
                _logger.LogInformation("Registration attempt for user: {UserName}", model.UserName);
                var errorMessage = await _authService.Register(model);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    _logger.LogInformation("Registration failed for user: {UserName} " +
                        "with error message: {errorMessage}", model.UserName, errorMessage);

                    _responseDTO.IsSuccess = false;
                    _responseDTO.DisplayMessage = errorMessage;
                    return BadRequest(_responseDTO);
                }

                return Ok(_responseDTO);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error occurred during registration for user: {UserName}", model.UserName);
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = "An error occurred during registration. Please try again later.";
                return StatusCode(StatusCodes.Status500InternalServerError, _responseDTO);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            try
            {
                _logger.LogInformation("Login attempt for user: {UserName}", model.UserName);

                var loginResponse = await _authService.Login(model);
                if (loginResponse == null || loginResponse.User == null)
                {
                    _logger.LogInformation("Login failed for user: {UserName} " +
                    "due to incorrect username or password", model.UserName);
                    _responseDTO.IsSuccess = false;
                    _responseDTO.DisplayMessage = "Username or password is incorrect";
                    return BadRequest(_responseDTO);
                }

                _responseDTO.Result = loginResponse;
                return Ok(_responseDTO);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error occurred during login for user: {UserName}", model.UserName);
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = "An error occurred during login. Please try again later.";
                return StatusCode(StatusCodes.Status500InternalServerError, _responseDTO);
            }

        }

        [HttpPost("assignRole")]
        public async Task<IActionResult> AssignRole([FromBody] UserRoleDTO model)
        {

            try {
                _logger.LogInformation("Role assignment attempt: Assigning role {Role} to user: {UserName}", model.Role, model.UserName);
                var assignRoleSuccessful = await _authService.AssignRole(model.UserName, model.Role.ToUpper());
                if (!assignRoleSuccessful)
                {
                    _logger.LogInformation("Role assignment failed: Could not assign role {Role} to user: {UserName}", model.Role, model.UserName);
                    _responseDTO.IsSuccess = false;
                    _responseDTO.DisplayMessage = "Error encountered";
                    return BadRequest(_responseDTO);
                }

                return Ok(_responseDTO);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while assigning role {Role} to user: {UserName}", model.Role, model.UserName);
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = "An error occurred while assigning role. Please try again later.";
                return StatusCode(StatusCodes.Status500InternalServerError, _responseDTO);
            }


        }

        [HttpPost("validateOTP")]
        public async Task<IActionResult> ValidateOTP([FromBody] OneTimeCodeDTO codeDTO)
        {
            try
            {
                _logger.LogInformation("OTP validation attempt for user: {UserName}", codeDTO.UserId);
                var loginResponse = await _authService.ValidateOTPAsync(codeDTO);
                if (loginResponse == null || string.IsNullOrEmpty(loginResponse.Token))
                {
                    _logger.LogInformation("OTP validation failed for user: {UserName} due to invalid OTP code", codeDTO.UserId);
                    _responseDTO.IsSuccess = false;
                    _responseDTO.DisplayMessage = "Invalid OTP code";
                    return BadRequest(_responseDTO);
                }
                _responseDTO.Result = loginResponse;
                return Ok(_responseDTO);

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error occurred during OTP validation for user: {UserName}", codeDTO.UserId);
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = "An error occurred during OTP validation. Please try again later.";
                return StatusCode(StatusCodes.Status500InternalServerError, _responseDTO);
            }


        }
    }
}
