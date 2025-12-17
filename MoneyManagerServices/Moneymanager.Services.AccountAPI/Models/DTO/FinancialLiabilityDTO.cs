using static Moneymanager.Services.AccountAPI.Constants.Constants;
using System.ComponentModel.DataAnnotations;

namespace Moneymanager.Services.AccountAPI.Models.DTO
{
    public class FinancialLiabilityDTO
    {
        
        public int FinancialId { get; set; }
        public string UserId { get; set; }
        public int? AccountID { get; set; }
        public string LiabilityName { get; set; }
        public LiabilityType LiabilityType { get; set; }
        public double AmountOwed { get; set; }
        public double? InterestRate { get; set; }
    }
}
