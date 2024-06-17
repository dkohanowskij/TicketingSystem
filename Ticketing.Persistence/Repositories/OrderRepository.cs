using Microsoft.EntityFrameworkCore;
using Ticketing.Application.Abstractions.Repositories;
using Ticketing.Domain.Entities;
using Ticketing.Persistence.Context;

namespace Ticketing.Persistence.Repositories
{
    public class OrderRepository: GenericRepository<Order>, IOrderRepository
    {
        private readonly TicketingDbContext _dbContext;

        public OrderRepository(TicketingDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> GetOrderWithDetailsAsync(int id) => await _dbContext.Orders.FirstOrDefaultAsync(q => q.Id == id);
        public async Task<int?> GetOrderStatusAsync(int id) {
          var orderStatus = await _dbContext.Orders.FirstOrDefaultAsync(q => q.Id == id);
          return orderStatus == null ? 0 : orderStatus.Status;
        }
    }
}
