using System.Text.Json.Serialization;

namespace Moneymanager.Services.TransactionAPI.Models.DTO
{
    public class AccountBalanceDTO
    {
        public int AccountID { get; set; }
      
        public double TransactionAmount { get; set; }
    }
}
