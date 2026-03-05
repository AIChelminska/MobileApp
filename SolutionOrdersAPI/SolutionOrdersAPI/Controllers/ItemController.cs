using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolutionOrdersAPI.Features.Items.Messages.DTOs;
using SolutionOrdersAPI.Features.Items.Messages.Queries;

namespace SolutionOrdersAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<ItemDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllItems()
    {
        var query = new GetItemsQuery();
        var items = await _mediator.Send(query);
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetItem(int id)
    {
        var query = new GetItemByIdQuery(id);
        var item = await _mediator.Send(query);
        if (item == null)
            return NotFound();
        return Ok(item);
    }
}