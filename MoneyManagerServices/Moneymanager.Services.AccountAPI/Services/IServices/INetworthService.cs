using Moneymanager.Services.AccountAPI.Models.DTO;

namespace Moneymanager.Services.AccountAPI.Services.IServices
{
    public interface INetworthService
    {

        Task<ResponseDTO> AddAccountAsAsset(FinancialAssetDTO financialAssetDTO);
        Task<ResponseDTO> AddAccountAsLiability(FinancialLiabilityDTO financialLiabilityDTO);
        Task<ResponseDTO> UpdateAssetValue(int accountId, double newBalance);
        Task<ResponseDTO> UpdateLiabilityAmount(int accountId, double newBalance);

    }

}
