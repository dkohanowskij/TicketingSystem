using System;
using System.Collections.Generic;

namespace Ticketing.Persistence.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public int SeatId { get; set; }

    public int Price { get; set; }

    public DateOnly DateCreated { get; set; }

    public DateOnly? DateModified { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? ModifiedBy { get; set; }

    public int OfferId { get; set; }

    public int? SectorId { get; set; }

    public int? RowId { get; set; }

    public virtual Offer Offer { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Seat Seat { get; set; } = null!;
}
