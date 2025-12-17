using static Moneymanager.Services.NetworthAPI.Constants.Constants;
using System.ComponentModel.DataAnnotations;

namespace Moneymanager.Services.NetworthAPI.Models.DTO
{
    public class FinancialLiabilityValueDTO
    {

        public int AccountID { get; set; }
        public double AmountOwed { get; set; }
    }
}
