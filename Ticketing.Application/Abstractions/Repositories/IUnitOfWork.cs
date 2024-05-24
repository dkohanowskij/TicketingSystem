using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Entities;

namespace Ticketing.Application.Abstractions.Repositories
{
    public interface IUnitOfWork: IDisposable
    {
        //TRepository GetRepository<TRepository>();

        IOrderRepository OrderRepository { get; }

        Task Save(CancellationToken cancellationToken);
    }
}
