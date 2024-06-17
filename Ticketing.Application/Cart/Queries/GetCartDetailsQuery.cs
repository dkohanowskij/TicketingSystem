using MediatR;
using Ticketing.Domain.Entities;

namespace Ticketing.Application.Cart.Queries
{
    public class GetCartDetailsQuery: IRequest<Ticketing.Domain.Entities.Cart>
    {
        public int CartId { get; set; }
    }
}
