using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Application.Abstractions.Repositories;
using Ticketing.Application.Orders.Commands;
using Ticketing.Domain.Entities;

namespace Ticketing.Application.Orders.Handlers
{
    public class RejectOrderCommandHandler(IUnitOfWork unitOfWork, ICartRepository cartRepository): IRequestHandler<RejectOrderCommand>
    {
        public async Task Handle(RejectOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await unitOfWork.GetRepository<IOrderRepository>().GetOrderWithDetailsAsync(request.OrderId);
            var orderOffers = await cartRepository.GetOffersByOrderIdAsunc(request.OrderId, cancellationToken);

            if (order is not null)
            {
                foreach (var offer in orderOffers)
                {
                    var offerFromOrder = await unitOfWork.GetRepository<IOfferRepository>().Get(offer.Id);
                    if (offerFromOrder is not null)
                    {
                        offerFromOrder.Status = 1;// Available
                    }
                }

                order.Status = 3;// Failed. Will be changed to enum value
                await unitOfWork.SaveAsync(cancellationToken);
            }
        }
    }
}
