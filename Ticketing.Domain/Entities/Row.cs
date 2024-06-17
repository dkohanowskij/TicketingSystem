using System;
using System.Collections.Generic;
using Ticketing.Domain.Common;

namespace Ticketing.Domain.Entities;

public partial class Row: AuditableEntity
{ 
    public int SectorId { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();

    public virtual Sector Sector { get; set; } = null!;
}
