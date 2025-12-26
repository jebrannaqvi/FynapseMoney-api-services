using Moneymanager.Services.NetworthAPI.Models;

namespace Moneymanager.Services.NetworthAPI.Data.IRepositories
{
    public interface INetworthRepository
    {

        public IEnumerable<FinancialAsset> GetAllFinancialAssets();

        public IEnumerable<FinancialLiabilities> GetAllFinancialLiabilities();

        public IEnumerable<FinancialAsset> GetFinancialAssetsByUserId(string userId);
        public IEnumerable<FinancialLiabilities> GetFinancialLiabilitiesByUserId(string userId);

        public FinancialAsset GetFinancialAssetByAccountID(int accountID);
        public FinancialLiabilities GetFinancialLiabilityByAccountID(int accountID);

        public FinancialAsset CreateFinancialAsset(FinancialAsset asset);
        public FinancialLiabilities CreateFinancialLiability(FinancialLiabilities liability);

        public FinancialAsset UpdateFinancialAsset(FinancialAsset asset);
        public FinancialLiabilities UpdateFinancialLiability(FinancialLiabilities liability);

    }
}
