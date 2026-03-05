using MediatR;
using SolutionOrdersAPI.Features.Items.Messages.DTOs;

namespace SolutionOrdersAPI.Features.Items.Messages.Queries;

public class GetItemByIdQuery(int id) : IRequest<ItemDto?>
{
    public int Id { get; } = id;
}
