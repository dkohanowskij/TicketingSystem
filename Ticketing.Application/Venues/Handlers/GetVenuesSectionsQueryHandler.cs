using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Application.Abstractions.Repositories;
using Ticketing.Application.Venues.Queries;
using Ticketing.Domain.Entities;

namespace Ticketing.Application.Venues.Handlers
{
    public class GetVenuesSectionsQueryHandler(ISectorRepository sectorRepository) : IRequestHandler<GetVenuesSectionsQuery, IEnumerable<Sector>>
    {
        public async Task<IEnumerable<Sector>> Handle(GetVenuesSectionsQuery request, CancellationToken cancellationToken)
        {
            return await sectorRepository.GetSectorsByVenueAsync(request.VenueID);
        }
    }
}
