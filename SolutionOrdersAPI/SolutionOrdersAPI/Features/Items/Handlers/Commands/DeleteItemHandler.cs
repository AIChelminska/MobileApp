using Mapster;
using MediatR;
using SolutionOrdersAPI.Features.Items.Messages.Commands;
using SolutionOrdersAPI.Features.Items.Providers;
using SolutionOrdersAPI.Features.Items.Services;

namespace SolutionOrdersAPI.Features.Items.Handlers.Commands;

public class DeleteItemHandler(IItemProvider itemProvider, IItemService itemService, ILogger<DeleteItemHandler> logger)
    : IRequestHandler<DeleteItemCommand, Unit>
{
    public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        var item = await itemProvider.GetItemByIdAsync(request.IdItem, false, cancellationToken);
        logger.LogInformation("Usuwanie produktu ID: {IdItem}", request.IdItem);
        item.IsActive = false;
        await itemService.DeleteItem(item, cancellationToken);
        logger.LogInformation("Usunięto produkt ID: {IdItem}", request.IdItem);
        return Unit.Value;
    }
}