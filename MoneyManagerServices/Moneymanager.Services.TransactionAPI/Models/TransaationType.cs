using System.ComponentModel.DataAnnotations;

namespace Moneymanager.Services.TransactionAPI.Models
{
    public class TransaationType
    {
        [Key]
        public int TransactionTypeID { get; set; }
        [Required]
        public string TransactionTypeName { get; set; }
        public DateTime CreatedDate { get; set; }

        internal static TransaationType[] GetPreconfiguredTransactionTypes()
        {
            return new TransaationType[] {
                new TransaationType() { TransactionTypeID = 1, TransactionTypeName = "Credit", CreatedDate = DateTime.Today },
                new TransaationType() { TransactionTypeID = 2, TransactionTypeName = "Debit", CreatedDate = DateTime.Today }
                };
        }
    }
}
