using AutoMapper;
using Castle.Components.DictionaryAdapter.Xml;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moneymanager.Services.AccountAPI.Controllers;
using Moneymanager.Services.AccountAPI.Data;
using Moneymanager.Services.AccountAPI.Data.Interface;
using Moneymanager.Services.AccountAPI.Models;
using Moneymanager.Services.AccountAPI.Models.DTO;
using Moneymanager.Services.AccountAPI.Services.IServices;
using static Moneymanager.Services.AccountAPI.Constants.Constants;

namespace Moneymanager.Tests.AccountAPITests
{
    public class AccountAPIControllerTests
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<AccountController> _logger;
        private IMapper _mapper;
        private INetworthService _networthService;
        public AccountAPIControllerTests()
        {

            _accountRepository = A.Fake<IAccountRepository>();
            _logger = A.Fake<ILogger<AccountController>>();
            _mapper = A.Fake<IMapper>();
            _networthService = A.Fake<INetworthService>();
        }

        [Fact]
        public void AccountAPIController_GetAllAccounts_ReturnsOK()
        {

            //Arrange
            List<Accounts> accounts = new List<Accounts>()
            {
                new Accounts
                {
                    AccountID = 1,
                    BankName = "RBC",
                    AccountType = AccountTypes.Investment,
                    CurrentBalance = 1000.00,
                },
                new Accounts
                {
                    AccountID = 2,
                    BankName  = "TD",
                    AccountType = AccountTypes.Savings,
                    CurrentBalance = 5000.00
                }
            };

            List<AccountDTO> accountDTOs = new List<AccountDTO>()
            {
                new AccountDTO
                {
                    AccountID = 1,
                    BankName = "RBC",
                    AccountType = AccountTypes.Investment,
                    CurrentBalance = 1000.00,
                },
                new AccountDTO
                {
                    AccountID = 2,
                    BankName  = "TD",
                    AccountType = AccountTypes.Savings,
                    CurrentBalance = 5000.00
                }
            };

            A.CallTo(() => _accountRepository.GetAllAccounts()).Returns(accounts);

            A.CallTo(() => _mapper.Map<IEnumerable<AccountDTO>>(accounts)).Returns(accountDTOs);

            var controller = new AccountController(_accountRepository, _mapper, _networthService, _logger);


            //Act
            var result = controller.Get();


            //Assert
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Result);
            List<AccountDTO> rtnAccountDTOs = Assert.IsType<List<AccountDTO>>(result.Result);
            Assert.Equal(2, rtnAccountDTOs.Count);

        }

        [Fact]
        public void AccountAPIController_GetAccountById_ReturnsOK()
        {

            //Arrange
            Accounts account =
                new Accounts
                {
                    AccountID = 1,
                    BankName = "RBC",
                    AccountType = AccountTypes.Investment,
                    CurrentBalance = 1000.00,
                };

            AccountDTO accountDTOs =
                new AccountDTO
                {
                    AccountID = 1,
                    BankName = "RBC",
                    AccountType = AccountTypes.Investment,
                    CurrentBalance = 1000.00,
                };



            A.CallTo(() => _accountRepository.GetAccountById(account.AccountID)).Returns(account);

            A.CallTo(() => _mapper.Map<AccountDTO>(account)).Returns(accountDTOs);

            var controller = new AccountController(_accountRepository, _mapper, _networthService, _logger);


            //Act
            var result = controller.Get(account.AccountID);


            //Assert
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Result);
            AccountDTO rtnAccountDTOs = Assert.IsType<AccountDTO>(result.Result);
            Assert.Equal(1, rtnAccountDTOs.AccountID);

        }

        [Fact]
        public void AccountAPIController_GetAccountByUserID_ReturnsOK()
        {

            //Arrange
            List<Accounts> accounts = new List<Accounts>()
            {
                new Accounts
                {
                    AccountID = 1,
                    BankName = "RBC",
                    AccountType = AccountTypes.Investment,
                    CurrentBalance = 1000.00,
                    UserID = "user1"
                },
                new Accounts
                {
                    AccountID = 2,
                    BankName  = "TD",
                    AccountType = AccountTypes.Savings,
                    CurrentBalance = 5000.00,
                    UserID = "user1"
                }
            };

            List<AccountDTO> accountDTOs = new List<AccountDTO>()
            {
                new AccountDTO
                {
                    AccountID = 1,
                    BankName = "RBC",
                    AccountType = AccountTypes.Investment,
                    CurrentBalance = 1000.00,
                    UserID = "user1"
                },
                new AccountDTO
                {
                    AccountID = 2,
                    BankName  = "TD",
                    AccountType = AccountTypes.Savings,
                    CurrentBalance = 5000.00,
                    UserID = "user1"
                }
            };

            A.CallTo(() => _accountRepository.GetAccountsByUserId("user1")).Returns(accounts);

            A.CallTo(() => _mapper.Map<IEnumerable<AccountDTO>>(accounts)).Returns(accountDTOs);

            var controller = new AccountController(_accountRepository, _mapper, _networthService, _logger);


            //Act
            var result = controller.GetByUserID("user1");


            //Assert
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Result);
            List<AccountDTO> rtnAccountDTOs = Assert.IsType<List<AccountDTO>>(result.Result);
            Assert.Equal(2, rtnAccountDTOs.Count);

        }

        [Fact]
        public async Task AccountAPIController_PostAccount_ReturnsOK()
        {

            //Arrange
            Accounts account =
                new Accounts
                {
                    AccountID = 1,
                    BankName = "RBC",
                    AccountType = AccountTypes.Investment,
                    StartingBalance = 1000.00,
                    UserID = "test1"
                };

            AccountDTO accountDTOs =
                new AccountDTO
                {
                    AccountID = 1,
                    BankName = "RBC",
                    AccountType = AccountTypes.Investment,
                    StartingBalance = 1000.00,
                    CurrentBalance = 0,
                    UserID = "test1"
                };

            FinancialAssetDTO financialAsset = A.Fake<FinancialAssetDTO>();
            FinancialLiabilityDTO financialLiability = A.Fake<FinancialLiabilityDTO>();
            ResponseDTO responseDTO = A.Fake<ResponseDTO>();



            A.CallTo(() => _accountRepository.CreateAccount(account)).DoesNothing();

            A.CallTo(() => _networthService.AddAccountAsAsset(financialAsset)).Returns(responseDTO);

            A.CallTo(() => _mapper.Map<AccountDTO>(account)).Returns(accountDTOs);
            A.CallTo(() => _mapper.Map<Accounts>(accountDTOs)).Returns(account);

            var controller = new AccountController(_accountRepository, _mapper, _networthService, _logger);


            //Act
            var result = await controller.Post(accountDTOs);


            //Assert
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Result);

        }

        [Fact]
        public async Task AccountAPIController_PostAccount_ReturnsFailure()
        {

            //Arrange
            Accounts account =
                 new Accounts
                 {
                     AccountID = 1,
                     BankName = "RBC",
                     StartingBalance = 1000.00
                 };

            AccountDTO accountDTOs = A.Fake<AccountDTO>();

            FinancialAssetDTO financialAsset = A.Fake<FinancialAssetDTO>();
            FinancialLiabilityDTO financialLiability = A.Fake<FinancialLiabilityDTO>();
            ResponseDTO responseDTO = A.Fake<ResponseDTO>();



            //A.CallTo(() => _accountRepository.CreateAccount(account)).DoesNothing();

            A.CallTo(() => _networthService.AddAccountAsAsset(financialAsset)).Returns(responseDTO);

            A.CallTo(() => _mapper.Map<AccountDTO>(account)).Returns(accountDTOs);
            A.CallTo(() => _mapper.Map<Accounts>(accountDTOs)).Returns(account);

            var controller = new AccountController(_accountRepository, _mapper, _networthService, _logger);


            //Act
            var result = await controller.Post(accountDTOs);


            //Assert
            Assert.NotNull(result);
            Assert.False(result.IsSuccess);
            Assert.Null(result.Result);
            //AccountDTO rtnResponse = Assert.IsType<ResponseDTO>(result.Result);

            //Assert.Equal(1, rtnAccountDTOs.AccountID);

        }

        [Fact]
        public void AccountAPIController_PutAccount_ReturnsOk()
        {

            Accounts account =
               new Accounts
               {
                   AccountID = 1,
                   BankName = "RBC",
                   AccountType = AccountTypes.Investment,
                   StartingBalance = 1000.00,
                   UserID = "test1"
               };

            AccountDTO accountDTOs =
                new AccountDTO
                {
                    AccountID = 1,
                    BankName = "RBC",
                    AccountType = AccountTypes.Investment,
                    StartingBalance = 1000.00,
                    CurrentBalance = 0,
                    UserID = "test1"
                };

            FinancialAssetDTO financialAsset = A.Fake<FinancialAssetDTO>();
            FinancialLiabilityDTO financialLiability = A.Fake<FinancialLiabilityDTO>();
            ResponseDTO responseDTO = A.Fake<ResponseDTO>();



            A.CallTo(() => _accountRepository.UpdateAccount(account)).DoesNothing();

            A.CallTo(() => _networthService.AddAccountAsAsset(financialAsset)).Returns(responseDTO);

            A.CallTo(() => _mapper.Map<AccountDTO>(account)).Returns(accountDTOs);
            A.CallTo(() => _mapper.Map<Accounts>(accountDTOs)).Returns(account);

            var controller = new AccountController(_accountRepository, _mapper, _networthService, _logger);


            //Act
            var result = controller.put(accountDTOs);


            //Assert
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Result);


        }

        [Fact]
        public void AccountAPIController_PutAccount_ReturnsFailure()
        {
            //Arrange
            Accounts account =
                 new Accounts
                 {
                     AccountID = 1,
                     BankName = "RBC",
                     StartingBalance = 1000.00
                 };

            AccountDTO accountDTOs = A.Fake<AccountDTO>();

            FinancialAssetDTO financialAsset = A.Fake<FinancialAssetDTO>();
            FinancialLiabilityDTO financialLiability = A.Fake<FinancialLiabilityDTO>();
            ResponseDTO responseDTO = A.Fake<ResponseDTO>();



            //A.CallTo(() => _accountRepository.CreateAccount(account)).DoesNothing();

            A.CallTo(() => _networthService.AddAccountAsAsset(financialAsset)).Returns(responseDTO);

            A.CallTo(() => _mapper.Map<AccountDTO>(account)).Returns(accountDTOs);
            A.CallTo(() => _mapper.Map<Accounts>(accountDTOs)).Returns(account);

            var controller = new AccountController(_accountRepository, _mapper, _networthService, _logger);


            //Act
            var result = controller.put(accountDTOs);


            //Assert
            Assert.NotNull(result);
            Assert.False(result.IsSuccess);
            Assert.Null(result.Result);

        }

        [Fact]
        public void AccountAPIController_UpdateBalance_ReturnsOk()
        {

            //Arrange
            AccountBalanceDTO accountBalanceDTO = new AccountBalanceDTO
            {
                AccountID = 1,
                TransactionAmount = 2000.00
            };

            Accounts account = A.Fake<Accounts>();
            AccountDTO accountDTOs = A.Fake<AccountDTO>();


            A.CallTo(() => _mapper.Map<AccountDTO>(account)).Returns(accountDTOs);
            A.CallTo(() => _mapper.Map<Accounts>(accountDTOs)).Returns(account);



            var controller = new AccountController(_accountRepository, _mapper, _networthService, _logger);

            //Act
            var result = controller.UpdateBalance(accountBalanceDTO);
            //Assert
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Result);
        }

        [Fact]
        public void AccountAPIController_UpdateBalance_ReturnsFailure()
        {

            //Arrange
            AccountBalanceDTO accountBalanceDTO = A.Fake<AccountBalanceDTO>();

            Accounts account = A.Fake<Accounts>();
            AccountDTO accountDTOs = A.Fake<AccountDTO>();


            A.CallTo(() => _mapper.Map<AccountDTO>(account)).Returns(accountDTOs);
            A.CallTo(() => _mapper.Map<Accounts>(accountDTOs)).Returns(account);



            var controller = new AccountController(_accountRepository, _mapper, _networthService, _logger);

            //Act
            var result = controller.UpdateBalance(accountBalanceDTO);
            //Assert
            Assert.NotNull(result);
            Assert.False(result.IsSuccess);
            Assert.Null(result.Result);
        }

    }
}