﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Ticketing.Persistence.Context;


#nullable disable

namespace Ticketing.Persistence.Migrations
{
    [DbContext(typeof(TicketingDbContext))]
    partial class TicketingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Ticketing.Persistence.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("ID");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateOnly>("DateCreated")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DateModified")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("EventStartDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PlaceId")
                        .HasColumnType("integer")
                        .HasColumnName("PlaceID");

                    b.HasKey("Id")
                        .HasName("Events_pkey");

                    b.HasIndex(new[] { "PlaceId" }, "fki_FK_PlaceID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Ticketing.Persistence.Models.Offer", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("ID");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateOnly>("DateCreated")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DateModified")
                        .HasColumnType("date");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<int>("EventId")
                        .HasColumnType("integer")
                        .HasColumnName("EventID");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<double?>("Price")
                        .HasColumnType("double precision");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.Property<int>("VenueId")
                        .HasColumnType("integer")
                        .HasColumnName("VenueID");

                    b.HasKey("Id")
                        .HasName("Offers_pkey");

                    b.HasIndex("EventId");

                    b.HasIndex("VenueId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("Ticketing.Persistence.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateOnly?>("DateCreated")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DateModified")
                        .HasColumnType("date");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<int?>("Status")
                        .HasColumnType("integer");

                    b.Property<int?>("TicketId")
                        .HasColumnType("integer")
                        .HasColumnName("TicketID");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("UserID");

                    b.HasKey("Id")
                        .HasName("Order_pkey");

                    b.HasIndex("TicketId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Ticketing.Persistence.Models.Row", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateOnly>("DateCreated")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DateModified")
                        .HasColumnType("date");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<int>("SectorId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("Rows_pkey");

                    b.HasIndex("SectorId");

                    b.ToTable("Rows");
                });

            modelBuilder.Entity("Ticketing.Persistence.Models.Seat", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateOnly?>("DateCreated")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DateModified")
                        .HasColumnType("date");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<int?>("RowId")
                        .HasColumnType("integer");

                    b.Property<int?>("SeatNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("Seats_pkey");

                    b.HasIndex("RowId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("Ticketing.Persistence.Models.Sector", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateOnly>("DateCreated")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DateModified")
                        .HasColumnType("date");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("VenueId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("Sectors_pkey");

                    b.HasIndex("VenueId");

                    b.ToTable("Sectors");
                });

            modelBuilder.Entity("Ticketing.Persistence.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("ID");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("DateCreated")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DateModified")
                        .HasColumnType("date");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<int>("OfferId")
                        .HasColumnType("integer")
                        .HasColumnName("OfferID");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int?>("RowId")
                        .HasColumnType("integer")
                        .HasColumnName("RowID");

                    b.Property<int>("SeatId")
                        .HasColumnType("integer")
                        .HasColumnName("SeatID");

                    b.Property<int?>("SectorId")
                        .HasColumnType("integer")
                        .HasColumnName("SectorID");

                    b.HasKey("Id")
                        .HasName("Ticket_pkey");

                    b.HasIndex("OfferId");

                    b.HasIndex("SeatId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Ticketing.Persistence.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateOnly?>("DateCreated")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DateModified")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("Users_pkey");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Ticketing.Persistence.Models.Venue", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("ID");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateOnly>("DateCreated")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DateModified")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("Places_pkey");

                    b.ToTable("Venues");
                });

            modelBuilder.Entity("Ticketing.Persistence.Models.Event", b =>
                {
                    b.HasOne("Ticketing.Persistence.Models.Venue", "Place")
                        .WithMany("Events")
                        .HasForeignKey("PlaceId")
                        .IsRequired()
                        .HasConstraintName("FK_PlaceID");

                    b.Navigation("Place");
                });

            modelBuilder.Entity("Ticketing.Persistence.Models.Offer", b =>
                {
                    b.HasOne("Ticketing.Persistence.Models.Event", "Event")
                        .WithMany("Offers")
                        .HasForeignKey("EventId")
                        .IsRequired()
                        .HasConstraintName("fk_eventId");

                    b.HasOne("Ticketing.Persistence.Models.Venue", "Venue")
                        .WithMany("Offers")
                        .HasForeignKey("VenueId")
                        .IsRequired()
                        .HasConstraintName("fk_venueId");

                    b.Navigation("Event");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("Ticketing.Persistence.Models.Order", b =>
                {
                    b.HasOne("Ticketing.Persistence.Models.Ticket", "Ticket")
                        .WithMany("Orders")
                        .HasForeignKey("TicketId")
                        .HasConstraintName("fk_ticketId");

                    b.HasOne("Ticketing.Persistence.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_userrId");

                    b.Navigation("Ticket");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ticketing.Persistence.Models.Row", b =>
                {
                    b.HasOne("Ticketing.Persistence.Models.Sector", "Sector")
                        .WithMany("Rows")
                        .HasForeignKey("SectorId")
                        .IsRequired()
                        .HasConstraintName("fk_sectorId");

                    b.Navigation("Sector");
                });

            modelBuilder.Entity("Ticketing.Persistence.Models.Seat", b =>
                {
                    b.HasOne("Ticketing.Persistence.Models.Row", "Row")
                        .WithMany("Seats")
                        .HasForeignKey("RowId")
                        .HasConstraintName("fo_rowId");

                    b.Navigation("Row");
                });

            modelBuilder.Entity("Ticketing.Persistence.Models.Sector", b =>
                {
                    b.HasOne("Ticketing.Persistence.Models.Venue", "Venue")
                        .WithMany("Sectors")
                        .HasForeignKey("VenueId")
                        .IsRequired()
                        .HasConstraintName("fk_venueId");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("Ticketing.Persistence.Models.Ticket", b =>
                {
                    b.HasOne("Ticketing.Persistence.Models.Offer", "Offer")
                        .WithMany("Tickets")
                        .HasForeignKey("OfferId")
                        .IsRequired()
                        .HasConstraintName("fk_offerId");

                    b.HasOne("Ticketing.Persistence.Models.Seat", "Seat")
                        .WithMany("Tickets")
                        .HasForeignKey("SeatId")
                        .IsRequired()
                        .HasConstraintName("fk_seadId");

                    b.Navigation("Offer");

                    b.Navigation("Seat");
                });

            modelBuilder.Entity("Ticketing.Persistence.Models.Event", b =>
                {
                    b.Navigation("Offers");
                });

            modelBuilder.Entity("Ticketing.Persistence.Models.Offer", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Ticketing.Persistence.Models.Row", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("Ticketing.Persistence.Models.Seat", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Ticketing.Persistence.Models.Sector", b =>
                {
                    b.Navigation("Rows");
                });

            modelBuilder.Entity("Ticketing.Persistence.Models.Ticket", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Ticketing.Persistence.Models.User", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Ticketing.Persistence.Models.Venue", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Offers");

                    b.Navigation("Sectors");
                });
#pragma warning restore 612, 618
        }
    }
}
