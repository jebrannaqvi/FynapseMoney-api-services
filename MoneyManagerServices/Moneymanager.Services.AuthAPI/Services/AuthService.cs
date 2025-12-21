using Microsoft.AspNetCore.Identity;
using Moneymanager.Services.AuthAPI.Data;
using Moneymanager.Services.AuthAPI.Modal;
using Moneymanager.Services.AuthAPI.Modal.DTO;
using Moneymanager.Services.AuthAPI.Services.IService;
using System.Data;

namespace Moneymanager.Services.AuthAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDBContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IEmailService _emailService;

        public AuthService(AppDBContext db, IJwtTokenGenerator jwtTokenGenerator, UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, IEmailService emailService)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator = jwtTokenGenerator;
            _emailService = emailService;   
        }

        public async Task<bool> AssignRole(string userName, string roleName)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == userName.ToLower());
            if (user != null)
            {
                if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    var role = new IdentityRole();
                    role.Name = roleName;
                    _roleManager.CreateAsync(role).GetAwaiter().GetResult();
                }

                await _userManager.AddToRoleAsync(user, roleName);

                return true;
            }

            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDTO.UserName.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);
            
            if (user == null || !isValid)
            {
                return new LoginResponseDTO() { User = null, Token=""};
            }


            var oneTimeCode = await _userManager.GenerateTwoFactorTokenAsync(user, TokenOptions.DefaultEmailProvider);
            // call email API to send the code to user email address
            await _emailService.SendEmailAsync(user.Email, "Your One Time Code", $"Your one time code is: {oneTimeCode}");

            
            UserDTO userDTO = new()
            {
                ID = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            LoginResponseDTO loginResponseDTO = new()
            {
                User = userDTO,
                Token = ""
            };

            return loginResponseDTO;
        }

        public async Task<string> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            ApplicationUser user = new()
            {
                UserName = registrationRequestDTO.UserName,
                Email = registrationRequestDTO.Email,
                NormalizedEmail = registrationRequestDTO.Email.ToUpper(),
                FirstName = registrationRequestDTO.FirstName,
                LastName = registrationRequestDTO.LastName,
                PhoneNumber = registrationRequestDTO.PhoneNumber
            };

            try
            {
                var result = await _userManager.CreateAsync(user, registrationRequestDTO.Password);
                if (result.Succeeded)
                {
                    var userToReturn = _db.ApplicationUsers.FirstOrDefault(u => u.UserName == registrationRequestDTO.UserName);
                    
                    UserDTO userDTO = new()
                    {
                        ID = userToReturn.Id,
                        FirstName = userToReturn.FirstName,
                        LastName = userToReturn.LastName,
                        Email = userToReturn.Email,
                        PhoneNumber = userToReturn.PhoneNumber
                    };

                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
                
            }
            catch (Exception ex)
            {

                return "Error encountered during registration: " + ex.Message;
            }
        }

        public async Task<LoginResponseDTO> ValidateOTPAsync (OneTimeCodeDTO oneTimeCodeDTO)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.Id == oneTimeCodeDTO.UserId);
            var roles = await _userManager.GetRolesAsync(user);
            bool isVerified = await _userManager.VerifyTwoFactorTokenAsync(user, TokenOptions.DefaultEmailProvider, oneTimeCodeDTO.Code);

            if (isVerified)
            {
                string token = _jwtTokenGenerator.GenerateToken(user, roles);
                UserDTO userDTO = new()
                {
                    ID = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber
                };

                LoginResponseDTO loginResponseDTO = new()
                {
                    User = userDTO,
                    Token = token
                };

                return loginResponseDTO;
            }
            else
            {
                return new LoginResponseDTO() { User = null, Token = "" };
            }
        }
    }
}
