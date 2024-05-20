using System;
using System.Collections.Generic;

namespace Ticketing.Persistence.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? TicketId { get; set; }

    public int? UserId { get; set; }

    public int? Status { get; set; }

    public string? ModifiedBy { get; set; }

    public string? CreatedBy { get; set; }

    public DateOnly? DateCreated { get; set; }

    public DateOnly? DateModified { get; set; }

    public virtual Ticket? Ticket { get; set; }

    public virtual User? User { get; set; }
}
