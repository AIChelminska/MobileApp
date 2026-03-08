using Mapster;
using MediatR;
using SolutionOrdersAPI.Features.Items.Messages.Commands;
using SolutionOrdersAPI.Features.Items.Providers;
using SolutionOrdersAPI.Features.Items.Services;

namespace SolutionOrdersAPI.Features.Items.Handlers.Commands;

public class UpdateItemHandler(IItemProvider itemProvider, IItemService itemService, ILogger<UpdateItemHandler> logger)
    : IRequestHandler<UpdateItemCommand, Unit>
{
    public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var item = await itemProvider.GetItemByIdAsync(request.IdItem, false, cancellationToken);

        if (item == null)
            throw new KeyNotFoundException($"Produkt o ID {request.IdItem} nie istnieje.");

        logger.LogInformation("Aktualizacja produktu ID: {IdItem}", request.IdItem);
        request.Adapt(item);
        await itemService.UpdateItem(item, cancellationToken);
        logger.LogInformation("Zaktualizowano produkt ID: {IdItem}", request.IdItem);
        return Unit.Value;
    }
}
