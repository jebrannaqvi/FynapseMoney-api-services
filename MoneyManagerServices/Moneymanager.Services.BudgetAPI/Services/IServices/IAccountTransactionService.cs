using Moneymanager.Services.BudgetAPI.Models.DTO;

namespace Moneymanager.Services.BudgetAPI.Services.IServices
{
    public interface IAccountTransactionService
    {
        Task<SubcategoryDTO> GetSubcategoryById(int id);
    }
}
