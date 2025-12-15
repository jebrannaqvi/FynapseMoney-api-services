using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moneymanager.Services.BudgetAPI.Data;
using Moneymanager.Services.BudgetAPI.Models;
using Moneymanager.Services.BudgetAPI.Models.DTO;
using Moneymanager.Services.BudgetAPI.Services.IServices;

namespace Moneymanager.Services.BudgetAPI.Controllers
{
    [Route("api/budget")]
    [ApiController]
    public class BudgetAPIController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        private ResponseDTO _responseDTO;
        private IMapper _mapper;
        private IAccountTransactionService _accountTransactionService;

        public BudgetAPIController(AppDBContext dbContext, IMapper mapper, IAccountTransactionService accountTransactionService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _responseDTO = new ResponseDTO();
            _accountTransactionService = accountTransactionService;


        }

        [HttpGet]
        public async Task<ResponseDTO> Get()
        {
            try
            {
                var budgets = _dbContext.Budget.ToList();
                foreach (var budget in budgets)
                {
                    budget.Subcategory = await _accountTransactionService.GetSubcategoryById(budget.SubcategoryId);
                }

                _responseDTO.Result = _mapper.Map<IEnumerable<BudgetDTO>>(budgets);
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
                var budget = _dbContext.Budget.FirstOrDefault(at => at.BudgetId == id);
                if (budget != null)
                {
                    budget.Subcategory = await _accountTransactionService.GetSubcategoryById(budget.SubcategoryId);
                }
                
                _responseDTO.Result  = _mapper.Map<BudgetDTO>(budget);
            }
            catch (Exception ex)
            {

                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = ex.Message;
            }

            return _responseDTO;

        }



        [HttpPost]
        public ResponseDTO Post([FromBody] BudgetDTO bdgtdto)
        {
            try
            {
                Budget budget = _mapper.Map<Budget>(bdgtdto);
                _dbContext.Budget.Add(budget);
                _dbContext.SaveChanges();

                _responseDTO.Result = _mapper.Map<BudgetDTO>(budget);
            }
            catch (Exception ex)
            {

                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = ex.Message;
            }

            return _responseDTO;

        }


        [HttpPut]
        public ResponseDTO put([FromBody] BudgetDTO budgetDto)
        {
            try
            {
                Budget budget = _mapper.Map<Budget>(budgetDto);
                _dbContext.Budget.Update(budget);
                _dbContext.SaveChanges();

                _responseDTO.Result = _mapper.Map<BudgetDTO>(budget);
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
