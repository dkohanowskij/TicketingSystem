using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Application.Abstractions.Repositories;
using Ticketing.Application.Cart.Commands;

namespace Ticketing.Application.Cart.Handlers
{
    public class DeleteOrderFromCartCommandHandler(ICartRepository cartRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteOrderFromCartCommand>
    {
        public async Task Handle(DeleteOrderFromCartCommand request, CancellationToken cancellationToken)
        {
            var order = await unitOfWork.GetRepository<IOrderRepository>().GetOrderWithDetailsAsync(request.CartId);
            var orderOffers = await cartRepository.GetOffersByOrderIdAsunc(request.CartId, cancellationToken);

            if (order is not null)
            {
                order.Status = 4;// Deleted

                foreach (var offer in orderOffers)
                {
                    var offerFromOrder = await unitOfWork.GetRepository<IOfferRepository>().Get(offer.Id);
                    if (offerFromOrder is not null)
                    {
                        offerFromOrder.Status = 1;// Available
                    }
                }
            }

            await cartRepository.DeleteByIdAsync(request.CartId, cancellationToken);
            await unitOfWork.SaveAsync(cancellationToken);
        }
    }
}
