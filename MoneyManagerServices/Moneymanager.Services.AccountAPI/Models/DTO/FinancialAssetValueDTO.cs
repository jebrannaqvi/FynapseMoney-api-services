using static Moneymanager.Services.AccountAPI.Constants.Constants;
using System.ComponentModel.DataAnnotations;

namespace Moneymanager.Services.AccountAPI.Models.DTO
{
    public class FinancialAssetValueDTO
    {
        public int? AccountID { get; set; }
        public double AssetValue { get; set; }
    }
}
