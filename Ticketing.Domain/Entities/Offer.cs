using System;
using System.Collections.Generic;
using Ticketing.Domain.Common;

namespace Ticketing.Domain.Entities;

public partial class Offer: AuditableEntity
{
    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public int VenueId { get; set; }

    public int EventId { get; set; }

    public bool? IsActive { get; set; }

    public double? Price { get; set; }

    public int Status { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual Venue Venue { get; set; } = null!;
}
