using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolutionOrdersAPI.Features.Items.Messages.Queries;

namespace SolutionOrdersAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetItems()
    {
        var items = await _mediator.Send(new GetItemsQuery());
        return Ok(items);
    }
}