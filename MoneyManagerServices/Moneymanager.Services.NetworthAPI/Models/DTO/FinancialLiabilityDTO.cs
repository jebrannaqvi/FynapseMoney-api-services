using static Moneymanager.Services.NetworthAPI.Constants.Constants;
using System.ComponentModel.DataAnnotations;

namespace Moneymanager.Services.NetworthAPI.Models.DTO
{
    public class FinancialLiabilityDTO
    {
        
        public int FinancialId { get; set; }
        public int UserId { get; set; }
        public string LiabilityName { get; set; }
        public LiabilityType LiabilityType { get; set; }
        public double AmountOwed { get; set; }
        public double? InterestRate { get; set; }
    }
}
