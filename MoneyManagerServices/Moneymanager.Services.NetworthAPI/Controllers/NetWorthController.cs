using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moneymanager.Services.NetworthAPI.Data;
using Moneymanager.Services.NetworthAPI.Models;
using Moneymanager.Services.NetworthAPI.Models.DTO;

namespace Moneymanager.Services.NetworthAPI.Controllers
{
    [Route("api/networth")]
    [ApiController]
    public class NetWorthController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        private ResponseDTO _responseDTO;
        private IMapper _mapper;

        public NetWorthController(AppDBContext dbContext, IMapper mapper)
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
                var financialAssets = _dbContext.Assets.ToList();
                var financialLiabilities = _dbContext.Liabilities.ToList();
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
                var financialAssets = _dbContext.Assets.Where(at => at.UserId == userId);
                var financialLiabilities = _dbContext.Liabilities.Where(at => at.UserId == userId);
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
                _dbContext.Assets.Add(financialAsset);
                _dbContext.SaveChanges();

                _responseDTO.Result = _mapper.Map<FinancialAssetDTO>(financialAsset);
            }
            catch (Exception ex)
            {

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
                _dbContext.Liabilities.Add(financialLiability);
                _dbContext.SaveChanges();

                _responseDTO.Result = _mapper.Map<FinancialLiabilityDTO>(financialLiability);
            }
            catch (Exception ex)
            {

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

                FinancialAsset asset = _dbContext.Assets.FirstOrDefault(a => a.AccountID == financialAssetValue.AccountID);

                asset.AssetValue = financialAssetValue.AssetValue;
                _dbContext.Assets.Update(asset);
                _dbContext.SaveChanges();

                _responseDTO.Result = _mapper.Map<FinancialAssetDTO>(asset);
            }
            catch (Exception ex)
            {

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
                FinancialLiabilities liability = _dbContext.Liabilities.FirstOrDefault(a => a.AccountID == financialLiabilityValue.AccountID);

                liability.AmountOwed = financialLiabilityValue.AmountOwed;
                _dbContext.Liabilities.Update(liability);
                _dbContext.SaveChanges();

                _responseDTO.Result = _mapper.Map<FinancialLiabilityDTO>(liability);
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
