using Moneymanager.Services.BudgetAPI.Models.DTO;
using Moneymanager.Services.BudgetAPI.Services.IServices;
using System.Text.Json;

namespace Moneymanager.Services.BudgetAPI.Services
{
    public class AccountTransactionService : IAccountTransactionService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AccountTransactionService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<SubcategoryDTO> GetSubcategoryById(int id)
        {
            var client = _httpClientFactory.CreateClient("Category");
            var response = await client.GetAsync($"/api/category/GetSubcategory/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var resp = JsonSerializer.Deserialize<ResponseDTO>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                if (resp.IsSuccess)
                {
                    var subcategory = JsonSerializer.Deserialize<SubcategoryDTO>(Convert.ToString(resp.Result), new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return subcategory;
                }
            }
            return new SubcategoryDTO();


        }
    }
}
