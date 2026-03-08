using MediatR;
using SolutionOrdersAPI.Features.Items.Messages.DTOs;

namespace SolutionOrdersAPI.Features.Items.Messages.Queries;

// "Query" to obiekt reprezentujący żądanie ODCZYTU danych (bez zmiany stanu).
// Ta klasa jest pusta, bo nie potrzebujemy żadnych parametrów — chcemy po prostu wszystkie produkty.
//
// IRequest<IEnumerable<ItemDto>> oznacza że ten query zwróci listę ItemDto.
// Zwracamy ItemDto (a nie Item), żeby nie ujawniać klientowi wszystkich pól modelu bazy danych.
public class GetItemsQuery : IRequest<IEnumerable<ItemDto>>
{
}
