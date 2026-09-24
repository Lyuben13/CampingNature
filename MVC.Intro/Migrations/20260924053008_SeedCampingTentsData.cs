using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Intro.Migrations
{
    /// <inheritdoc />
    public partial class SeedCampingTentsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CampingTents",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CampingTents",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CampingTents",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CampingTents",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 5, 29, 33, 218, DateTimeKind.Utc).AddTicks(1523));

            migrationBuilder.UpdateData(
                table: "CampingTents",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 5, 29, 33, 218, DateTimeKind.Utc).AddTicks(3534));

            migrationBuilder.UpdateData(
                table: "CampingTents",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 5, 29, 33, 218, DateTimeKind.Utc).AddTicks(3538));
        }
    }
}
