using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moneymanager.Services.BudgetAPI.Data;
using Moneymanager.Services.BudgetAPI.Data.IRepositories;
using Moneymanager.Services.BudgetAPI.Models;
using Moneymanager.Services.BudgetAPI.Models.DTO;
using Moneymanager.Services.BudgetAPI.Services.IServices;

namespace Moneymanager.Services.BudgetAPI.Controllers
{
    [Route("api/budget")]
    [ApiController]
    public class BudgetAPIController : ControllerBase
    {
        private readonly IBudgetRepository _budgetRepository;
        private ResponseDTO _responseDTO;
        private IMapper _mapper;
        private IAccountTransactionService _accountTransactionService;
        private readonly ILogger<BudgetAPIController> _logger;

        public BudgetAPIController(IBudgetRepository budgetRepository, IMapper mapper, IAccountTransactionService accountTransactionService, ILogger<BudgetAPIController> logger)
        {
            _budgetRepository = budgetRepository;
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
                var budgets = _budgetRepository.GetAllBudgets();
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
                var budget = _budgetRepository.GetBudgetById(id);
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
                _budgetRepository.CreateBudget(budget);

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
                _budgetRepository.UpdateBudget(budget);

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
