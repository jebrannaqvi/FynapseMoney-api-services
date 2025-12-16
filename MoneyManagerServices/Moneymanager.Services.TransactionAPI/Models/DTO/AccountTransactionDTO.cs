namespace Moneymanager.Services.TransactionAPI.Models.DTO
{
    public class AccountTransactionDTO
    {
        public int TransactionID { get; set; }

        public int UserID { get; set; }
        public int BankAccountID { get; set; }
        public DateTime TransactionDate { get; set; }
        public String? Description { get; set; }
        public double Amount { get; set; }
        public int SubcategoryID { get; set; }
        public SubcategoryDTO? Subcategory { get; set; } //e.g., 'Groceries', 'Rent', etc.
        public int TransactionTypeID { get; set; }
        public TransactionTypeDTO? TransactionType { get; set; } // e.g. credit, debit
    }
}
