using MediatR;
using Ticketing.Domain.Entities;

namespace Ticketing.Application.Venues.Queries
{
    public class GetVenuesQuery: IRequest<IEnumerable<Venue>>
    {

    }
}
