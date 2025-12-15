using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moneymanager.Services.BudgetAPI.Data;
using Moneymanager.Services.BudgetAPI.Models;
using Moneymanager.Services.BudgetAPI.Models.DTO;

namespace Moneymanager.Services.BudgetAPI.Controllers
{
    [Route("api/budget")]
    [ApiController]
    public class BudgetAPIController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        private ResponseDTO _responseDTO;
        private IMapper _mapper;

        public BudgetAPIController(AppDBContext dbContext, IMapper mapper)
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
                var budgets = _dbContext.Budget.ToList();
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
        public ResponseDTO Get(int id)
        {
            try
            {
                var budget = _dbContext.Budget.FirstOrDefaultAsync(at => at.BudgetId == id);
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
