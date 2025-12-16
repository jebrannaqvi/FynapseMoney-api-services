using Moneymanager.Services.BudgetAPI.Models.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moneymanager.Services.BudgetAPI.Models.DTO
{
    public class BudgetDTO
    {
        public int BudgetId { get; set; }
        public int UserId { get; set; }
        public int SubcategoryId { get; set; }
        public double Amount { get; set; }
        public SubcategoryDTO? Subcategory { get; set; }
    }
}
