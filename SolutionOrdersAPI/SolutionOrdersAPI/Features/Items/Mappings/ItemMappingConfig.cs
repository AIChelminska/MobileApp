using Mapster;
using SolutionOrdersAPI.Features.Items.Messages.DTOs;
using SolutionOrdersAPI.Models;

namespace SolutionOrdersAPI.Features.Items.Mappings;

public class ItemMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Item, ItemDto>()
            .Map(dest => dest.CategoryName, src => src.Category.Name)
            .Map(dest => dest.UnitName, src => src.UnitOfMeasurement != null
                ? src.UnitOfMeasurement.Name
                : null);
    }
}
