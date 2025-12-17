using Moneymanager.Services.TransactionAPI.Models.DTO;

namespace Moneymanager.Services.TransactionAPI.Services.IServices
{
    public interface IAccountService
    {
        Task<ResponseDTO> UpdateAccountBalance(AccountBalanceDTO transactionUpdate);
    }
}
