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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly TicketingDbContext _dbContext;

        public UserRepository(TicketingDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<User> GetUserWithDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}
