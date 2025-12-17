using Moneymanager.Services.TransactionAPI.Models.DTO;
using Moneymanager.Services.TransactionAPI.Services.IServices;
using Newtonsoft.Json;


namespace Moneymanager.Services.TransactionAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AccountService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseDTO> UpdateAccountBalance(AccountBalanceDTO transactionUpdate)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("Account");
                HttpRequestMessage message = new();
                message.Method = HttpMethod.Put;
                message.RequestUri = new Uri(client.BaseAddress + "api/account/updatebalance");
                message.Content = new StringContent(JsonConvert.SerializeObject(transactionUpdate),
                    System.Text.Encoding.UTF8, "application/json");


                var response = await client.SendAsync(message);

                if (!response.IsSuccessStatusCode)
                {
                    return new ResponseDTO
                    {
                        IsSuccess = false,
                        DisplayMessage = "Error occurred while updating account balance."
                    };
                }
                else
                {
                    var apiContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ResponseDTO>(apiContent);
                }
            }
            catch (Exception ex)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    DisplayMessage = ex.Message
                };
            }
        }
    }
}
