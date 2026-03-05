using MediatR;
using SolutionOrdersAPI.Features.Items.Messages.DTOs;

namespace SolutionOrdersAPI.Features.Items.Messages.Queries;

public class GetItemsQuery : IRequest<IEnumerable<ItemDto>>
{
    
}