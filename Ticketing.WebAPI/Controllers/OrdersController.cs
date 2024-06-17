using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticketing.Application.Orders.Commands;
using Ticketing.Application.Orders.Queries;
using Ticketing.Application.Venues.Queries;
using Ticketing.Domain.Entities;

namespace Ticketing.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{orderId}/sections")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> GetVenuesSections([FromQuery] long orderId)
        {
            var result = await _mediator.Send(new GetOrderStatusQuery() { OrderId = (int)orderId });

            return Ok(result);
        }

        [HttpGet("{orderId}/complete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CompleteOrder([FromRoute] long orderId)
        {
            await _mediator.Send(new PayOrderCommand() { OrderID = (int)orderId });

            return NoContent();
        }

        [HttpGet("{orderId}/reject")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RejectOrder([FromRoute] long orderId)
        {
            await _mediator.Send(new RejectOrderCommand() { OrderId = (int)orderId });

            return NoContent();
        }
    }
}
