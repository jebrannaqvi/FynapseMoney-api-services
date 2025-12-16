using AutoMapper;
using Microsoft.Extensions.Logging;
using Moneymanager.Services.AccountAPI.Models;
using Moneymanager.Services.AccountAPI.Models.DTO;

namespace Moneymanager.Services.AccountAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole()); // Example: Using Console Logger

            var mappingConfig = new MapperConfiguration(cfg =>
            {
                // Add your mappings here
                cfg.CreateMap<Accounts, AccountDTO>().ReverseMap();
              
            }, loggerFactory);

            return mappingConfig;
        }
    }
}
