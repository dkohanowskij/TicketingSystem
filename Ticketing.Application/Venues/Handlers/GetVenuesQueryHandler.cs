using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Application.Abstractions.Repositories;
using Ticketing.Application.Venues.Queries;
using Ticketing.Domain.Entities;

namespace Ticketing.Application.Venues.Handlers
{
    public class GetVenuesQueryHandler(IVenueRepository venueRepository) : IRequestHandler<GetVenuesQuery, IEnumerable<Venue>>
    {
        public async Task<IEnumerable<Venue>> Handle(GetVenuesQuery request, CancellationToken cancellationToken)
        {
            return await venueRepository.GetAll();
        }
    }
}
