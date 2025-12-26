using Moneymanager.Services.BudgetAPI.Models;

namespace Moneymanager.Services.BudgetAPI.Data.IRepositories
{
    public interface IBudgetRepository
    {
        IEnumerable<Budgets> GetAllBudgets();
        Budgets GetBudgetById(int id);
        Budgets CreateBudget(Budgets budget);
        Budgets UpdateBudget(Budgets budget);
        
    }
}
