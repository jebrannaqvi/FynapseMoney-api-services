using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Moneymanager.Services.TransactionAPI.Models.DTO
{
    public class SubcategoryDTO
    {
        public int SubcategoryID { get; set; }
        public string SubcategoryName { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int CategoryTypeId { get; set; }
        public CategoryType? CategoryType { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
