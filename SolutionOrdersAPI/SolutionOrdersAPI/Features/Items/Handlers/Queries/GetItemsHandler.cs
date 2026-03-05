using MediatR;
using SolutionOrdersAPI.Features.Items.Messages.DTOs;
using SolutionOrdersAPI.Features.Items.Messages.Queries;
using SolutionOrdersAPI.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace SolutionOrdersAPI.Features.Items.Handlers.Queries;

public class GetItemsHandler : IRequestHandler<GetItemsQuery, IEnumerable<ItemDto>>
{
    private readonly ApplicationDbContext _context;

    public GetItemsHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ItemDto>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
    {
        var items = await _context.Items
            .AsNoTracking()
            .Include(i => i.Category)
            .Include(i => i.UnitOfMeasurement)
            .Where(i => i.IsActive)
            .Select(i => new ItemDto
            {
                IdItem = i.IdItem,
                Name = i.Name,
                Description = i.Description,
                CategoryName = i.Category.Name,
                Price = i.Price,
                Quantity = i.Quantity,
                UnitName = i.UnitOfMeasurement != null 
                    ? i.UnitOfMeasurement.Name 
                    : null,
                Code = i.Code,
                IsActive = i.IsActive
            })
            .ToListAsync(cancellationToken);

        return items;
    }     
}