using Castle.Core.Logging;
using Moneymanager.Services.AuthAPI.Services.IService;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using Moneymanager.Services.AuthAPI.Models.DTO;
using Moneymanager.Services.AuthAPI.Controllers;
using FluentAssertions;
using Moneymanager.Services.AuthAPI.Modal.DTO;
using Microsoft.AspNetCore.Mvc;
using Moneymanager.Services.AuthAPI.Services;

namespace Moneymanager.Tests.AuthAPITests
{
    public class AuthAPIControllerTests
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthAPIController> _logger;


        public AuthAPIControllerTests()
        {

            _authService = A.Fake<IAuthService>();
            _logger = A.Fake<ILogger<AuthAPIController>>();

        }

        [Fact]
        public async Task AuthAPIController_Login_ReturnsOk()
        {
            //Arrange

            var _loginRequestDTO = A.Fake<LoginRequestDTO>();
            var _loginResponseDTO = A.Fake<LoginResponseDTO>();

            var controller = new AuthAPIController(_authService, _logger);


            //Act

            IActionResult result = await controller.Login(_loginRequestDTO);

            //Assert

            result.Should().NotBeNull();

            var okObjectResult = Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public async Task AuthAPIController_Login_ReturnsLoginError()
        {
            //Arrange

            var _loginRequestDTO = A.Fake<LoginRequestDTO>();
            var _loginResponseDTO = A.Fake<LoginResponseDTO>();

            var controller = new AuthAPIController(_authService, _logger);
            A.CallTo(() => _loginResponseDTO.User).Returns(null);
            A.CallTo(() => _authService.Login(_loginRequestDTO)).Returns(_loginResponseDTO);

            //Act
            IActionResult result = await controller.Login(_loginRequestDTO);

            //Assert

            result.Should().NotBeNull();
            Assert.IsType<BadRequestObjectResult>(result);


        }


        [Fact]
        public async Task AuthAPIController_Login_ThrowsException()
        {
            //Arrange

            var _loginRequestDTO = A.Fake<LoginRequestDTO>();
            var _loginResponseDTO = A.Fake<LoginResponseDTO>();
            A.CallTo(() => _authService.Login(_loginRequestDTO)).Throws<Exception>();

            var controller = new AuthAPIController(_authService, _logger);
            
            //Act

            var exception = await controller.Login(_loginRequestDTO);
            var response = Assert.IsType<ObjectResult>(exception);


            var responseDTO = Assert.IsType<ResponseDTO>(response.Value);


            //Assert
            exception.Should().NotBeNull();
            Assert.False(responseDTO.IsSuccess);

        }

        [Fact]
        public async Task AuthAPIController_Register_ReturnsOK()
        {

            //Arrange

            var _registrationRequestDTO = A.Fake<RegistrationRequestDTO>();
            A.CallTo(() => _authService.Register(_registrationRequestDTO)).Returns("");

            var controller = new AuthAPIController(_authService, _logger);


            //Act

            IActionResult result = await controller.Register(_registrationRequestDTO);

            //Assert

            result.Should().NotBeNull();

            var okObjectResult = Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public async Task AuthAPIController_Register_ReturnsError()
        {

            //Arrange

            var _registrationRequestDTO = A.Fake<RegistrationRequestDTO>();
            A.CallTo(() => _authService.Register(_registrationRequestDTO)).Returns("registration failed");

            var controller = new AuthAPIController(_authService, _logger);


            //Act

            IActionResult result = await controller.Register(_registrationRequestDTO);

            //Assert

            result.Should().NotBeNull();

            var badObjectResult = Assert.IsType<BadRequestObjectResult>(result);

        }


        [Fact]
        public async Task AuthAPIController_ValidateOTP_ReturnsOK()
        {

            //Arrange

            var _oneTimeCodeDTO = A.Fake<OneTimeCodeDTO>();
            var _loginResponseDTO = A.Fake<LoginResponseDTO>();
            A.CallTo(() => _loginResponseDTO.Token).Returns("token value");
            A.CallTo(() => _authService.ValidateOTPAsync(_oneTimeCodeDTO)).Returns(_loginResponseDTO);


            var controller = new AuthAPIController(_authService, _logger);

            //Act

            IActionResult result = await controller.ValidateOTP(_oneTimeCodeDTO);

            //Assert

            result.Should().NotBeNull();
            var okObjectResult = Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public async Task AuthAPIController_ValidateOTP_ReturnsError()
        {

            //Arrange

            var _oneTimeCodeDTO = A.Fake<OneTimeCodeDTO>();
            var _loginResponseDTO = A.Fake<LoginResponseDTO>();
            A.CallTo(() => _authService.ValidateOTPAsync(_oneTimeCodeDTO)).Returns(_loginResponseDTO);

            var controller = new AuthAPIController(_authService, _logger);

            //Act

            IActionResult result = await controller.ValidateOTP(_oneTimeCodeDTO);


            //Assert

            result.Should().NotBeNull();

            var badObjectResult = Assert.IsType<BadRequestObjectResult>(result);

        }

        [Fact]
        public async Task AuthAPIController_AssignRole_ReturnsOK()
        {

            //Arrange

            var _userRoleDTO = A.Fake<UserRoleDTO>();
            
            A.CallTo(() => _userRoleDTO.UserName).Returns("testuser");
            A.CallTo(() => _userRoleDTO.Role).Returns("Admin");
            A.CallTo(() => _authService.AssignRole(_userRoleDTO.UserName, _userRoleDTO.Role.ToUpper())).Returns(true);


            var controller = new AuthAPIController(_authService, _logger);

            //Act

            IActionResult result = await controller.AssignRole(_userRoleDTO);

            //Assert

            result.Should().NotBeNull();
            var okObjectResult = Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public async Task AuthAPIController_AssignRole_ReturnsError()
        {

            //Arrange

            var _userRoleDTO = A.Fake<UserRoleDTO>();

            A.CallTo(() => _userRoleDTO.UserName).Returns("testuser");
            A.CallTo(() => _userRoleDTO.Role).Returns("Admin");
            A.CallTo(() => _authService.AssignRole(_userRoleDTO.UserName, _userRoleDTO.Role.ToUpper())).Returns(false);


            var controller = new AuthAPIController(_authService, _logger);

            //Act

            IActionResult result = await controller.AssignRole(_userRoleDTO);


            //Assert

            result.Should().NotBeNull();

            var badObjectResult = Assert.IsType<BadRequestObjectResult>(result);

        }

    }


}