using Mapster;
using SolutionOrdersAPI.Features.Items.Messages.DTOs;
using SolutionOrdersAPI.Models;

namespace SolutionOrdersAPI.Features.Items.Mappings;

// MAPSTER — biblioteka do mapowania obiektów (alternatywa dla AutoMapper).
//
// Mapster potrafi automatycznie mapować pola o TYCH SAMYCH NAZWACH (np. Name → Name).
// Ta klasa konfiguruje NIESTANDARDOWE reguły mapowania, czyli te, których Mapster
// nie może sam wywnioskować.
//
// IRegister — interfejs Mapstera. Klasy implementujące IRegister są automatycznie
// wykrywane przy starcie aplikacji dzięki:
//   TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly())
// w Program.cs — nie musisz ręcznie rejestrować każdej konfiguracji.
public class ItemMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // NewConfig<TSource, TDestination>() — definiuje reguły mapowania z Item na ItemDto
        config.NewConfig<Item, ItemDto>()
            // .Map(dest => POLE_DOCELOWE, src => SKĄD_POBRAĆ_WARTOŚĆ)
            // CategoryName nie ma w Item, ale Item ma nawigację Category,
            // więc pobieramy nazwę z powiązanego obiektu
            .Map(dest => dest.CategoryName, src => src.Category.Name)

            // UnitOfMeasurement jest opcjonalne (nullable), więc sprawdzamy czy istnieje
            .Map(dest => dest.UnitName, src => src.UnitOfMeasurement != null
                ? src.UnitOfMeasurement.Name
                : null);

        // Mapowanie w drugą stronę (ItemDto → Item) NIE jest tu zdefiniowane —
        // Mapster obsługuje je automatycznie na podstawie nazw pól.
        // Używamy go w handlerach przez: request.Adapt(existingItem)
    }
}
