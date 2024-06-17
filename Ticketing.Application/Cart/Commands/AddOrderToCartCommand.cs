using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Entities;

namespace Ticketing.Application.Cart.Commands
{
    public class AddOrderToCartCommand : IRequest<Ticketing.Domain.Entities.Cart>
    {
        public int CartID { get; set; }
        public Offer Offer { get;set;}
    }
}
