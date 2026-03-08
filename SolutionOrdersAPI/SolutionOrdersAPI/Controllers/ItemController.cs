using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolutionOrdersAPI.Features.Items.Messages.Commands;
using SolutionOrdersAPI.Features.Items.Messages.DTOs;
using SolutionOrdersAPI.Features.Items.Messages.Queries;

namespace SolutionOrdersAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ItemDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllItems()
    {
        var query = new GetItemsQuery();
        var items = await mediator.Send(query);
        return Ok(items);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ItemDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetItem(int id)
    {
        var query = new GetItemByIdQuery(id);
        var item = await mediator.Send(query);
        if (item == null)
            return NotFound();
        return Ok(item);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateItemCommand command)
    {
        var itemId = await mediator.Send(command);
        
        return CreatedAtAction(nameof(GetItem), new { id = itemId },
            new { id = itemId, message = "Produkt został utworzony" }
        );
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateItemCommand command)
    {
        if (id != command.IdItem)
            return BadRequest(new { message = "ID w URL różni się od ID w body" });

        try
        {
            await mediator.Send(command);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteItemCommand(id);

        try
        {
            await mediator.Send(command);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}
