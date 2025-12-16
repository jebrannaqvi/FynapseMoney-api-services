using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moneymanager.Services.RecommendationAPI.Data;
using Moneymanager.Services.RecommendationAPI.Models;
using Moneymanager.Services.RecommendationAPI.Models.DTO;

namespace Moneymanager.Services.RecommendationAPI.Controllers
{
    [Route("api/recommendation")]
    [ApiController]
    public class RecommendationAPIController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        private ResponseDTO _responseDTO;
        private IMapper _mapper;

        public RecommendationAPIController(AppDBContext dbContext, IMapper mapper)
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
                var recommendation = _dbContext.Recommendations.ToList();
                _responseDTO.Result = _mapper.Map<IEnumerable<RecommendationDTO>>(recommendation);
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
                var recommendation = _dbContext.Recommendations.FirstOrDefault(at => at.RecommendationId == id);
                _responseDTO.Result  = _mapper.Map<RecommendationDTO>(recommendation);
            }
            catch (Exception ex)
            {

                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = ex.Message;
            }

            return _responseDTO;

        }



        [HttpPost]
        public ResponseDTO Post([FromBody] RecommendationDTO recdto)
        {
            try
            {
                Recommendations recommendation = _mapper.Map<Recommendations>(recdto);
                _dbContext.Recommendations.Add(recommendation);
                _dbContext.SaveChanges();

                _responseDTO.Result = _mapper.Map<RecommendationDTO>(recommendation);
            }
            catch (Exception ex)
            {

                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = ex.Message;
            }

            return _responseDTO;

        }


        [HttpPut]
        public ResponseDTO put([FromBody] RecommendationDTO recommendationDTO)
        {
            try
            {
                Recommendations recommendation = _mapper.Map<Recommendations>(recommendationDTO);
                _dbContext.Recommendations.Update(recommendation);
                _dbContext.SaveChanges();

                _responseDTO.Result = _mapper.Map<RecommendationDTO>(recommendation);
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
