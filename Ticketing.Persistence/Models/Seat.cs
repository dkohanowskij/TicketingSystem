using System;
using System.Collections.Generic;

namespace Ticketing.Persistence.Models;

public partial class Seat
{
    public int Id { get; set; }

    public int? RowId { get; set; }

    public int? SeatNumber { get; set; }

    public bool? IsActive { get; set; }

    public DateOnly? DateCreated { get; set; }

    public DateOnly? DateModified { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual Row? Row { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
