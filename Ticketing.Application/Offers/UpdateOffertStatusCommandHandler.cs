using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Application.Abstractions.Repositories;
using Ticketing.Application.Offers.Commands;
using Ticketing.Domain.Entities;

namespace Ticketing.Application.Offers
{
    public class UpdateOffertStatusCommandHandler(IUnitOfWork unitOfWork): IRequestHandler<UpdateOffertStatusCommand, Offer>
    {
        public async Task<Offer> Handle(UpdateOffertStatusCommand request, CancellationToken cancellationToken)
        {
            var offer = await unitOfWork.GetRepository<IOfferRepository>().Get(request.OfferID);
            if (offer == null)
            {
                offer.IsActive = request.Status;
                await unitOfWork.SaveAsync(cancellationToken);
            }

            return offer;
        }
    }
}
