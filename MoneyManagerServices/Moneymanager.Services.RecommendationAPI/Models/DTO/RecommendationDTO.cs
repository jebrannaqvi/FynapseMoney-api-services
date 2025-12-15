using System.ComponentModel.DataAnnotations;

namespace Moneymanager.Services.RecommendationAPI.Models.DTO
{
    public class RecommendationDTO
    {
        public int RecommendationId { get; set; }
        public int UserId { get; set; }
        public string RecommendationValue { get; set; }
    }
}
