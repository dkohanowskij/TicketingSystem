using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Application.Cart.Commands
{
    public class DeleteOrderFromCartCommand: IRequest
    {
        public int CartId { get; set; }
    }
}
