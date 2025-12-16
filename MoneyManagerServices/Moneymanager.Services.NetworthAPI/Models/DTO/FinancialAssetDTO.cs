using static Moneymanager.Services.NetworthAPI.Constants.Constants;
using System.ComponentModel.DataAnnotations;

namespace Moneymanager.Services.NetworthAPI.Models.DTO
{
    public class FinancialAssetDTO
    {
        public int FinancialAssetId { get; set; }
        public int UserId { get; set; }
        public string AssetName { get; set; }
        public AssetType AssetType { get; set; }
        public double AssetValue { get; set; }
        public double? GrowthRate { get; set; }
    }
}
