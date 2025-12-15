using System.ComponentModel.DataAnnotations;

namespace Moneymanager.Services.RecommendationAPI.Models
{
    public class Recommendation
    {
        [Key]
        public int RecommendationId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string RecommendationValue { get; set; }

    }
}
