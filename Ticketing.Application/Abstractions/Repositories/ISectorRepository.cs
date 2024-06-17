using Ticketing.Domain.Entities;

namespace Ticketing.Application.Abstractions.Repositories
{
    public interface ISectorRepository: IGenericRepository<Sector>
    {
        Task<IEnumerable<Sector>> GetSectorsByVenueAsync(int venueId);
    }
}
