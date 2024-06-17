using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Application.Abstractions.Repositories;
using Ticketing.Application.Orders.Queries;
using Ticketing.Domain.Entities;

namespace Ticketing.Application.Orders.Handlers
{
    public class GetOrderStatusQueryHandler(IOrderRepository orderRepository) : IRequestHandler<GetOrderStatusQuery, int?>
    {
        public async Task<int?> Handle(GetOrderStatusQuery request, CancellationToken cancellationToken)
        {
            return await orderRepository.GetOrderStatusAsync(request.OrderId);
        }
    }
}
