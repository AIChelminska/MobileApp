using Microsoft.EntityFrameworkCore;
using SolutionOrdersAPI.Models;
using SolutionOrdersAPI.Models.Data;

namespace SolutionOrdersAPI.Features.Items.Providers;

public class ItemProvider : IItemProvider
{
    private readonly ApplicationDbContext _context;

    public ItemProvider(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Item>> GetItemsAsync(bool AsNoTracking = true, CancellationToken cancellationToken = default)
    {
        var query = _context.Items
            .Include(i => i.Category)
            .Include(i => i.UnitOfMeasurement)
            .Where(i => i.IsActive);
        
        if (AsNoTracking)
        {
            query = query.AsNoTracking();
        }
        
        return await query
            .OrderBy(item => item.Name)
            .ToListAsync(cancellationToken);
    }

    public async Task<Item?> GetItemByIdAsync(int id, bool AsNoTracking = true, CancellationToken cancellationToken = default)
    {
        var query = _context.Items
            .Include(i => i.Category)
            .Include(i => i.UnitOfMeasurement)
            .Where(i => i.IsActive);
        
        if (AsNoTracking)
        {
            query = query.AsNoTracking();
        }
        
        return await query
            .FirstOrDefaultAsync(i => i.IdItem == id, cancellationToken);
    }
}
