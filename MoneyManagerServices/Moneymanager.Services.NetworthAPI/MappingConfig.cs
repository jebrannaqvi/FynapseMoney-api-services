using AutoMapper;
using Microsoft.Extensions.Logging;
using Moneymanager.Services.NetworthAPI.Models;
using Moneymanager.Services.NetworthAPI.Models.DTO;

namespace Moneymanager.Services.NetworthAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole()); // Example: Using Console Logger

            var mappingConfig = new MapperConfiguration(cfg =>
            {
                // Add your mappings here
                cfg.CreateMap<FinancialAsset, FinancialAssetDTO>().ReverseMap();
                cfg.CreateMap<FinancialLiability, FinancialLiabilityDTO>().ReverseMap();
            }, loggerFactory);

            return mappingConfig;
        }
    }
}
