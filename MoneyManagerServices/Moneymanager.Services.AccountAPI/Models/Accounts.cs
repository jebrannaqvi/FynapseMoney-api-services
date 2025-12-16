using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static Moneymanager.Services.AccountAPI.Constants.Constants;

namespace Moneymanager.Services.AccountAPI.Models
{
    public class Accounts
    {
        [Key]
        public int AccountID { get; set; }
        [Required]
        public string UserID { get; set; }
        [Required]
        public string BankName { get; set; }
        public string? Nickname { get; set; }
        [Required]
        public double StartingBalance { get; set; }
        [Required]
        public double CurrentBalance { get; set; }
        public string? AccountNumber { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AccountTypes? AccountType { get; set; }
        public int? AverageMonthlyTransactions { get; set; }

    }
}
