using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Entities;

namespace Ticketing.Application.Events.Handlers.Queries
{
    public class GetEventsQuery: IRequest<IEnumerable<Event>>
    {
    }
}
