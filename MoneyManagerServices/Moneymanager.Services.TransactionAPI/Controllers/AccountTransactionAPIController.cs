using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moneymanager.Services.TransactionAPI.Data;
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
        private readonly AppDBContext _dbContext;
        private ResponseDTO _responseDTO;
        private IMapper _mapper;
        private IAccountService _accountService;

        public AccountTransactionAPIController(AppDBContext dbContext, IMapper mapper, IAccountService accountService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _accountService = accountService;
            _responseDTO = new ResponseDTO();


        }

        [HttpGet]
        public async Task<ResponseDTO> Get()
        {
            try
            {
                var transactions = await _dbContext.AccountTransactions.Include(at => at.Subcategory)
                                                                      .ThenInclude(sc => sc.Category)
                                                                      .Include(at => at.Subcategory.CategoryType)
                                                                      .Include(at => at.TransactionType)
                                                                      .ToListAsync();

                _responseDTO.Result = _mapper.Map<IEnumerable<AccountTransactionDTO>>(transactions);
            }
            catch (Exception ex)
            {

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
                var accountTransaction = await _dbContext.AccountTransactions.Include(at => at.Subcategory)
                                                                            .ThenInclude(sc => sc.Category)
                                                                            .Include(at => at.Subcategory.CategoryType)
                                                                            .Include(at => at.TransactionType)
                                                                            .FirstOrDefaultAsync(at => at.TransactionID == id);

                _responseDTO.Result  = _mapper.Map<AccountTransactionDTO>(accountTransaction);
            }
            catch (Exception ex)
            {

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
                var accountTransactions = await _dbContext.AccountTransactions.Include(at => at.Subcategory)
                                                                           .ThenInclude(sc => sc.Category)
                                                                           .Include(at => at.Subcategory.CategoryType)
                                                                           .Include(at => at.TransactionType)
                                                                           .Where(u => u.AccountID == accountId)
                                                                           .ToListAsync();

                _responseDTO.Result = _mapper.Map<IEnumerable<AccountTransactionDTO>>(accountTransactions);
            }
            catch (Exception ex)
            {

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
                _dbContext.AccountTransactions.Add(accountTransaction);
                _dbContext.SaveChanges();

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
                    _dbContext.AccountTransactions.Update(accountTransaction);
                    _dbContext.SaveChanges();
                }
                
                _responseDTO.Result = _mapper.Map<AccountTransactionDTO>(accountTransaction);
            }
            catch (Exception ex)
            {

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
                    AccountTransactions prevTransaction = _dbContext.AccountTransactions.FirstOrDefault(at => at.TransactionID == accountTransaction.TransactionID);

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

                    _dbContext.AccountTransactions.Entry(prevTransaction).State = EntityState.Detached;

                    //Update transaction in DB
                    _dbContext.AccountTransactions.Update(accountTransaction);
                    _dbContext.SaveChanges();


                }
                else
                {
                    throw new Exception("Invalid TransactionID");
                }

                _responseDTO.Result = _mapper.Map<AccountTransactionDTO>(accountTransaction);
            }
            catch (Exception ex)
            {

                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = ex.Message;
            }

            return _responseDTO;

        }


    }
}
