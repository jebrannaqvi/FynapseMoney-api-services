using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moneymanager.Services.AccountAPI.Data;
using Moneymanager.Services.AccountAPI.Data.Interface;
using Moneymanager.Services.AccountAPI.Models;
using Moneymanager.Services.AccountAPI.Models.DTO;
using Moneymanager.Services.AccountAPI.Services.IServices;

namespace Moneymanager.Services.AccountAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private ResponseDTO _responseDTO;
        private IMapper _mapper;
        private INetworthService _networthService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountRepository accountRepository, IMapper mapper, INetworthService networthService, ILogger<AccountController> logger)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _networthService = networthService;
            _responseDTO = new ResponseDTO();
            _logger = logger;
        }

        [HttpGet]
        public ResponseDTO Get()
        {
            try
            {
                _logger.LogInformation("Fetching all accounts");
                var account = _accountRepository.GetAllAccounts();
                _responseDTO.Result = _mapper.Map<IEnumerable<AccountDTO>>(account);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching accounts with exception message: {exception}", ex.Message);
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = ex.Message;
            }
            return _responseDTO;

        }

        [HttpGet]
        [Route("{id}")]
        public ResponseDTO Get(int id)
        {
            try
            {

                var account = _accountRepository.GetAccountById(id);
                _responseDTO.Result = _mapper.Map<AccountDTO>(account);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error occurred while fetching account by ID with exception message: {exception}", ex.Message);
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = ex.Message;
            }

            return _responseDTO;

        }

        [HttpGet]
        [Route("GetByUserID/{userid}")]
        public ResponseDTO GetByUserID(string userid)
        {
            try
            {
                var account = _accountRepository.GetAccountsByUserId(userid);
                _responseDTO.Result = _mapper.Map<IEnumerable<AccountDTO>>(account);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching account by ID with exception message: {exception}", ex.Message);
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = ex.Message;
            }

            return _responseDTO;

        }

        [HttpPost]
        public async Task<ResponseDTO> Post([FromBody] AccountDTO actdto)
        {
            try
            {


                if (actdto.AccountType is null || String.IsNullOrEmpty(actdto.BankName) || String.IsNullOrEmpty(actdto.UserID))
                {
                    throw new Exception("Invalid input values");

                }
                Accounts account = _mapper.Map<Accounts>(actdto);

                if (actdto.CurrentBalance == 0)
                {
                    account.CurrentBalance = actdto.StartingBalance;
                }
                _accountRepository.CreateAccount(account);


                // TODO: Post to NetworthAPI and add new financial asset or financial liability based on AccountType. 
                if (account.AccountType == Constants.Constants.AccountTypes.Credit)
                {
                    FinancialLiabilityDTO financialLiability = new()
                    {
                        AccountID = account.AccountID,
                        UserId = account.UserID,
                        LiabilityName = account.BankName,
                        AmountOwed = account.CurrentBalance
                    };

                    await _networthService.AddAccountAsLiability(financialLiability);
                }
                else
                {
                    FinancialAssetDTO financialAsset = new()
                    {
                        AccountID = account.AccountID,
                        UserId = account.UserID,
                        AssetName = account.BankName,
                        AssetType = Constants.Constants.AssetType.Cash,
                        AssetValue = account.CurrentBalance
                    };

                    await _networthService.AddAccountAsAsset(financialAsset);
                }


                _responseDTO.Result = _mapper.Map<AccountDTO>(account);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding new account with exception message: {exception}", ex.Message);
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = ex.Message;
            }

            return _responseDTO;

        }

        [HttpPut]
        public ResponseDTO put([FromBody] AccountDTO actDTO)
        {
            try
            {
                if (actDTO.AccountType is null || String.IsNullOrEmpty(actDTO.BankName) || String.IsNullOrEmpty(actDTO.UserID)
                    || actDTO.AccountID == 0)
                {
                    throw new Exception("Invalid input values");

                }

                Accounts account = _mapper.Map<Accounts>(actDTO);
                _accountRepository.UpdateAccount(account);

                // TODO: Post to NetworthAPI and update existing financial asset or financial liability based on AccountType. 

                _responseDTO.Result = _mapper.Map<AccountDTO>(account);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating account with exception message: {exception}", ex.Message);
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = ex.Message;
            }

            return _responseDTO;

        }

        [HttpPost]
        [Route("updatebalance")]
        public ResponseDTO UpdateBalance([FromBody] AccountBalanceDTO abDTO)
        {
            try
            {
                if (abDTO.AccountID == 0 || abDTO.TransactionAmount == 0)
                {
                    throw new Exception("Invalid input values");

                }

                Accounts? account = _accountRepository.GetAccountById(abDTO.AccountID);

                if (account != null)
                {
                    if (account.AccountType == Constants.Constants.AccountTypes.Credit)
                    {
                        abDTO.TransactionAmount = -abDTO.TransactionAmount;
                    }
                    account.CurrentBalance = account.CurrentBalance + abDTO.TransactionAmount;
                    _accountRepository.UpdateAccount(account);

                    // update balance in NetworthAPI
                    if (account.AccountType == Constants.Constants.AccountTypes.Credit)
                    {
                        _networthService.UpdateLiabilityAmount(account.AccountID, account.CurrentBalance);
                    }
                    else
                    {
                        _networthService.UpdateAssetValue(account.AccountID, account.CurrentBalance);
                    }

                    _responseDTO.Result = _mapper.Map<AccountDTO>(account);
                }
                else
                {
                    _responseDTO.IsSuccess = false;
                    _responseDTO.DisplayMessage = "Account not found.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating account balance with exception message: {exception}", ex.Message);
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = ex.Message;
            }

            return _responseDTO;

        }

    }
}
