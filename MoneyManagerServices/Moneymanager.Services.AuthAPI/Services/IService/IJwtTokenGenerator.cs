using Moneymanager.Services.AuthAPI.Modal;

namespace Moneymanager.Services.AuthAPI.Services.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser user, IEnumerable<string> roles);
    }
}
