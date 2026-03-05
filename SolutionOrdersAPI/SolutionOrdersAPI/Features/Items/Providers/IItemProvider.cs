using SolutionOrdersAPI.Features.Items.Messages.DTOs;

namespace SolutionOrdersAPI.Features.Items.Providers;

public interface IItemProvider
{
    Task<IEnumerable<ItemDto>> GetItemsAsync(CancellationToken cancellationToken = default);
    Task<ItemDto?> GetItemByIdAsync(int id, CancellationToken cancellationToken = default);
}
