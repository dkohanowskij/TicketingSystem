using System;
using System.Collections.Generic;

namespace Ticketing.Persistence.Models;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateOnly? DateCreated { get; set; }

    public DateOnly? DateModified { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
