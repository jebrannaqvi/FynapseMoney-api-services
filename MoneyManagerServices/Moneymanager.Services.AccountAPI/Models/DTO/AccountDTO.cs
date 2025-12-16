using System.Text.Json.Serialization;
using static Moneymanager.Services.AccountAPI.Constants.Constants;

namespace Moneymanager.Services.AccountAPI.Models.DTO
{
    public class AccountDTO
    {
        public int AccountID { get; set; }
        public string UserID { get; set; }
        public string BankName { get; set; }
        public string? Nickname { get; set; }
        public double StartingBalance { get; set; }
        public double CurrentBalance { get; set; }
        public string? AccountNumber { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AccountTypes? AccountType { get; set; }
        public int? AverageMonthlyTransactions { get; set; }
    }
}
