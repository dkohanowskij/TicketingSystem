using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Entities;

namespace Ticketing.Application.Abstractions.Repositories
{
    public interface ICartRepository
    {
        public Task<Ticketing.Domain.Entities.Cart> GetCartByIdAsync(int id, CancellationToken cancellationToken);
        public Task<IEnumerable<Offer>> GetOffersByOrderIdAsunc(int id, CancellationToken cancellationToken);
        public Task AddAsync(Ticketing.Domain.Entities.Cart cart, CancellationToken cancellationToken);
        public Task UpdateAsync(Ticketing.Domain.Entities.Cart cart, CancellationToken cancellationToken);
        public Task DeleteByIdAsync(int id, CancellationToken cancellationToken);
    }
}
