namespace Moneymanager.Services.NetworthAPI.Models.DTO
{
    public class ResponseDTO
    {
        public bool IsSuccess { get; set; } = true;
        public object? Result { get; set; }
        public string? DisplayMessage { get; set; } = null;
        public List<string>? ErrorMessages { get; set; }
    }
}
