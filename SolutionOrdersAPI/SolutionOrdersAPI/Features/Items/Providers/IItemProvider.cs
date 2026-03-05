using SolutionOrdersAPI.Models;

namespace SolutionOrdersAPI.Features.Items.Providers;

public interface IItemProvider
{
    Task<IEnumerable<Item>> GetItemsAsync(bool AsNoTracking = true, CancellationToken cancellationToken = default);
    Task<Item?> GetItemByIdAsync(int id, bool AsNoTracking = true, CancellationToken cancellationToken = default);
}
