using Ticketing.Application.Abstractions.Repositories;
using Ticketing.Domain.Entities;
using Ticketing.Persistence.Context;

namespace Ticketing.Persistence.Repositories
{
    public class RowRepository : GenericRepository<Row>, IRowRepository
    {
        private readonly TicketingDbContext _dbContext;

        public RowRepository(TicketingDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
