using Moneymanager.Services.AccountAPI.Models.DTO;
using Moneymanager.Services.AccountAPI.Services.IServices;
using Newtonsoft.Json;

namespace Moneymanager.Services.AccountAPI.Services
{
    public class NetworthService : INetworthService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public NetworthService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseDTO> AddAccountAsAsset(FinancialAssetDTO financialAssetDTO)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("Networth");
                HttpRequestMessage message = new();
                message.Method = HttpMethod.Post;
                message.RequestUri = new Uri(client.BaseAddress + "api/networth/financialasset");
                message.Content = new StringContent(JsonConvert.SerializeObject(financialAssetDTO),
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

        public async Task<ResponseDTO> AddAccountAsLiability(FinancialLiabilityDTO financialLiabilityDTO)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("Networth");
                HttpRequestMessage message = new();
                message.Method = HttpMethod.Post;
                message.RequestUri = new Uri(client.BaseAddress + "api/networth/financialliability");
                message.Content = new StringContent(JsonConvert.SerializeObject(financialLiabilityDTO),
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

        public async Task<ResponseDTO> UpdateAssetValue(int accountId, double newBalance)
        {
            try
            {
                FinancialAssetValueDTO financialAssetValueDTO = new()
                {
                    AccountID = accountId,
                    AssetValue = newBalance
                };

                var client = _httpClientFactory.CreateClient("Networth");
                HttpRequestMessage message = new();
                message.Method = HttpMethod.Patch;
                message.RequestUri = new Uri(client.BaseAddress + "api/networth/financialasset/updatebalance");
                message.Content = new StringContent(JsonConvert.SerializeObject(financialAssetValueDTO),
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

        public async Task<ResponseDTO> UpdateLiabilityAmount(int accountId, double newBalance)
        {
            try
            {
                FinancialLiabilityValueDTO financialLiabilityValueDTO = new()
                {
                    AccountID = accountId,
                    AmountOwed = newBalance
                };

                var client = _httpClientFactory.CreateClient("Networth");
                HttpRequestMessage message = new();
                message.Method = HttpMethod.Patch;
                message.RequestUri = new Uri(client.BaseAddress + "api/networth/financialliability/updatebalance");
                message.Content = new StringContent(JsonConvert.SerializeObject(financialLiabilityValueDTO),
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
