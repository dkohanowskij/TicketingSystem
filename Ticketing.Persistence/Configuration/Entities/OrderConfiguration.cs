using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Entities;

namespace Ticketing.Persistence.Configuration.Entities
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => e.Id).HasName("Order_pkey");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.TicketId).HasColumnName("TicketID");
            builder.Property(e => e.UserId).HasColumnName("UserID");

            builder.HasOne(d => d.Ticket).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("fk_ticketId");

            builder.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_userrId");
        }
    }
}
