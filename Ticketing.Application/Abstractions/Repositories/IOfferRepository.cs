using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Entities;

namespace Ticketing.Application.Abstractions.Repositories
{
    public interface IOfferRepository: IGenericRepository<Offer>
    {
    }
}
