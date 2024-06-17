using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Domain.Entities
{
    public  class Cart
    {
        public int OrderId { get; set; }
        public IEnumerable<Offer> Offers { get; set; }
    }
}
