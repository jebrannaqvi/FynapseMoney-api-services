using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Moneymanager.Services.NetworthAPI.Models;

namespace Moneymanager.Services.NetworthAPI.Data
{
    public class AppDBContext : DbContext

    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<FinancialAsset> Assets { get; set; }
        public DbSet<FinancialLiabilities> Liabilities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
    
    
}
