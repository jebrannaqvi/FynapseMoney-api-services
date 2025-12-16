using Moneymanager.Services.BudgetAPI.Models.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moneymanager.Services.BudgetAPI.Models
{
    public class Budgets
    {
        [Key]
        public int BudgetId { get; set; }
        [Required]
        public string UserId { get; set; }
        public int SubcategoryId { get; set; }
        public double Amount { get; set; }
        
        [NotMapped]
        public SubcategoryDTO Subcategory { get; set; }
    }
}
