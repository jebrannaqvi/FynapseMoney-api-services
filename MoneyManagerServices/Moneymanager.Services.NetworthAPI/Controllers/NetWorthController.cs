using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moneymanager.Services.NetworthAPI.Data;
using Moneymanager.Services.NetworthAPI.Data.IRepositories;
using Moneymanager.Services.NetworthAPI.Models;
using Moneymanager.Services.NetworthAPI.Models.DTO;

namespace Moneymanager.Services.NetworthAPI.Controllers
{
    [Route("api/networth")]
    [ApiController]
    public class NetWorthController : ControllerBase
    {
        private readonly INetworthRepository _networthRepository;
        private ResponseDTO _responseDTO;
        private IMapper _mapper;
        private readonly  ILogger<NetWorthController> _logger;

        public NetWorthController(INetworthRepository networthRepository, IMapper mapper, ILogger<NetWorthController> logger)
        {
            _networthRepository = networthRepository;
            _mapper = mapper;
            _responseDTO = new ResponseDTO();
            _logger = logger;
        }

        [HttpGet]
        public ResponseDTO Get()
        {
            try
            {
                var financialAssets = _networthRepository.GetAllFinancialAssets();
                var financialLiabilities = _networthRepository.GetAllFinancialLiabilities();
                var netWorth = new
                {
                    Assets = _mapper.Map<IEnumerable<FinancialAssetDTO>>(financialAssets),
                    Liabilities = _mapper.Map<IEnumerable<FinancialLiabilityDTO>>(financialLiabilities),
                    TotalAssets = financialAssets.Sum(a => a.AssetValue),
                    TotalLiabilities = financialLiabilities.Sum(l => l.AmountOwed),
                    NetWorth = financialAssets.Sum(a => a.AssetValue) - financialLiabilities.Sum(l => l.AmountOwed)
                };

                _responseDTO.Result = netWorth;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching net worth with exception message: {exception}", ex.Message);
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = ex.Message;
            }
            return _responseDTO;

        }

        [HttpGet]
        [Route("{userId}")]
        public ResponseDTO Get(string userId)
        {
            try
            {
                var financialAssets = _networthRepository.GetFinancialAssetsByUserId(userId);
                var financialLiabilities = _networthRepository.GetFinancialLiabilitiesByUserId(userId);
                var netWorth = new
                {
                    Assets = _mapper.Map<IEnumerable<FinancialAssetDTO>>(financialAssets),
                    Liabilities = _mapper.Map<IEnumerable<FinancialLiabilityDTO>>(financialLiabilities),
                    TotalAssets = financialAssets.Sum(a => a.AssetValue),
                    TotalLiabilities = financialLiabilities.Sum(l => l.AmountOwed),
                    NetWorth = financialAssets.Sum(a => a.AssetValue) - financialLiabilities.Sum(l => l.AmountOwed)
                };

                _responseDTO.Result = netWorth;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching net worth by UserID with exception message: {exception}", ex.Message);
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = ex.Message;
            }

            return _responseDTO;

        }



        [HttpPost]
        [Route("financialasset")]
        public ResponseDTO Post([FromBody] FinancialAssetDTO financialAssetDTO)
        {
            try
            {
                //TODO: Add AccountID as optional field for Financial Asset

                FinancialAsset financialAsset = _mapper.Map<FinancialAsset>(financialAssetDTO);
                _networthRepository.CreateFinancialAsset(financialAsset);

                _responseDTO.Result = _mapper.Map<FinancialAssetDTO>(financialAsset);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a new financial asset with exception message: {exception}", ex.Message);
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = ex.Message;
            }

            return _responseDTO;

        }

        [HttpPost]
        [Route("financialliability")]
        public ResponseDTO Post([FromBody] FinancialLiabilityDTO financialLiabilityDTO)
        {
            try
            {
                //TODO: Add AccountID as optional field for Financial Liability

                FinancialLiabilities financialLiability = _mapper.Map<FinancialLiabilities>(financialLiabilityDTO);
                _networthRepository.CreateFinancialLiability(financialLiability);

                _responseDTO.Result = _mapper.Map<FinancialLiabilityDTO>(financialLiability);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a new financial liability with exception message: {exception}", ex.Message);
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = ex.Message;
            }

            return _responseDTO;

        }


        [HttpPatch]
        [Route("financialasset/updatebalance")]
        public ResponseDTO UpdateBalance([FromBody] FinancialAssetValueDTO financialAssetValue)
        {
            try
            {

                FinancialAsset asset = _networthRepository.GetFinancialAssetByAccountID(financialAssetValue.AccountID);

                asset.AssetValue = financialAssetValue.AssetValue;
                _networthRepository.UpdateFinancialAsset(asset);

                _responseDTO.Result = _mapper.Map<FinancialAssetDTO>(asset);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating financial asset balance with exception message: {exception}", ex.Message);
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = ex.Message;
            }

            return _responseDTO;

        }

        [HttpPatch]
        [Route("financialliability/updatebalance")]
        public ResponseDTO UpdateBalance([FromBody] FinancialLiabilityValueDTO financialLiabilityValue)
        {
            try
            {
                FinancialLiabilities liability = _networthRepository.GetFinancialLiabilityByAccountID(financialLiabilityValue.AccountID);

                liability.AmountOwed = financialLiabilityValue.AmountOwed;
                _networthRepository.UpdateFinancialLiability(liability);

                _responseDTO.Result = _mapper.Map<FinancialLiabilityDTO>(liability);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating financial liability balance with exception message: {exception}", ex.Message);
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = ex.Message;
            }

            return _responseDTO;

        }
    }
}
