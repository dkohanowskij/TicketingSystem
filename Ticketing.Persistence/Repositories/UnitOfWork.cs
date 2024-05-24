using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Application.Abstractions.Repositories;
using Ticketing.Persistence.Context;

namespace Ticketing.Persistence.Repositories
{
    public class UnitOfWork(TicketingDbContext context) : IUnitOfWork
    {

        private IEventRepository _eventRepository;
        private IOfferRepository _offerRepository;
        private IOrderRepository _orderRepository;
        private IRowRepository _rowRepository;
        private ISeatRepository _seatRepository;
        private ISectorRepository _sectorRepository;
        private ITicketRepository _ticketRepository;
        private IUserRepository _userRepository;
        private IVenueRepository _venueRepository;

        public IEventRepository EventRepository =>
            _eventRepository ??= new EventRepository(context);

        public IOfferRepository OfferRepository =>
            _offerRepository ??= new OfferRepository(context);

        public IOrderRepository OrderRepository =>
            _orderRepository ??= new OrderRepository(context);

        public IRowRepository RowRepository =>
            _rowRepository ??= new RowRepository(context);

        public ISeatRepository SeatRepository =>
            _seatRepository ??= new SeatRepository(context);
        public ISectorRepository SectorRepository =>
            _sectorRepository ??= new SectorRepository(context);

        public ITicketRepository TicketRepository =>
            _ticketRepository ??= new TicketRepository(context);

        public IUserRepository UserRepository =>
            _userRepository ??= new UserRepository(context);

        public IVenueRepository VenueRepository =>
            _venueRepository ??= new VenueRepository(context);


        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(CancellationToken cancellationToken)
        {
            await context.SaveChangesAsync(cancellationToken);
        }

        //public TRepository GetRepository<TRepository>()
        //{
        //    var theInterface = typeof(TRepository);

        //    var type = AppDomain.CurrentDomain.GetAssemblies()
        //        .SelectMany(a => a.GetTypes())
        //        .FirstOrDefault(t => theInterface.IsAssignableFrom(t));

        //}
    }
}
