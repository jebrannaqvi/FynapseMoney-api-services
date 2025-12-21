using Moneymanager.Services.AuthAPI.Modal.DTO;

namespace Moneymanager.Services.AuthAPI.Services.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDTO registrationRequestDTO);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);

        Task<bool> AssignRole(string userName, string roleName);

        Task<LoginResponseDTO> ValidateOTPAsync (OneTimeCodeDTO oneTimeCodeDTO);
    }
}
