using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moneymanager.Services.TransactionAPI.Data;
using Moneymanager.Services.TransactionAPI.Models.DTO;

namespace Moneymanager.Services.TransactionAPI.Controllers
{
    [Route("api/category")]
    [ApiController]
   
    public class CategoryController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        private ResponseDTO _responseDTO;
        private IMapper _mapper;

        public CategoryController(AppDBContext dbContext, IMapper mapper)
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
                var categories = _dbContext.Categories.ToList();
                _responseDTO.Result = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
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
                var category = _dbContext.Categories.FirstOrDefault(at => at.CategoryID == id);
                _responseDTO.Result = _mapper.Map<CategoryDTO>(category);
            }
            catch (Exception ex)
            {

                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = ex.Message;
            }
            return _responseDTO;
        }

        [HttpGet]
        [Route("GetSubcategory")]
        public async Task<ResponseDTO> GetSubcategory()
        {
            try
            {
                var subcategory = await _dbContext.Subcategories.Include(at => at.Category)
                                                                .Include(at => at.CategoryType)
                                                                .ToListAsync();
                _responseDTO.Result = _mapper.Map<IEnumerable<SubcategoryDTO>>(subcategory);
            }
            catch (Exception ex)
            {

                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = ex.Message;
            }
            return _responseDTO;
        }

        [HttpGet]
        [Route("GetSubcategory/{id}")]
        public async Task<ResponseDTO> GetSubcategory(int id)
        {
            try
            {
                var subcategory = await _dbContext.Subcategories.Include(at=> at.Category)
                                                                .Include(at => at.CategoryType)
                                                                .FirstOrDefaultAsync(at => at.SubcategoryID == id);
                _responseDTO.Result = _mapper.Map<SubcategoryDTO>(subcategory);
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
