﻿using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;
using Ticketing.Application.Abstractions.Repositories;
using Ticketing.Persistence.Context;

namespace Ticketing.Persistence
{
    public class UnitOfWork(TicketingDbContext context, IServiceProvider serviceProvider) : IUnitOfWork
    {
        private IDbContextTransaction _objTran;

        private bool _disposed;

        public void Save()
        {
            context.SaveChanges();
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            try
            {
                CreateTransaction();
                await context.SaveChangesAsync(cancellationToken);
                Commit();
            }
            catch (Exception)
            {
                Rollback();
            }
        }
            

        public void CreateTransaction()
        {
            _objTran = context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _objTran.Commit();
        }

        public void Rollback()
        {
            _objTran.Rollback();
            _objTran.Dispose();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                _disposed = true;
            }
        }

        public TRepository GetRepository<TRepository>()
        {
            var repository = ActivatorUtilities.CreateInstance<TRepository>(serviceProvider, context);

            return repository;
        }
    }
}
