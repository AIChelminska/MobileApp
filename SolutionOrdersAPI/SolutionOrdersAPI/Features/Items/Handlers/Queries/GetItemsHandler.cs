using MediatR;
using SolutionOrdersAPI.Features.Items.Messages.DTOs;
using SolutionOrdersAPI.Features.Items.Messages.Queries;
using SolutionOrdersAPI.Features.Items.Providers;

namespace SolutionOrdersAPI.Features.Items.Handlers.Queries;

public class GetItemsHandler : IRequestHandler<GetItemsQuery, IEnumerable<ItemDto>>
{
    private readonly IItemProvider _itemProvider;

    public GetItemsHandler(IItemProvider itemProvider)
    {
        _itemProvider = itemProvider;
    }

    public async Task<IEnumerable<ItemDto>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
    {
        return await _itemProvider.GetItemsAsync(cancellationToken);
    }
}
