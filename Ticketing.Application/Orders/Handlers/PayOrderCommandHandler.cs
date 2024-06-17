using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Application.Abstractions.Repositories;
using Ticketing.Application.Orders.Commands;
using Ticketing.Application.Orders.Queries;
using Ticketing.Domain.Entities;

namespace Ticketing.Application.Orders.Handlers
{
    public class PayOrderCommandHandler(ICartRepository cartRepository, IUnitOfWork unitOfWork) : IRequestHandler<PayOrderCommand, Order?>
    {
        public async Task<Order?> Handle(PayOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await unitOfWork.GetRepository<IOrderRepository>().GetOrderWithDetailsAsync(request.OrderID);
            var orderOffers = await cartRepository.GetOffersByOrderIdAsunc(request.OrderID, cancellationToken);

            if (order is not null) {

                foreach (var offer in orderOffers) {
                    var offerFromOrder = await unitOfWork.GetRepository<IOfferRepository>().Get(offer.Id);
                    if (offerFromOrder is not null)
                    {
                        offerFromOrder.Status = 2;
                    }
                }

                order.Status = 2;// Will be changed to enum value
                await unitOfWork.SaveAsync(cancellationToken);
            }

            return order ?? null;
        }
    }
}
