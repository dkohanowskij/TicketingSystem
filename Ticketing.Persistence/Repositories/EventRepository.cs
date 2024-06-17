using Ticketing.Application.Abstractions.Repositories;
using Ticketing.Domain.Entities;
using Ticketing.Persistence.Context;

namespace Ticketing.Persistence.Repositories
{
    public class EventRepository: GenericRepository<Event>, IEventRepository
    {
        private readonly TicketingDbContext _dbContext;

        public EventRepository(TicketingDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
