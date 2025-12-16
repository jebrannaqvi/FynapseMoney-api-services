using System.ComponentModel.DataAnnotations;

namespace Moneymanager.Services.RecommendationAPI.Models
{
    public class Recommendations
    {
        [Key]
        public int RecommendationId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string RecommendationValue { get; set; }

    }
}
