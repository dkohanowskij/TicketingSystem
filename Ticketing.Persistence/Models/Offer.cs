using System;
using System.Collections.Generic;

namespace Ticketing.Persistence.Models;

public partial class Offer
{
    public int Id { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public int VenueId { get; set; }

    public int EventId { get; set; }

    public bool? IsActive { get; set; }

    public DateOnly DateCreated { get; set; }

    public DateOnly DateModified { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public double? Price { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual Venue Venue { get; set; } = null!;
}
