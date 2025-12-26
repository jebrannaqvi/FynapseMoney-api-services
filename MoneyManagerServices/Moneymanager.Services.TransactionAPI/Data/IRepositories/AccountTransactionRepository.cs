using Microsoft.EntityFrameworkCore;
using Moneymanager.Services.TransactionAPI.Models;

namespace Moneymanager.Services.TransactionAPI.Data.IRepositories
{
    public class AccountTransactionRepository : IAccountTransactionRepository
    {
        private readonly AppDBContext _dbContext;
        public AccountTransactionRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AccountTransactions CreateTransaction(AccountTransactions transaction)
        {
            _dbContext.AccountTransactions.Update(transaction);
            _dbContext.SaveChanges();
            return transaction;
        }

        public async Task<IEnumerable<AccountTransactions>> GetAllTransactionsAsync()
        {
            return await _dbContext.AccountTransactions.Include(at => at.Subcategory)
                                                                      .ThenInclude(sc => sc.Category)
                                                                      .Include(at => at.Subcategory.CategoryType)
                                                                      .Include(at => at.TransactionType)
                                                                      .ToListAsync();
        }

        public async Task<AccountTransactions> GetTransactionByAccountIdAsync(int accountId)
        {
            return await _dbContext.AccountTransactions.Include(at => at.Subcategory)
                                                                      .ThenInclude(sc => sc.Category)
                                                                      .Include(at => at.Subcategory.CategoryType)
                                                                      .Include(at => at.TransactionType)
                                                                      .FirstOrDefaultAsync(at => at.AccountID == accountId)??new AccountTransactions();
        }

        public async Task<AccountTransactions> GetTransactionByIdAsync(int id)
        {
            return await _dbContext.AccountTransactions.Include(at => at.Subcategory)
                                                                            .ThenInclude(sc => sc.Category)
                                                                            .Include(at => at.Subcategory.CategoryType)
                                                                            .Include(at => at.TransactionType)
                                                                            .FirstOrDefaultAsync(at => at.TransactionID == id)??new AccountTransactions();
        }

        public AccountTransactions UpdateTransaction(AccountTransactions transaction)
        {
            _dbContext.AccountTransactions.Update(transaction);
            _dbContext.SaveChanges();
            return transaction;
        }
    }
}
