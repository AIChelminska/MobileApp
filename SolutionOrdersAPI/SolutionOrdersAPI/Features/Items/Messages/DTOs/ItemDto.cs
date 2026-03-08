namespace SolutionOrdersAPI.Features.Items.Messages.DTOs;

// DTO (Data Transfer Object) — obiekt służący TYLKO do przesyłania danych do klienta (API response).
//
// Dlaczego nie zwracamy bezpośrednio modelu Item?
// 1. BEZPIECZEŃSTWO — model może mieć pola, których nie chcemy ujawniać (np. wewnętrzne flagi)
// 2. KSZTAŁT DANYCH — DTO może mieć inne pola niż model, np. tu mamy CategoryName (string)
//    zamiast IdCategory (int) — klientowi bardziej przydatna jest nazwa niż ID
// 3. ODSPRZĘŻENIE — zmiana modelu bazy nie musi od razu zmieniać API
//
// Mapster automatycznie konwertuje Item → ItemDto na podstawie:
// - nazw pól (IdItem → IdItem, Name → Name itd.)
// - konfiguracji w ItemMappingConfig (CategoryName, UnitName — pola z nawigacji)
public class ItemDto
{
    public int IdItem { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    // To pole NIE istnieje w modelu Item — Mapster pobiera je z relacji Item.Category.Name
    // Konfiguracja tej reguły jest w ItemMappingConfig
    public string? CategoryName { get; set; }

    public decimal? Price { get; set; }
    public decimal? Quantity { get; set; }

    // Podobnie jak CategoryName — pochodzi z Item.UnitOfMeasurement.Name
    public string? UnitName { get; set; }

    public string? Code { get; set; }
    public bool IsActive { get; set; }
}
