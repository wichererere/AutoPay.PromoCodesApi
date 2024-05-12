using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPay.PromoCodesApi.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Entity = table.Column<string>(type: "TEXT", unicode: false, nullable: false),
                    State = table.Column<string>(type: "TEXT", unicode: false, nullable: false),
                    PrimaryKey = table.Column<string>(type: "TEXT", unicode: false, nullable: true),
                    OldValues = table.Column<string>(type: "TEXT", unicode: false, nullable: true),
                    NewValues = table.Column<string>(type: "TEXT", unicode: false, nullable: true),
                    AffectedColumns = table.Column<string>(type: "TEXT", unicode: false, nullable: true),
                    CreateOnUtc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromoCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    MaxPossibleDownloads = table.Column<uint>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoCodes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PromoCodes_Code",
                table: "PromoCodes",
                column: "Code",
                unique: true,
                filter: "[IsActive] = 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "PromoCodes");
        }
    }
}
