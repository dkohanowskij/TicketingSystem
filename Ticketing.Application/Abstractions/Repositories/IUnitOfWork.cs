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
        //Start the database Transaction
        void CreateTransaction();
        //Commit the database Transaction
        void Commit();
        //Rollback the database Transaction
        void Rollback();
        //DbContext Class SaveChanges method
        Task SaveAsync(CancellationToken cancellationToken);
        //Get repository by type
        TRepository GetRepository<TRepository>();
    }
}
