using System.ComponentModel.DataAnnotations;

namespace Moneymanager.Services.TransactionAPI.Models.DTO
{
    public class CategoryTypeDTO
    {
        public int CategoryTypeID { get; set; }
        public string CategoryTypeName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
