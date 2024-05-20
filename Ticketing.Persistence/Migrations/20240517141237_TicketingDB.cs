using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketing.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TicketingDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateOnly>(type: "date", nullable: true),
                    DateModified = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Users_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    DateCreated = table.Column<DateOnly>(type: "date", nullable: false),
                    DateModified = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Places_pkey", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false),
                    PlaceID = table.Column<int>(type: "integer", nullable: false),
                    EventStartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateOnly>(type: "date", nullable: false),
                    DateModified = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Events_pkey", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PlaceID",
                        column: x => x.PlaceID,
                        principalTable: "Venues",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    VenueId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    DateCreated = table.Column<DateOnly>(type: "date", nullable: false),
                    DateModified = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Sectors_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "fk_venueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    VenueID = table.Column<int>(type: "integer", nullable: false),
                    EventID = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    DateCreated = table.Column<DateOnly>(type: "date", nullable: false),
                    DateModified = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Offers_pkey", x => x.ID);
                    table.ForeignKey(
                        name: "fk_eventId",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "fk_venueId",
                        column: x => x.VenueID,
                        principalTable: "Venues",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Rows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    SectorId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    DateCreated = table.Column<DateOnly>(type: "date", nullable: false),
                    DateModified = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Rows_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "fk_sectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    RowId = table.Column<int>(type: "integer", nullable: true),
                    SeatNumber = table.Column<int>(type: "integer", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    DateCreated = table.Column<DateOnly>(type: "date", nullable: true),
                    DateModified = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Seats_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "fo_rowId",
                        column: x => x.RowId,
                        principalTable: "Rows",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false),
                    SeatID = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateOnly>(type: "date", nullable: false),
                    DateModified = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    OfferID = table.Column<int>(type: "integer", nullable: false),
                    SectorID = table.Column<int>(type: "integer", nullable: true),
                    RowID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Ticket_pkey", x => x.ID);
                    table.ForeignKey(
                        name: "fk_offerId",
                        column: x => x.OfferID,
                        principalTable: "Offers",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "fk_seadId",
                        column: x => x.SeatID,
                        principalTable: "Seats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    TicketID = table.Column<int>(type: "integer", nullable: true),
                    UserID = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateOnly>(type: "date", nullable: true),
                    DateModified = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Order_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "fk_ticketId",
                        column: x => x.TicketID,
                        principalTable: "Tickets",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "fk_userrId",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "fki_FK_PlaceID",
                table: "Events",
                column: "PlaceID");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_EventID",
                table: "Offers",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_VenueID",
                table: "Offers",
                column: "VenueID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TicketID",
                table: "Orders",
                column: "TicketID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID",
                table: "Orders",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Rows_SectorId",
                table: "Rows",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_RowId",
                table: "Seats",
                column: "RowId");

            migrationBuilder.CreateIndex(
                name: "IX_Sectors_VenueId",
                table: "Sectors",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OfferID",
                table: "Tickets",
                column: "OfferID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SeatID",
                table: "Tickets",
                column: "SeatID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Rows");

            migrationBuilder.DropTable(
                name: "Sectors");

            migrationBuilder.DropTable(
                name: "Venues");
        }
    }
}
