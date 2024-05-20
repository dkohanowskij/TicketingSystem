using System;
using System.Collections.Generic;

namespace Ticketing.Persistence.Models;

public partial class Sector
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int VenueId { get; set; }

    public bool? IsActive { get; set; }

    public DateOnly DateCreated { get; set; }

    public DateOnly? DateModified { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual ICollection<Row> Rows { get; set; } = new List<Row>();

    public virtual Venue Venue { get; set; } = null!;
}
