using MediatR;
using SolutionOrdersAPI.Features.Items.Messages.DTOs;
using SolutionOrdersAPI.Features.Items.Messages.Queries;
using SolutionOrdersAPI.Features.Items.Providers;

namespace SolutionOrdersAPI.Features.Items.Handlers.Queries;

public class GetItemByIdHandler : IRequestHandler<GetItemByIdQuery, ItemDto?>
{
    private readonly IItemProvider _itemProvider;

    public GetItemByIdHandler(IItemProvider itemProvider)
    {
        _itemProvider = itemProvider;
    }

    public async Task<ItemDto?> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
    {
        return await _itemProvider.GetItemByIdAsync(request.Id, cancellationToken);
    }
}
