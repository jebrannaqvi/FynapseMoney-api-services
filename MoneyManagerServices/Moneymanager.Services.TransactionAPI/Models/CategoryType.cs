using System.ComponentModel.DataAnnotations;

namespace Moneymanager.Services.TransactionAPI.Models
{
    public class CategoryType
    {
        [Key]
        public int CategoryTypeID { get; set; }
        [Required]
        public string CategoryTypeName { get; set; }
        public DateTime CreatedDate { get; set; }

        internal static CategoryType[] GetPreconfiguredCategoryTypes()
        {
            return new CategoryType[] {
                new CategoryType() { CategoryTypeID = 1, CategoryTypeName = "Income", CreatedDate = DateTime.Now },
                new CategoryType() { CategoryTypeID = 2, CategoryTypeName = "Variable", CreatedDate = DateTime.Now },
                new CategoryType() { CategoryTypeID = 3, CategoryTypeName = "Fixed", CreatedDate = DateTime.Now },
                new CategoryType() { CategoryTypeID = 4, CategoryTypeName = "Other", CreatedDate = DateTime.Now }
            };
        }
    }
}
