using SolutionOrdersAPI.Models;
using SolutionOrdersAPI.Models.Data;

namespace SolutionOrdersAPI.Features.Items.Services;

public class ItemService(ApplicationDbContext context) : IItemService
{
    public async Task CreateItem(Item item, CancellationToken cancellationToken)
    {
        item.IsActive = true;
        context.Items.Add(item);
        await context.SaveChangesAsync(cancellationToken);
    }
}
