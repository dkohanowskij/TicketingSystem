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
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id).HasName("Events_pkey");

            builder.HasIndex(e => e.PlaceId, "fki_FK_PlaceID");

            builder.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
            builder.Property(e => e.PlaceId).HasColumnName("PlaceID");

            builder.HasOne(d => d.Place).WithMany(p => p.Events)
                    .HasForeignKey(d => d.PlaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlaceID");
        }
    }
}
