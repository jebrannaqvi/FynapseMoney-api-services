using Microsoft.AspNetCore.Identity;

namespace Moneymanager.Services.AuthAPI.Modal
{
    public class ApplicationUser : IdentityUser
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }

    }
}
