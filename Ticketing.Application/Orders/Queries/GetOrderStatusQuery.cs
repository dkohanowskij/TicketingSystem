using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Entities;

namespace Ticketing.Application.Orders.Queries
{
    public class GetOrderStatusQuery: IRequest<int?>
    {
        public int OrderId { get; set; }
    }
}
