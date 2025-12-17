using static Moneymanager.Services.AccountAPI.Constants.Constants;
using System.ComponentModel.DataAnnotations;

namespace Moneymanager.Services.AccountAPI.Models.DTO
{
    public class FinancialLiabilityValueDTO
    {

        public int AccountID { get; set; }
        public double AmountOwed { get; set; }
    }
}
