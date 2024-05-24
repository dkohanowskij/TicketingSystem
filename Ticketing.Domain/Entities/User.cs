using System;
using System.Collections.Generic;
using Ticketing.Domain.Common;

namespace Ticketing.Domain.Entities;

public partial class User: AuditableEntity
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
