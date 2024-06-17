using MediatR;
using Ticketing.Application.Abstractions.Repositories;
using Ticketing.Application.Events.Handlers.Queries;
using Ticketing.Domain.Entities;

namespace Ticketing.Application.Events.Handlers.Handlers
{
    public class GetEventsQueryHandler(IEventRepository eventRepository) : IRequestHandler<GetEventsQuery, IEnumerable<Event>>
    {
        public async Task<IEnumerable<Event>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            return await eventRepository.GetAll();
        }
    }
}
