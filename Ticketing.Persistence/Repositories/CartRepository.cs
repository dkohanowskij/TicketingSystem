using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Ticketing.Application.Abstractions.Repositories;
using Ticketing.Domain.Entities;

namespace Ticketing.Persistence.Repositories
{
    public class CartRepository : ICartRepository
    {
        IDistributedCache _distCache;

        public CartRepository(IDistributedCache distCache)
        {
            _distCache = distCache;
        }

        public async Task AddAsync(Cart cart, CancellationToken cancellationToken)
        {
            string key = $"order-{cart.OrderId}";
            await _distCache.SetStringAsync(key, JsonConvert.SerializeObject(cart.Offers), cancellationToken);
        }

        public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken)
        {
            string key = $"order-{id}";
            await _distCache.RemoveAsync(key, cancellationToken);
        }

        public async Task<Cart> GetCartByIdAsync(int id, CancellationToken cancellationToken)
        {
            string key = $"order-{id}";

            string cachedMemeber = await _distCache?.GetStringAsync(key);

            if (string.IsNullOrEmpty(cachedMemeber))
            {
                return null;
            }

            Cart cart = JsonConvert.DeserializeObject<Cart>(cachedMemeber);

            return cart;
        }

        public async Task<IEnumerable<Offer>> GetOffersByOrderIdAsunc(int id, CancellationToken cancellationToken)
        {
            string key = $"order-{id}";

            string cachedMemeber = await _distCache?.GetStringAsync(key, cancellationToken);

            if (string.IsNullOrEmpty(cachedMemeber))
            {
                return null;
            }

            Cart cart = JsonConvert.DeserializeObject<Cart>(cachedMemeber);

            return cart.Offers;
        }

        public async Task UpdateAsync(Cart cart, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
