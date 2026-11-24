using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingSystem.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedServiceTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 0, 30, 0, 0), "Klippning" },
                    { 2, new TimeSpan(0, 1, 30, 0, 0), "Hårfärgning" },
                    { 3, new TimeSpan(0, 0, 15, 0, 0), "Skäggtrimning" },
                    { 4, new TimeSpan(0, 0, 45, 0, 0), "Styling" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
