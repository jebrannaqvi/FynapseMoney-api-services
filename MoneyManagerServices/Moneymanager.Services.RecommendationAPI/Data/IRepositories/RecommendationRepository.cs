using Moneymanager.Services.RecommendationAPI.Models;

namespace Moneymanager.Services.RecommendationAPI.Data.IRepositories
{
    public class RecommendationRepository : IRecommendationRepository
    {
        private readonly AppDBContext _dbContext;

        public RecommendationRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Recommendations CreateRecommendation(Recommendations recommendation)
        {
            _dbContext.Recommendations.Add(recommendation);
            _dbContext.SaveChanges();
            return recommendation;
        }

        public IEnumerable<Recommendations> GetAllRecommendations()
        {
            return _dbContext.Recommendations.ToList();
        }

        public Recommendations GetRecommendationById(int id)
        {
            return _dbContext.Recommendations.FirstOrDefault(r => r.RecommendationId == id);
        }

        public Recommendations UpdateRecommendation(Recommendations recommendation)
        {
            _dbContext.Recommendations.Update(recommendation);
            _dbContext.SaveChanges();
            return recommendation;
        }
    }
}
