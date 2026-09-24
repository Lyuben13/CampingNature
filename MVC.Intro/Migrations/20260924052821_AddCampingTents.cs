using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Intro.Migrations
{
    /// <inheritdoc />
    public partial class AddCampingTents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CampingTents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    IsWaterproof = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasVentilation = table.Column<bool>(type: "INTEGER", nullable: false),
                    Features = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampingTents", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampingTents");
        }
    }
}
