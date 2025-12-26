using Moneymanager.Services.RecommendationAPI.Models;

namespace Moneymanager.Services.RecommendationAPI.Data.IRepositories
{
    public interface IRecommendationRepository
    {
        public IEnumerable<Recommendations> GetAllRecommendations();
        public Recommendations GetRecommendationById(int id);
        public Recommendations CreateRecommendation(Recommendations recommendation);
        public Recommendations UpdateRecommendation(Recommendations recommendation);
    }
}
