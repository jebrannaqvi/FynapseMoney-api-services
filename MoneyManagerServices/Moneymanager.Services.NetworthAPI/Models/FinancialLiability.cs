using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static Moneymanager.Services.NetworthAPI.Constants.Constants;

namespace Moneymanager.Services.NetworthAPI.Models
{
    public class FinancialLiability
    {
        [Key]
        public int FinancialId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string LiabilityName { get; set; }
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LiabilityType LiabilityType { get; set; }
        [Required]
        public double AmountOwed { get; set; }
        public double? InterestRate { get; set; }
    }
}
