namespace Moneymanager.Services.AuthAPI.Modal.DTO
{
    public class LoginResponseDTO
    {
        public virtual String Token { get; set; }
        public virtual UserDTO User { get; set; }
    }
}
