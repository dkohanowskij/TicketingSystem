using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Application.Abstractions.Repositories;
using Ticketing.Domain.Entities;
using Ticketing.Persistence.Context;

namespace Ticketing.Persistence.Repositories
{
    internal class SectorRepository : GenericRepository<Sector>, ISectorRepository
    {
        private readonly TicketingDbContext _dbContext;

        public SectorRepository(TicketingDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
