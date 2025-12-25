using Microsoft.EntityFrameworkCore;
using Moneymanager.Services.AccountAPI.Data.Interface;
using Moneymanager.Services.AccountAPI.Models;

namespace Moneymanager.Services.AccountAPI.Data
{
    public class AccountRepository : IAccountRepository
    {

        private readonly AppDBContext _dbContext;
        public AccountRepository(AppDBContext appDBContext) 
        { 
            _dbContext = appDBContext;
        }

        public void CreateAccount(Accounts account)
        {
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
        }

        public Accounts GetAccountById(int accountId)
        {
            return _dbContext.Accounts.FirstOrDefault(at => at.AccountID == accountId);
        }

        public IEnumerable<Accounts> GetAccountsByUserId(string userId)
        {
            return _dbContext.Accounts.Where(at => at.UserID == userId).ToList(); 
        }

        public IEnumerable<Accounts> GetAllAccounts()
        {
            return _dbContext.Accounts.ToList();
        }

        public void UpdateAccount(Accounts account)
        {
            _dbContext.Accounts.Update(account);
            _dbContext.SaveChanges();
        }
    }
}
