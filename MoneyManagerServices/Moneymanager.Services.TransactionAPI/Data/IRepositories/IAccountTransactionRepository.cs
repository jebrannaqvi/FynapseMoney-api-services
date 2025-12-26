using Moneymanager.Services.TransactionAPI.Models;

namespace Moneymanager.Services.TransactionAPI.Data.IRepositories
{
    public interface IAccountTransactionRepository
    {
        public Task<IEnumerable<AccountTransactions>> GetAllTransactionsAsync();
        public Task<AccountTransactions> GetTransactionByIdAsync(int id);
        public Task<AccountTransactions> GetTransactionByAccountIdAsync(int accountId);

        public AccountTransactions CreateTransaction(AccountTransactions transaction);
        public AccountTransactions UpdateTransaction(AccountTransactions transaction);
    }
}
