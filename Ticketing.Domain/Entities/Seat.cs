using System;
using System.Collections.Generic;
using Ticketing.Domain.Common;

namespace Ticketing.Domain.Entities;

public partial class Seat: AuditableEntity
{
    public int? RowId { get; set; }

    public int? SeatNumber { get; set; }

    public bool? IsActive { get; set; }

    public virtual Row? Row { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
