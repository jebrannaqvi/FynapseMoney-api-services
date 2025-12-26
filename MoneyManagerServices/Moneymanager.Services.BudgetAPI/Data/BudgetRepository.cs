using Moneymanager.Services.BudgetAPI.Data.IRepositories;
using Moneymanager.Services.BudgetAPI.Models;

namespace Moneymanager.Services.BudgetAPI.Data
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly AppDBContext _dbContext;
        public BudgetRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Budgets CreateBudget(Budgets budget)
        {
            _dbContext.Budgets.Add(budget);
            _dbContext.SaveChanges();
            return budget;

        }

        public IEnumerable<Budgets> GetAllBudgets()
        {
            return _dbContext.Budgets.ToList();
        }

        public Budgets GetBudgetById(int id)
        {
            return _dbContext.Budgets.FirstOrDefault(b => b.BudgetId == id);
        }

        public Budgets UpdateBudget(Budgets budget)
        {
            _dbContext.Budgets.Update(budget);
            _dbContext.SaveChanges();
            return budget;
        }
    }
}
