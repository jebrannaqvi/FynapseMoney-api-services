using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static Moneymanager.Services.NetworthAPI.Constants.Constants;

namespace Moneymanager.Services.NetworthAPI.Models
{
    public class FinancialAsset
    {
        [Key]
        public int FinancialAssetId { get; set; }
        [Required]
        public string UserId { get; set; }
        public int? AccountID { get; set; }
        [Required]
        public string AssetName { get; set; }
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AssetType AssetType { get; set; }
        [Required]
        public double AssetValue { get; set; }
        
        
        public double? GrowthRate { get; set; }
    }
}
