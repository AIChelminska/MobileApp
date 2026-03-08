using MediatR;

namespace SolutionOrdersAPI.Features.Items.Messages.Commands;

// WZORZEC CQRS + MediatR
// "Command" to obiekt reprezentujący ŻĄDANIE zmiany stanu aplikacji (zapis do bazy).
// Kontrast: "Query" to żądanie odczytu danych (bez zmiany stanu).
//
// Jak to działa:
// 1. Kontroler tworzy instancję tej klasy i wypełnia ją danymi z HTTP body
// 2. Kontroler wywołuje: await _mediator.Send(command)
// 3. MediatR automatycznie ZNAJDZIE handler zarejestrowany dla tego typu (CreateItemHandler)
//    i wykona metodę Handle(command, cancellationToken)
//
// IRequest<int> oznacza: "ten command zwróci int" (w tym przypadku ID nowo utworzonego produktu)
// Gdyby command nic nie zwracał, użyłbyś IRequest<Unit> (Unit = void w MediatR)
public class CreateItemCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int IdCategory { get; set; }
    public decimal? Price { get; set; }
    public decimal? Quantity { get; set; }
    public string? FotoUrl { get; set; }
    public int? IdUnitOfMeasurement { get; set; }
    public string? Code { get; set; }

    // UWAGA: IsActive celowo NIE ma tu być — przy tworzeniu zawsze ustawiamy true w handlerze.
    // Klient nie powinien móc sam decydować czy nowy produkt jest aktywny.
}
