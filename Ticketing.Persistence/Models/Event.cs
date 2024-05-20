using System;
using System.Collections.Generic;

namespace Ticketing.Persistence.Models;

public partial class Event
{
    public int Id { get; set; }

    public int PlaceId { get; set; }

    public DateOnly EventStartDate { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateOnly DateCreated { get; set; }

    public DateOnly? DateModified { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

    public virtual Venue Place { get; set; } = null!;
}
