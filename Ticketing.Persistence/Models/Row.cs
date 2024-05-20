using System;
using System.Collections.Generic;

namespace Ticketing.Persistence.Models;

public partial class Row
{
    public int Id { get; set; }

    public int SectorId { get; set; }

    public bool? IsActive { get; set; }

    public DateOnly DateCreated { get; set; }

    public DateOnly? DateModified { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();

    public virtual Sector Sector { get; set; } = null!;
}
