using System.ComponentModel.DataAnnotations;

namespace Moneymanager.Services.TransactionAPI.Models.DTO
{
    public class TransactionTypeDTO
    {
        public int TransactionTypeID { get; set; }
        public string TransactionTypeName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
