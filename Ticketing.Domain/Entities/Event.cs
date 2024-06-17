using System;
using System.Collections.Generic;
using Ticketing.Domain.Common;

namespace Ticketing.Domain.Entities;

public partial class Event: AuditableEntity
{
    public int PlaceId { get; set; }

    public DateOnly EventStartDate { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

    public virtual Venue Place { get; set; } = null!;
}
