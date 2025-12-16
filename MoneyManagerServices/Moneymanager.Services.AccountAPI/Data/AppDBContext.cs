using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Moneymanager.Services.AccountAPI.Models;


namespace Moneymanager.Services.AccountAPI.Data
{
    public class AppDBContext : DbContext

    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Accounts> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
    
    
}
