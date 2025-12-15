using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moneymanager.Services.TransactionAPI.Models
{
    public class Subcategory
    {
        [Key]
        public int SubcategoryID { get; set; }
        [Required]
        public string SubcategoryName { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int CategoryTypeId { get; set; }
        [ForeignKey("CategoryTypeId")]
        public CategoryType CategoryType { get; set; }
        public DateTime CreatedDate { get; set; }

        internal static Subcategory[] GetPreconfiguredSubcategories()
        {
            return new Subcategory[]
            {
                // Income Subcategories
                new Subcategory() { SubcategoryID = 1, SubcategoryName = "Freelance", CategoryId = 1, CategoryTypeId = 1, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 2, SubcategoryName = "Rental Income", CategoryId = 1, CategoryTypeId = 1, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 3, SubcategoryName = "Investment Income", CategoryId = 1, CategoryTypeId = 1, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 4, SubcategoryName = "Bonus", CategoryId = 1, CategoryTypeId = 1, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 5, SubcategoryName = "Interest", CategoryId = 1, CategoryTypeId = 1, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 6, SubcategoryName = "Other Income", CategoryId = 1, CategoryTypeId = 1, CreatedDate = DateTime.Now },
                
                // Auto and Transport Subcategories
                new Subcategory() { SubcategoryID = 7, SubcategoryName = "Auto Payment", CategoryId = 2, CategoryTypeId = 3, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 8, SubcategoryName = "Public Transportation", CategoryId = 2, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 9, SubcategoryName = "Fuel & Gasoline", CategoryId = 2, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 10, SubcategoryName = "Ridesharing & Taxis", CategoryId = 2, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 11, SubcategoryName = "Vehicle Maintenance & Repairs", CategoryId = 2, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 12, SubcategoryName = "Parking & Tolls", CategoryId = 2, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                
                // Housing Subcategories
                new Subcategory() { SubcategoryID = 13, SubcategoryName = "Mortgage", CategoryId = 3, CategoryTypeId = 3, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 14, SubcategoryName = "Rent", CategoryId = 3, CategoryTypeId = 3, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 15, SubcategoryName = "Property Tax", CategoryId = 3, CategoryTypeId = 3, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 16, SubcategoryName = "Home Improvements", CategoryId = 3, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 17, SubcategoryName = "Home Security", CategoryId = 3, CategoryTypeId = 3, CreatedDate = DateTime.Now },
                
                // Bills and Utilities Subcategories
                new Subcategory() { SubcategoryID = 18, SubcategoryName = "Home Gas", CategoryId = 4, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 19, SubcategoryName = "Home Electricity", CategoryId = 4, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 20, SubcategoryName = "Internet & Streaming", CategoryId = 4, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 21, SubcategoryName = "Water", CategoryId = 4, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 22, SubcategoryName = "Home Rental Equipment", CategoryId = 4, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 23, SubcategoryName = "Phone", CategoryId = 4, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                
                // Food and Dining Subcategories
                new Subcategory() { SubcategoryID = 24, SubcategoryName = "Groceries", CategoryId = 5, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 25, SubcategoryName = "Coffee Shops", CategoryId = 5, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 26, SubcategoryName = "Fast Food", CategoryId = 5, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 27, SubcategoryName = "Restaurants", CategoryId = 5, CategoryTypeId = 2, CreatedDate = DateTime.Now },

                // Shopping Subcategories
                new Subcategory() { SubcategoryID = 28, SubcategoryName = "Shopping", CategoryId = 6, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 29, SubcategoryName = "Clothing & Accessories", CategoryId = 6, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 30, SubcategoryName = "Furniture & Home Decor", CategoryId = 6, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 31, SubcategoryName = "Appliances & Electronics", CategoryId = 6, CategoryTypeId = 2, CreatedDate = DateTime.Now },

                // Gifts and Donations Subcategories
                new Subcategory() { SubcategoryID = 32, SubcategoryName = "Gifts", CategoryId = 7, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 33, SubcategoryName = "Charity", CategoryId = 7, CategoryTypeId = 2, CreatedDate = DateTime.Now },

                // Financial Subcategories
                new Subcategory() { SubcategoryID = 34, SubcategoryName = "Student Loans & Repayments", CategoryId = 8, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 35, SubcategoryName = "Financial Fees", CategoryId = 8, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 36, SubcategoryName = "Taxes", CategoryId = 8, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 37, SubcategoryName = "Cash & Withdrawals", CategoryId = 8, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 38, SubcategoryName = "Car Insurance", CategoryId = 8, CategoryTypeId = 3, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 39, SubcategoryName = "Home Insurance", CategoryId = 8, CategoryTypeId = 3, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 40, SubcategoryName = "Other Insurance", CategoryId = 8, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 41, SubcategoryName = "Savings", CategoryId = 8, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 42, SubcategoryName = "Investments", CategoryId = 8, CategoryTypeId = 2, CreatedDate = DateTime.Now },

                // Children Subcategories
                new Subcategory() { SubcategoryID = 43, SubcategoryName = "Childcare Expenses", CategoryId = 9, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 44, SubcategoryName = "Child Activities", CategoryId = 9, CategoryTypeId = 2, CreatedDate = DateTime.Now },

                // Health and Fitness Subcategories
                new Subcategory() { SubcategoryID = 45, SubcategoryName = "Medical", CategoryId = 10, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 46, SubcategoryName = "Dentist", CategoryId = 10, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 47, SubcategoryName = "Fitness", CategoryId = 10, CategoryTypeId = 2, CreatedDate = DateTime.Now },

                // Travel and Fun Subcategories
                new Subcategory() { SubcategoryID = 48, SubcategoryName = "Travel & Vacations", CategoryId = 11, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 49, SubcategoryName = "Entertainment & Leisure", CategoryId = 11, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 50, SubcategoryName = "Hobbies & Crafts", CategoryId = 11, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 51, SubcategoryName = "Pets", CategoryId = 11, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 52, SubcategoryName = "Fun Money", CategoryId = 11, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 53, SubcategoryName = "Personal Care", CategoryId = 11, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 54, SubcategoryName = "Subscriptions & Memberships", CategoryId = 11, CategoryTypeId = 2, CreatedDate = DateTime.Now },

                // Business Expenses Subcategories
                new Subcategory() { SubcategoryID = 55, SubcategoryName = "Advertising & Marketing", CategoryId = 12, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 56, SubcategoryName = "Office Supplies", CategoryId = 12, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 57, SubcategoryName = "Software & Tools", CategoryId = 12, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 58, SubcategoryName = "Business Utilities", CategoryId = 12, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 59, SubcategoryName = "Employee Salaries", CategoryId = 12, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 60, SubcategoryName = "Business Travel", CategoryId = 12, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 61, SubcategoryName = "Business Insurance", CategoryId = 12, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 62, SubcategoryName = "Business Rent", CategoryId = 12, CategoryTypeId = 2, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 63, SubcategoryName = "Other Business Expenses", CategoryId = 12, CategoryTypeId = 2, CreatedDate = DateTime.Now },

                // Other Subcategories
                new Subcategory() { SubcategoryID = 64, SubcategoryName = "Uncategorized", CategoryId = 13, CategoryTypeId = 4, CreatedDate = DateTime.Now },
                new Subcategory() { SubcategoryID = 65, SubcategoryName = "Miscellaneous Expenses", CategoryId = 13, CategoryTypeId = 4, CreatedDate = DateTime.Now }
                };
        }
    }
}
