using Mapster;
using MediatR;
using SolutionOrdersAPI.Features.Items.Messages.DTOs;
using SolutionOrdersAPI.Features.Items.Messages.Queries;
using SolutionOrdersAPI.Features.Items.Providers;

namespace SolutionOrdersAPI.Features.Items.Handlers.Queries;

public class GetItemsHandler(IItemProvider itemProvider) : IRequestHandler<GetItemsQuery, IEnumerable<ItemDto>>
{
    public async Task<IEnumerable<ItemDto>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
    {
        var items = await itemProvider.GetItemsAsync(true, cancellationToken);
        return items.Adapt<IEnumerable<ItemDto>>();
    }
}
