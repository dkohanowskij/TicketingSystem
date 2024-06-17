using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Application.Abstractions.Repositories;
using Ticketing.Application.Cart.Commands;
using Ticketing.Application.Orders.Commands;
using Ticketing.Domain.Entities;

namespace Ticketing.Application.Cart.Handlers
{
    public class AddOrderToCartCommandHandler(ICartRepository cartRepository, IUnitOfWork unitOfWork) : IRequestHandler<AddOrderToCartCommand, Ticketing.Domain.Entities.Cart>
    {
        public async Task<Domain.Entities.Cart> Handle(AddOrderToCartCommand request, CancellationToken cancellationToken)
        {
            var order = await unitOfWork.GetRepository<IOrderRepository>().GetOrderWithDetailsAsync(request.CartID);
            if (order is not null)
            {
                await cartRepository.AddAsync(cart: new Domain.Entities.Cart() { OrderId = request.CartID, Offers = new List<Offer>() { request.Offer } }, cancellationToken);
            }

            var cart = await cartRepository.GetCartByIdAsync(request.CartID, cancellationToken);

            return cart;
        }
    }
}
