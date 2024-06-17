using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Entities;

namespace Ticketing.Application.Offers.Commands
{
    public class UpdateOffertStatusCommand: IRequest<Offer>
    {
        public int OfferID { get; set; }
        public bool Status { get; set; }
    }
}
