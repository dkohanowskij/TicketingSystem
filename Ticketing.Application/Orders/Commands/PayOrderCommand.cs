using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Entities;

namespace Ticketing.Application.Orders.Commands
{
    public class PayOrderCommand: IRequest<Order?>
    {
       public int OrderID { get; set; }
    }
}
