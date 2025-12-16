using Moneymanager.Services.BudgetAPI.Models.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moneymanager.Services.BudgetAPI.Models
{
    public class Budget
    {
        [Key]
        public int BudgetId { get; set; }
        [Required]
        public int UserId { get; set; }
        public int SubcategoryId { get; set; }
        public double Amount { get; set; }
        
        [NotMapped]
        public SubcategoryDTO Subcategory { get; set; }
    }
}
