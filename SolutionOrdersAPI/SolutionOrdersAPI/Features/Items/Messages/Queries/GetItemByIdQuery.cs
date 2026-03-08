using MediatR;
using SolutionOrdersAPI.Features.Items.Messages.DTOs;

namespace SolutionOrdersAPI.Features.Items.Messages.Queries;

// Primary constructor — skrócony zapis konstruktora w C# 12.
// Zamiast pisać pełny konstruktor, parametr `id` podajemy bezpośrednio przy klasie.
// Odpowiednik:
//   public GetItemByIdQuery(int id) { Id = id; }
//
// IRequest<ItemDto?> — zwróci ItemDto lub null (? = nullable), gdy produkt nie istnieje.
public class GetItemByIdQuery(int id) : IRequest<ItemDto?>
{
    public int Id { get; } = id;
}
