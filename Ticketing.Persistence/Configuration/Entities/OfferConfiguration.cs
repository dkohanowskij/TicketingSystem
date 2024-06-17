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
    public class OfferConfiguration: IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasKey(e => e.Id).HasName("Offers_pkey");

            builder.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
            builder.Property(e => e.EventId).HasColumnName("EventID");
            builder.Property(e => e.VenueId).HasColumnName("VenueID");

            builder.HasOne(d => d.Event).WithMany(p => p.Offers)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_eventId");

            builder.HasOne(d => d.Venue).WithMany(p => p.Offers)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_venueId");
        }
    }
}
