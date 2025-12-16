namespace Moneymanager.Services.NetworthAPI.Models.DTO
{
    public class NetworthDTO
    {
        public List<FinancialAssetDTO> FinancialAssets { get; set; }
        public List<FinancialLiabilityDTO> FinancialLiabilities { get; set; }
        public double TotalAssets { get; set; }
        public double TotalLiabilities { get; set; }
        public double NetWorth { get; set; }

    }
}
