using AutoMapper;
using Microsoft.Extensions.Logging;
using Moneymanager.Services.BudgetAPI.Models;
using Moneymanager.Services.BudgetAPI.Models.DTO;

namespace Moneymanager.Services.BudgetAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole()); // Example: Using Console Logger

            var mappingConfig = new MapperConfiguration(cfg =>
            {
                // Add your mappings here
                cfg.CreateMap<BudgetDTO, Budgets>().ReverseMap();
                //cfg.CreateMap<AccountTransactionDTO, AccountTransaction>().ReverseMap();
                //cfg.CreateMap<Subcategory, SubcategoryDTO>().ReverseMap();
                //cfg.CreateMap<CategoryDTO, Category>().ReverseMap();
                //cfg.CreateMap<TransactionTypeDTO, TransaationType>().ReverseMap();
                //cfg.CreateMap<CategoryTypeDTO, CategoryType>().ReverseMap();
            }, loggerFactory);

            return mappingConfig;
        }
    }
}
