using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Moneymanager.Services.BudgetAPI.Data
{
    public class AppDBContext : DbContext

    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Models.Budget> Budget { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
    
    
}
