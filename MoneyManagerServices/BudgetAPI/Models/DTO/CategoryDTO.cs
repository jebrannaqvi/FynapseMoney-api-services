using System.ComponentModel.DataAnnotations;

namespace Moneymanager.Services.BudgetAPI.Models.DTO
{
    public class CategoryDTO
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
