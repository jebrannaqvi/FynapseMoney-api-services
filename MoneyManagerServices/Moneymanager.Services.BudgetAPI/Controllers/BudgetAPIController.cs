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
        private readonly ILogger<BudgetAPIController> _logger;

        public BudgetAPIController(AppDBContext dbContext, IMapper mapper, IAccountTransactionService accountTransactionService, ILogger<BudgetAPIController> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _responseDTO = new ResponseDTO();
            _accountTransactionService = accountTransactionService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ResponseDTO> Get()
        {
            try
            {
                var budgets = _dbContext.Budgets.ToList();
                foreach (var budget in budgets)
                {
                    budget.Subcategory = await _accountTransactionService.GetSubcategoryById(budget.SubcategoryId);
                }

                _responseDTO.Result = _mapper.Map<IEnumerable<BudgetDTO>>(budgets);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all budgets with exception message: {exception}", ex.Message);
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
                var budget = _dbContext.Budgets.FirstOrDefault(at => at.BudgetId == id);
                if (budget != null)
                {
                    budget.Subcategory = await _accountTransactionService.GetSubcategoryById(budget.SubcategoryId);
                }
                
                _responseDTO.Result  = _mapper.Map<BudgetDTO>(budget);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching budget by ID with exception message: {exception}", ex.Message);
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
                Budgets budget = _mapper.Map<Budgets>(bdgtdto);
                _dbContext.Budgets.Add(budget);
                _dbContext.SaveChanges();

                _responseDTO.Result = _mapper.Map<BudgetDTO>(budget);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a new budget with exception message: {exception}", ex.Message);
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
                Budgets budget = _mapper.Map<Budgets>(budgetDto);
                _dbContext.Budgets.Update(budget);
                _dbContext.SaveChanges();

                _responseDTO.Result = _mapper.Map<BudgetDTO>(budget);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating budget with exception message: {exception}", ex.Message);
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = ex.Message;
            }

            return _responseDTO;

        }


    }
}
