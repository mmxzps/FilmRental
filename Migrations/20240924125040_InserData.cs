using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FilmRental.Migrations
{
    /// <inheritdoc />
    public partial class InserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, 2019, "John Wick" },
                    { 2, 2021, "John Wick2" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { 2, "mail@msn.se", "Tobias" },
                    { 3, "John@msn.se", "John" }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "FK_MovieId", "FK_UserId", "LoanDate", "ReturnDate" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 9, 24, 14, 50, 40, 128, DateTimeKind.Local).AddTicks(8274), null },
                    { 2, 2, 2, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
