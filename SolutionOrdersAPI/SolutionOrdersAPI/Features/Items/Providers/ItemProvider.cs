using Mapster;
using Microsoft.EntityFrameworkCore;
using SolutionOrdersAPI.Features.Items.Messages.DTOs;
using SolutionOrdersAPI.Models.Data;

namespace SolutionOrdersAPI.Features.Items.Providers;

public class ItemProvider : IItemProvider
{
    private readonly ApplicationDbContext _context;

    public ItemProvider(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ItemDto>> GetItemsAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Items
            .AsNoTracking()
            .Where(i => i.IsActive)
            .ProjectToType<ItemDto>()
            .ToListAsync(cancellationToken);
    }

    public async Task<ItemDto?> GetItemByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Items
            .AsNoTracking()
            .Where(i => i.IdItem == id && i.IsActive)
            .ProjectToType<ItemDto>()
            .FirstOrDefaultAsync(cancellationToken);
    }
}
