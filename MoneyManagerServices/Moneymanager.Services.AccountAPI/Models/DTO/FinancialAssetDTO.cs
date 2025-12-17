using static Moneymanager.Services.AccountAPI.Constants.Constants;
using System.ComponentModel.DataAnnotations;

namespace Moneymanager.Services.AccountAPI.Models.DTO
{
    public class FinancialAssetDTO
    {
        public int FinancialAssetId { get; set; }
        public string UserId { get; set; }
        public int? AccountID { get; set; }
        public string AssetName { get; set; }
        public AssetType AssetType { get; set; }
        public double AssetValue { get; set; }
        public double? GrowthRate { get; set; }
    }
}
