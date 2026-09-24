using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVC.Intro.Migrations
{
    /// <inheritdoc />
    public partial class SeedCampingTents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CampingTents",
                columns: new[] { "Id", "Capacity", "CreatedAt", "Description", "Features", "HasVentilation", "ImagePath", "IsWaterproof", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(2026, 9, 24, 5, 29, 33, 218, DateTimeKind.Utc).AddTicks(1523), "Луксозна палатка за 4-ма души с водоустойчиво покритие и вентилация", "Водоустойчива, Вентилация, 4-ма души", true, "images/palatka1.jpg", true, "Палатка Експлорер", 450.00m },
                    { 2, 2, new DateTime(2026, 9, 24, 5, 29, 33, 218, DateTimeKind.Utc).AddTicks(3534), "Компактна и лека палатка за 2-ма души, идеална за планински преходи", "Лека, Планинска, 2-ма души", false, "images/palatka2.jpg", true, "Палатка Авантюрист", 280.00m },
                    { 3, 6, new DateTime(2026, 9, 24, 5, 29, 33, 218, DateTimeKind.Utc).AddTicks(3538), "Голяма семейна палатка с две стаи и тераса за комфорт", "Две стаи, Тераса, 6-ма души", true, "images/palatka3.jpg", true, "Палатка Семейна", 620.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CampingTents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CampingTents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CampingTents",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
