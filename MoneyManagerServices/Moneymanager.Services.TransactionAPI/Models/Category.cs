using System.ComponentModel.DataAnnotations;

namespace Moneymanager.Services.TransactionAPI.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public DateTime CreatedDate { get; set; }

        internal static Category[] GetPreconfiguredCategories()
        {
            return new Category[] {
                new Category() { CategoryID = 1, CategoryName = "Income", CreatedDate = DateTime.Today },
                new Category() { CategoryID = 2, CategoryName = "Auto & Transport", CreatedDate = DateTime.Today },
                new Category() { CategoryID = 3, CategoryName = "Housing", CreatedDate = DateTime.Today },
                new Category() { CategoryID = 4, CategoryName = "Bills & Utilities", CreatedDate = DateTime.Today },
                new Category() { CategoryID = 5, CategoryName = "Food & Dining", CreatedDate = DateTime.Today },
                new Category() { CategoryID = 6, CategoryName = "Shopping", CreatedDate = DateTime.Today },
                new Category() { CategoryID = 7, CategoryName = "Gifts & Donations", CreatedDate = DateTime.Today },
                new Category() { CategoryID = 8, CategoryName = "Financial", CreatedDate = DateTime.Today },
                new Category() { CategoryID = 9, CategoryName = "Children", CreatedDate = DateTime.Today },
                new Category() { CategoryID = 10, CategoryName = "Health & Fitness", CreatedDate = DateTime.Today },
                new Category() { CategoryID = 11, CategoryName = "Travel & Fun", CreatedDate = DateTime.Today },
                new Category() { CategoryID = 12, CategoryName = "Business Expenses", CreatedDate = DateTime.Today },
                new Category() { CategoryID = 13, CategoryName = "Other", CreatedDate = DateTime.Today }
            };
        }
    }
}
