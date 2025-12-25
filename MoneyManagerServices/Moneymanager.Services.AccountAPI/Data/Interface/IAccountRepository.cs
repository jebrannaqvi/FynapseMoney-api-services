using Moneymanager.Services.AccountAPI.Models;

namespace Moneymanager.Services.AccountAPI.Data.Interface
{
    public interface IAccountRepository
    {

        public IEnumerable<Accounts> GetAllAccounts();

        public Accounts GetAccountById(int accountId);

        public IEnumerable<Accounts> GetAccountsByUserId(string userId);

        public void CreateAccount(Accounts account);

        public void UpdateAccount(Accounts account);


    }
}
