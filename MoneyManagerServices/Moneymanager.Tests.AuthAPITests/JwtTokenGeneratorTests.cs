using Moneymanager.Services.AuthAPI.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using Moneymanager.Services.AuthAPI.Services;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;

namespace Moneymanager.Tests.AuthAPITests
{
    public class JwtTokenGeneratorTests
    {
        private IOptions<JwtOptions> _jwtOptions;
        public JwtTokenGeneratorTests() { }
        

        [Fact]
        public void JWTTokenGenerator_GenerateToken_tokenValid()
        {
            //Arrange
            var jwtOptionsData = new JwtOptions
            {
                Issuer = "TestIssuer",
                Audience = "TestAudience",
                Secret  = "A_very_long_and_secure_test_signing_key"
            };

            _jwtOptions = Options.Create(jwtOptionsData);


            ApplicationUser user = new ApplicationUser();
            user.Id = "1";
            user.Email = "test@test.com";
            user.FirstName = "FirstName";
            user.LastName = "LastName";

            List<string> roles = new List<string>();
            roles.Add("Admin");

            var jwtTokenGenerator = new JwtTokenGenerator(_jwtOptions);

            //Act
            var token = jwtTokenGenerator.GenerateToken(user, roles);

            //Assert
            Assert.NotNull(token);
            Assert.NotEmpty(token);
            //deserialize and check claims
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            Assert.Equal(user.Email, jwtToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Email).Value);



        }

    }
}
