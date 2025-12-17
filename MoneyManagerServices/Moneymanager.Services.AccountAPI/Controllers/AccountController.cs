using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moneymanager.Services.AccountAPI.Data;
using Moneymanager.Services.AccountAPI.Models;
using Moneymanager.Services.AccountAPI.Models.DTO;
using Moneymanager.Services.AccountAPI.Services.IServices;

namespace Moneymanager.Services.AccountAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        private ResponseDTO _responseDTO;
        private IMapper _mapper;
        private INetworthService _networthService;

        public AccountController(AppDBContext dbContext, IMapper mapper, INetworthService networthService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _networthService = networthService;
            _responseDTO = new ResponseDTO();
        }

        [HttpGet]
        public ResponseDTO Get()
        {
            try
            {
                var account = _dbContext.Accounts.ToList();
                _responseDTO.Result = _mapper.Map<IEnumerable<AccountDTO>>(account);
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
        public ResponseDTO Get(int id)
        {
            try
            {
                var account = _dbContext.Accounts.FirstOrDefault(at => at.AccountID == id);
                _responseDTO.Result = _mapper.Map<AccountDTO>(account);
            }
            catch (Exception ex)
            {

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
                var account = _dbContext.Accounts.Where(at => at.UserID == userid).ToList();
                _responseDTO.Result = _mapper.Map<IEnumerable<AccountDTO>>(account);
            }
            catch (Exception ex)
            {

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
                Accounts account = _mapper.Map<Accounts>(actdto);
                if (actdto.CurrentBalance == 0)
                {
                    account.CurrentBalance = actdto.StartingBalance;
                }
                _dbContext.Accounts.Add(account);
                _dbContext.SaveChanges();

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
                Accounts account = _mapper.Map<Accounts>(actDTO);
                _dbContext.Accounts.Update(account);
                _dbContext.SaveChanges();

                // TODO: Post to NetworthAPI and update existing financial asset or financial liability based on AccountType. 

                _responseDTO.Result = _mapper.Map<AccountDTO>(account);
            }
            catch (Exception ex)
            {

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
                Accounts? account = _dbContext.Accounts.FirstOrDefault(at => at.AccountID == abDTO.AccountID);

                if (account != null)
                {
                    if (account.AccountType == Constants.Constants.AccountTypes.Credit)
                    {
                        abDTO.TransactionAmount = -abDTO.TransactionAmount;
                    }
                    account.CurrentBalance = account.CurrentBalance + abDTO.TransactionAmount;
                    _dbContext.Accounts.Update(account);
                    _dbContext.SaveChanges();

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

                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = ex.Message;
            }

            return _responseDTO;

        }

    }
}
