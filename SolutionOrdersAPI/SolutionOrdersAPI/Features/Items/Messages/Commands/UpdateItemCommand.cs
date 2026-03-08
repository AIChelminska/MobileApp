using MediatR;

namespace SolutionOrdersAPI.Features.Items.Messages.Commands;

// Update command różni się od Create tym, że:
// - zawiera IdItem (musimy wiedzieć KTÓRY produkt edytujemy)
// - zawiera IsActive (przy update klient może aktywować/deaktywować produkt)
//
// IRequest<Unit> — ten command nic nie zwraca (Unit to odpowiednik void w MediatR).
// Po udanym update kontroler zwróci HTTP 204 No Content (sukces bez body).
public class UpdateItemCommand : IRequest<Unit>
{
    public int IdItem { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int IdCategory { get; set; }
    public decimal? Price { get; set; }
    public decimal? Quantity { get; set; }
    public string? FotoUrl { get; set; }
    public int? IdUnitOfMeasurement { get; set; }
    public string? Code { get; set; }
    public bool IsActive { get; set; }
}
