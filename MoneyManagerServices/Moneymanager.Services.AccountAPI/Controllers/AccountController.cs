using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moneymanager.Services.AccountAPI.Data;
using Moneymanager.Services.AccountAPI.Models;
using Moneymanager.Services.AccountAPI.Models.DTO;

namespace Moneymanager.Services.AccountAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        private ResponseDTO _responseDTO;
        private IMapper _mapper;

        public AccountController(AppDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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
        public ResponseDTO Post([FromBody] AccountDTO actdto)
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

                _responseDTO.Result = _mapper.Map<AccountDTO>(account);
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
