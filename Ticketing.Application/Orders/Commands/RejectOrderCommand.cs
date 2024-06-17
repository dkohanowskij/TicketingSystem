using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Application.Orders.Commands
{
    public class RejectOrderCommand: IRequest
    {
        public int OrderId { get; set;}
    }
}
