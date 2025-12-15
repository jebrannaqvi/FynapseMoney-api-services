using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Moneymanager.Services.RecommendationAPI.Models;

namespace Moneymanager.Services.RecommendationAPI.Data
{
    public class AppDBContext : DbContext

    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Recommendation> Recommendation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
    
    
}
