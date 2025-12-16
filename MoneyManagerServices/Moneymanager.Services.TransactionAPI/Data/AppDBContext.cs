using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Moneymanager.Services.TransactionAPI.Data
{
    public class AppDBContext : DbContext

    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Models.Category> Categories { get; set; }
        public DbSet<Models.CategoryType> CategoryTypes { get; set; }

        public DbSet<Models.Subcategory> Subcategories { get; set; }
       
        public DbSet<Models.TransaationType> TransacationTypes { get; set; }
        public DbSet<Models.AccountTransactions> AccountTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.CategoryType>().HasData(Models.CategoryType.GetPreconfiguredCategoryTypes());
            modelBuilder.Entity<Models.Category>().HasData(Models.Category.GetPreconfiguredCategories());
            modelBuilder.Entity<Models.Subcategory>().HasData(Models.Subcategory.GetPreconfiguredSubcategories());
            modelBuilder.Entity<Models.TransaationType>().HasData(Models.TransaationType.GetPreconfiguredTransactionTypes());
            //modelBuilder.Entity<Models.AccountTransaction>().HasData(new Models.AccountTransaction
            //{
            //    TransactionID = 1,
            //    BankAccountID = 1,
            //    TransactionDate = DateTime.Now,
            //    Description = "Salary Deposit",
            //    Amount = 1000.00,
            //    Subcategory = new Models.Subcategory { SubcategoryID = 1, 
            //                                            SubcategoryName = "Income", 
            //                                            CategoryId = 1, 
            //                                            Category = new Models.Category { CategoryID = 1, 
            //                                                                            CategoryName = "Income", 
            //                                                                            CreatedDate = DateTime.Now }, 
            //                                            CategoryTypeId = 1, 
            //                                            CategoryType = new Models.CategoryType { CategoryTypeID = 1, 
            //                                                                                    CategoryTypeName = "Income", 
            //                                                                                    CreatedDate = DateTime.Now }, 
            //                                            CreatedDate = DateTime.Now },
            //    TransactionType = new Models.TransacationType { TransactionTypeID = 1, TransactionTypeName = "Credit", CreatedDate = DateTime.Now },
            //});

            //modelBuilder.Entity<Models.AccountTransaction>().HasData(new Models.AccountTransaction
            //{
            //    TransactionID = 2,
            //    BankAccountID = 1,
            //    TransactionDate = DateTime.Now.AddDays(-1),
            //    Description = "No Frills",
            //    Amount = 100.00,
            //    Subcategory = new Models.Subcategory
            //    {
            //        SubcategoryID = 2,
            //        SubcategoryName = "Groceries",
            //        CategoryId = 2,
            //        Category = new Models.Category
            //        {
            //            CategoryID = 2,
            //            CategoryName = "Food and dining",
            //            CreatedDate = DateTime.Now
            //        },
            //        CategoryTypeId = 2,
            //        CategoryType = new Models.CategoryType
            //        {
            //            CategoryTypeID = 2,
            //            CategoryTypeName = "Variable",
            //            CreatedDate = DateTime.Now
            //        },
            //        CreatedDate = DateTime.Now
            //    },
            //    TransactionType = new Models.TransacationType { TransactionTypeID = 2, TransactionTypeName = "Debit", CreatedDate = DateTime.Now },
            //});
        }
    }
    
    
}
