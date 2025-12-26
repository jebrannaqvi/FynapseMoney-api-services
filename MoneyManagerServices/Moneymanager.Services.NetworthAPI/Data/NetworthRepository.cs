using Moneymanager.Services.NetworthAPI.Data.IRepositories;
using Moneymanager.Services.NetworthAPI.Models;

namespace Moneymanager.Services.NetworthAPI.Data
{
    public class NetworthRepository : INetworthRepository
    {
        private readonly AppDBContext _dbContext;
        public NetworthRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public FinancialAsset CreateFinancialAsset(FinancialAsset asset)
        {
            _dbContext.Assets.Add(asset);
            _dbContext.SaveChanges();
            return asset;
        }

        public FinancialLiabilities CreateFinancialLiability(FinancialLiabilities liability)
        {
            _dbContext.Liabilities.Add(liability);
            _dbContext.SaveChanges();
            return liability;
        }

        public IEnumerable<FinancialAsset> GetAllFinancialAssets()
        {
            return _dbContext.Assets.ToList();
        }

        public IEnumerable<FinancialLiabilities> GetAllFinancialLiabilities()
        {
            return _dbContext.Liabilities.ToList();
        }

        public FinancialAsset GetFinancialAssetByAccountID(int accountID)
        {
            return _dbContext.Assets.FirstOrDefault(a => a.AccountID == accountID);
        }

        public IEnumerable<FinancialAsset> GetFinancialAssetsByUserId(string userId)
        {
            return _dbContext.Assets.Where(a => a.UserId == userId).ToList();
        }

        public IEnumerable<FinancialLiabilities> GetFinancialLiabilitiesByUserId(string userId)
        {
            return _dbContext.Liabilities.Where(l => l.UserId == userId).ToList();
        }

        public FinancialLiabilities GetFinancialLiabilityByAccountID(int accountID)
        {
            return _dbContext.Liabilities.FirstOrDefault(l => l.AccountID == accountID);
        }

        public FinancialAsset UpdateFinancialAsset(FinancialAsset asset)
        {
            _dbContext.Assets.Update(asset);
            _dbContext.SaveChanges();
            return asset;
        }

        public FinancialLiabilities UpdateFinancialLiability(FinancialLiabilities liability)
        {
            _dbContext.Liabilities.Update(liability);
            _dbContext.SaveChanges();
            return liability;
        }
    }
}
