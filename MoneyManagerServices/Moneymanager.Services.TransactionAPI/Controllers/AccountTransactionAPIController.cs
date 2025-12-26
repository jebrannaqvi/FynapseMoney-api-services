using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moneymanager.Services.TransactionAPI.Data;
using Moneymanager.Services.TransactionAPI.Data.IRepositories;
using Moneymanager.Services.TransactionAPI.Models;
using Moneymanager.Services.TransactionAPI.Models.DTO;
using Moneymanager.Services.TransactionAPI.Services;
using Moneymanager.Services.TransactionAPI.Services.IServices;

namespace Moneymanager.Services.TransactionAPI.Controllers
{
    [Route("api/accountTransaction")]
    [ApiController]
    public class AccountTransactionAPIController : ControllerBase
    {
        private readonly IAccountTransactionRepository _accountTransactionRepository;
        private ResponseDTO _responseDTO;
        private IMapper _mapper;
        private IAccountService _accountService;
        private readonly ILogger<AccountTransactionAPIController> _logger;

        public AccountTransactionAPIController(IAccountTransactionRepository accountTransactionRepository, IMapper mapper, IAccountService accountService, ILogger<AccountTransactionAPIController> logger)
        {
            _accountTransactionRepository = accountTransactionRepository;
            _mapper = mapper;
            _accountService = accountService;
            _responseDTO = new ResponseDTO();
            _logger = logger;
        }

        [HttpGet]
        public async Task<ResponseDTO> Get()
        {
            try
            {
                var transactions = await _accountTransactionRepository.GetAllTransactionsAsync();

                _responseDTO.Result = _mapper.Map<IEnumerable<AccountTransactionDTO>>(transactions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all account transactions with exception message: {exception}", ex.Message);
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = ex.Message;
            }
            return _responseDTO;

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ResponseDTO> Get(int id)
        {
            try
            {
                var accountTransaction = await _accountTransactionRepository.GetTransactionByIdAsync(id);

                _responseDTO.Result  = _mapper.Map<AccountTransactionDTO>(accountTransaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching account transaction by ID with exception message: {exception}", ex.Message);
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = ex.Message;
            }

            return _responseDTO;

        }

        [HttpGet]
        [Route("GetByAccountID/{accountId}")]
        public async Task<ResponseDTO> GetByBankID(int accountId)
        {
            try
            {
                var accountTransactions = await _accountTransactionRepository.GetTransactionByAccountIdAsync(accountId);

                _responseDTO.Result = _mapper.Map<IEnumerable<AccountTransactionDTO>>(accountTransactions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching account transactions by AccountID with exception message: {exception}", ex.Message);
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = ex.Message;
            }

            return _responseDTO;

        }


        [HttpPost]
        public async Task<ResponseDTO> Post([FromBody] AccountTransactionDTO actTrnDto)
        {
            try
            {
                AccountTransactions accountTransaction = _mapper.Map<AccountTransactions>(actTrnDto);
                _accountTransactionRepository.CreateTransaction(accountTransaction);

                // Update current balance of the associated account
                AccountBalanceDTO accountBalanceUpdate = new AccountBalanceDTO
                {
                    AccountID = accountTransaction.AccountID,
                    TransactionAmount = accountTransaction.TransactionTypeID == 1 ? accountTransaction.Amount : -accountTransaction.Amount
                };

                ResponseDTO accountResponse = await _accountService.UpdateAccountBalance(accountBalanceUpdate);

                if (accountResponse.IsSuccess)
                {
                    accountTransaction.BalanceUpdated = true;
                    _accountTransactionRepository.UpdateTransaction(accountTransaction);
                }
                
                _responseDTO.Result = _mapper.Map<AccountTransactionDTO>(accountTransaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a new account transaction with exception message: {exception}", ex.Message);
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = ex.Message;
            }

            return _responseDTO;

        }


        [HttpPut]
        public ResponseDTO put([FromBody] AccountTransactionDTO actTrnDto)
        {
            try
            {
                AccountTransactions accountTransaction = _mapper.Map<AccountTransactions>(actTrnDto);
                if (actTrnDto.TransactionID != 0)
                {
                    AccountTransactions prevTransaction = _accountTransactionRepository.GetTransactionByIdAsync(actTrnDto.TransactionID).GetAwaiter().GetResult();

                    if (prevTransaction != null && prevTransaction.Amount != accountTransaction.Amount)
                    {
                        // Update current balance of the associated account
                        var amountDifference = accountTransaction.Amount - prevTransaction.Amount; 
                        AccountBalanceDTO accountBalanceUpdate = new AccountBalanceDTO
                        {
                            AccountID = accountTransaction.AccountID,
                            TransactionAmount = accountTransaction.TransactionTypeID == 1 ? amountDifference : -amountDifference
                        };

                        ResponseDTO accountResponse = _accountService.UpdateAccountBalance(accountBalanceUpdate).GetAwaiter().GetResult();

                        accountTransaction.BalanceUpdated = accountResponse.IsSuccess;
                        
                    }

                    //_dbContext.AccountTransactions.Entry(prevTransaction).State = EntityState.Detached;

                    //Update transaction in DB
                    _accountTransactionRepository.UpdateTransaction(accountTransaction);


                }
                else
                {
                    throw new Exception("Invalid TransactionID");
                }

                _responseDTO.Result = _mapper.Map<AccountTransactionDTO>(accountTransaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating account transaction with exception message: {exception}", ex.Message);
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = ex.Message;
            }

            return _responseDTO;

        }


    }
}
