using System.ComponentModel.DataAnnotations;
using static Moneymanager.Services.NetworthAPI.Constants.Constants;

namespace Moneymanager.Services.NetworthAPI.Models
{
    public class FinancialAsset
    {
        [Key]
        public int FinancialAssetId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string AssetName { get; set; }
        [Required]
        public AssetType AssetType { get; set; }
        [Required]
        public double AssetValue { get; set; }
        public double? GrowthRate { get; set; }
    }
}
