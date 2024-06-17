
using Ticketing.Domain.Entities;

namespace Ticketing.Application.Abstractions.Repositories
{
    public interface IUserRepository: IGenericRepository<User>
    {
        Task<User> GetUserWithDetails(int id);
    }
}
