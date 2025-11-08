using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashSaleDB.Migrations
{
    /// <inheritdoc />
    public partial class AddReservationColumnsToOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CorrelationId",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReservationId",
                table: "Order",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrelationId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Order");
        }
    }
}
