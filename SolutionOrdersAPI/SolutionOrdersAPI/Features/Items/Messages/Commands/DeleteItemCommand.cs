using MediatR;
namespace SolutionOrdersAPI.Features.Items.Messages.Commands;

public class DeleteItemCommand(int idItem) : IRequest<Unit>
{
    public int IdItem { get; set; } = idItem;
}