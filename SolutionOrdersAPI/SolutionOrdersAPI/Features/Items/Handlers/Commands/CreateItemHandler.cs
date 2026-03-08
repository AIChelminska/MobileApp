using Mapster;
using MediatR;
using SolutionOrdersAPI.Models;
using SolutionOrdersAPI.Features.Items.Messages.Commands;
using SolutionOrdersAPI.Features.Items.Services;

namespace SolutionOrdersAPI.Features.Items.Handlers.Commands;

public class CreateItemHandler(IItemService itemService, ILogger<CreateItemHandler> logger)
    : IRequestHandler<CreateItemCommand, int>
{
    public async Task<int> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Tworzenie nowego produktu: {Name}", request.Name);
        var item = request.Adapt<Item>();
        item.IsActive = true;
        await itemService.CreateItem(item, cancellationToken);
        logger.LogInformation("Utworzono produkt ID: {IdItem}", item.IdItem);
        return item.IdItem;
    }
}
