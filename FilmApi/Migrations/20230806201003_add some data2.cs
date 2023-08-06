using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmApi.Migrations
{
    /// <inheritdoc />
    public partial class addsomedata2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2023, 8, 6, 22, 10, 3, 449, DateTimeKind.Local).AddTicks(4988));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2023, 7, 6, 22, 10, 3, 449, DateTimeKind.Local).AddTicks(5018));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Username" },
                values: new object[] { 1, "testuser" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2023, 8, 6, 22, 4, 43, 507, DateTimeKind.Local).AddTicks(9554));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2023, 7, 6, 22, 4, 43, 507, DateTimeKind.Local).AddTicks(9595));
        }
    }
}
