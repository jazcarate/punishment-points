using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PunishmentPointsApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PunishmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Punishments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AuthorId = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "date", nullable: false),
                    Reason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Punishments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Punishments_TeamMembers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "TeamMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Punishments_AuthorId",
                table: "Punishments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_PunishmentId",
                table: "TeamMembers",
                column: "PunishmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Punishments_PunishmentId",
                table: "TeamMembers",
                column: "PunishmentId",
                principalTable: "Punishments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Punishments_TeamMembers_AuthorId",
                table: "Punishments");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "Punishments");
        }
    }
}
