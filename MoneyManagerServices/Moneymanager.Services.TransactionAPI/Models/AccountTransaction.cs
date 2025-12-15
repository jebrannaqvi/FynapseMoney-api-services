using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moneymanager.Services.TransactionAPI.Models
{
    public class AccountTransaction
    {
        [Key]
        public int TransactionID { get; set; }
        [Required]
        public int BankAccountID { get; set; }
        [Required] 
        public DateTime TransactionDate { get; set; }
        public String? Description { get; set; }
        [Required]
        public double Amount { get; set; }
        public int SubcategoryID { get; set; }
        [ForeignKey("SubcategoryID")]
        public Subcategory Subcategory { get; set; } //e.g., 'Groceries', 'Rent', etc.
        public int TransactionTypeID { get; set; }
        [ForeignKey("TransactionTypeID")]
        public TransaationType TransactionType { get; set; } // e.g. credit, debit
    }
}
