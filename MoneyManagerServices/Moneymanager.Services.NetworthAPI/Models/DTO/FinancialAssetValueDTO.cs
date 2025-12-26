using static Moneymanager.Services.NetworthAPI.Constants.Constants;
using System.ComponentModel.DataAnnotations;

namespace Moneymanager.Services.NetworthAPI.Models.DTO
{
    public class FinancialAssetValueDTO
    {
        public int AccountID { get; set; }
        public double AssetValue { get; set; }
    }
}
