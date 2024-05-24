using System;
using System.Collections.Generic;
using Ticketing.Domain.Common;

namespace Ticketing.Domain.Entities;

public partial class Order: AuditableEntity
{
    public int? TicketId { get; set; }

    public int? UserId { get; set; }

    public int? Status { get; set; }

    public virtual Ticket? Ticket { get; set; }

    public virtual User? User { get; set; }
}
