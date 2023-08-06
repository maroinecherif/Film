using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FilmApi.Migrations
{
    /// <inheritdoc />
    public partial class addsomedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, 7.5, new DateTime(2023, 8, 6, 22, 4, 43, 507, DateTimeKind.Local).AddTicks(9554), "Movie 1" },
                    { 2, 8.1999999999999993, new DateTime(2023, 7, 6, 22, 4, 43, 507, DateTimeKind.Local).AddTicks(9595), "Movie 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
