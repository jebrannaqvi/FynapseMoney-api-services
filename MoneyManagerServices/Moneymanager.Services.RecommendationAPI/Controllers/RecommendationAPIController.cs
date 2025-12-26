using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moneymanager.Services.RecommendationAPI.Data;
using Moneymanager.Services.RecommendationAPI.Data.IRepositories;
using Moneymanager.Services.RecommendationAPI.Models;
using Moneymanager.Services.RecommendationAPI.Models.DTO;

namespace Moneymanager.Services.RecommendationAPI.Controllers
{
    [Route("api/recommendation")]
    [ApiController]
    public class RecommendationAPIController : ControllerBase
    {
        private readonly IRecommendationRepository _recommendationRepository;
        private ResponseDTO _responseDTO;
        private IMapper _mapper;
        private readonly ILogger<RecommendationAPIController> _logger;

        public RecommendationAPIController(IRecommendationRepository recommendationRepository, IMapper mapper, ILogger<RecommendationAPIController> logger)
        {
            _recommendationRepository = recommendationRepository;
            _mapper = mapper;
            _responseDTO = new ResponseDTO();
            _logger = logger;


        }

        [HttpGet]
        public ResponseDTO Get()
        {
            try
            {
                var recommendation = _recommendationRepository.GetAllRecommendations();
                _responseDTO.Result = _mapper.Map<IEnumerable<RecommendationDTO>>(recommendation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all recommendations with exception message: {exception}", ex.Message);
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
                var recommendation = _recommendationRepository.GetRecommendationById(id);
                _responseDTO.Result  = _mapper.Map<RecommendationDTO>(recommendation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching recommendation by id with exception message: {exception}", ex.Message);
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
                _recommendationRepository.CreateRecommendation(recommendation);

                _responseDTO.Result = _mapper.Map<RecommendationDTO>(recommendation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating recommendation with exception message: {exception}", ex.Message);
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
                _recommendationRepository.UpdateRecommendation(recommendation);

                _responseDTO.Result = _mapper.Map<RecommendationDTO>(recommendation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating recommendation with exception message: {exception}", ex.Message);
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = ex.Message;
            }

            return _responseDTO;

        }


    }
}
