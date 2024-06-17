using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Application.Abstractions.Repositories;
using Ticketing.Application.Cart.Queries;

namespace Ticketing.Application.Cart.Handlers
{
    public class GetCartDetailsQueryHandler : IRequestHandler<GetCartDetailsQuery, Ticketing.Domain.Entities.Cart>
    {
        private ICartRepository _cartRepository;

        public GetCartDetailsQueryHandler(ICartRepository cartRepository) {
            _cartRepository = cartRepository;
        }
        public async Task<Domain.Entities.Cart> Handle(GetCartDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _cartRepository.GetCartByIdAsync(request.CartId, cancellationToken);
        }
    }
}
