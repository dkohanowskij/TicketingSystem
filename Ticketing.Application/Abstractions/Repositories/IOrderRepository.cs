using Ticketing.Domain.Entities;

namespace Ticketing.Application.Abstractions.Repositories
{
    public interface IOrderRepository: IGenericRepository<Order>
    {
        Task<Order> GetOrderWithDetails(int id);
    }
}
