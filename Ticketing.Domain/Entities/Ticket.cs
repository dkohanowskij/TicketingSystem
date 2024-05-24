using System;
using System.Collections.Generic;
using Ticketing.Domain.Common;

namespace Ticketing.Domain.Entities;

public partial class Ticket : AuditableEntity
{
    public int SeatId { get; set; }

    public int Price { get; set; }

    public int OfferId { get; set; }

    public int? SectorId { get; set; }

    public int? RowId { get; set; }

    public virtual Offer Offer { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Seat Seat { get; set; } = null!;
}
