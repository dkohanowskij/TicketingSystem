using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Entities;

namespace Ticketing.Application.Venues.Queries
{
    public class GetVenuesSectionsQuery: IRequest<IEnumerable<Sector>>
    {
        public int VenueID { get; set; }
    }
}
