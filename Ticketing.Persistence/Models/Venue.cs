using System;
using System.Collections.Generic;

namespace Ticketing.Persistence.Models;

public partial class Venue
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public DateOnly DateCreated { get; set; }

    public DateOnly? DateModified { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

    public virtual ICollection<Sector> Sectors { get; set; } = new List<Sector>();
}
