using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Ticketing.Application.Cart.Commands;
using Ticketing.Application.Cart.Queries;
using Ticketing.Application.Venues.Queries;
using Ticketing.Domain.Entities;

namespace Ticketing.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CartOrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartOrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Offer>>> Get([FromRoute] long cartId) 
        {
            var result = await _mediator.Send(new GetCartDetailsQuery { CartId = (int)cartId});

            return Ok(result.Offers);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrderToCart([FromRoute]long cartId, [FromBody]Offer offer)
        {
            var result = await _mediator.Send(new AddOrderToCartCommand() { CartID = (int)cartId, Offer = offer });

            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteOrder([FromRoute] long cartId)
        {
            await _mediator.Send(new DeleteOrderFromCartCommand() { CartId = (int)cartId});

            return NoContent();
        }
    }
}
