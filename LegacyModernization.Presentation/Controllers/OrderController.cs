using LegacyModernization.Application.UseCases.CreateOrder;
using LegacyModernization.Core.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LegacyModernization.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController(IMediator mediator) : ControllerBase
    {
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        // to return 404 we need to implement a middleware that handles
        // custom exception or the type we would be using in this application
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetOrderQuery(id);
            var orderDto = await mediator.Send(query);

            return Ok(orderDto);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] List<OrderItem> items)
        {
            var command = new CreateOrderCommand(items);
            await mediator.Send(command);

            return Created();
        }
    }
}
