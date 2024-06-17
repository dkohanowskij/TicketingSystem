using System;
using System.Collections.Generic;
using Ticketing.Domain.Common;

namespace Ticketing.Domain.Entities;

public partial class Sector: AuditableEntity
{ 
    public string Name { get; set; } = null!;

    public int VenueId { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Row> Rows { get; set; } = new List<Row>();

    public virtual Venue Venue { get; set; } = null!;
}
