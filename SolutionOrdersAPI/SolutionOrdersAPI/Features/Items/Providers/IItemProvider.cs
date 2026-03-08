using SolutionOrdersAPI.Models;

namespace SolutionOrdersAPI.Features.Items.Providers;

// PROVIDER — warstwa dostępu do danych (odpowiednik Repository Pattern).
// Odpowiada WYŁĄCZNIE za odczyt danych z bazy (SELECT).
// Zapisy (INSERT, UPDATE) obsługuje serwis (IItemService).
//
// Dlaczego interfejs?
// - Możemy podmienić implementację bez zmiany kodu handlerów (np. na wersję testową/mock)
// - Rejestrujemy w DI: builder.Services.AddScoped<IItemProvider, ItemProvider>()
public interface IItemProvider
{
    // bool AsNoTracking — gdy true, EF Core NIE śledzi zmian na pobranych obiektach.
    // Używaj AsNoTracking=true dla odczytów (GET) — szybsze, mniej pamięci.
    // Używaj AsNoTracking=false gdy chcesz POTEM edytować pobrany obiekt (jak w UpdateItemHandler).
    Task<IEnumerable<Item>> GetItemsAsync(bool AsNoTracking = true, CancellationToken cancellationToken = default);
    Task<Item?> GetItemByIdAsync(int id, bool AsNoTracking = true, CancellationToken cancellationToken = default);
}
