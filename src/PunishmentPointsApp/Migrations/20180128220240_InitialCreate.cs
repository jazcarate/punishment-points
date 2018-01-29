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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncomingMessages",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ChannelId = table.Column<string>(nullable: true),
                    FromId = table.Column<string>(nullable: true),
                    LocalTimestamp = table.Column<DateTime>(type: "date", nullable: false),
                    ServiceUrl = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomingMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomingMessages_TeamMembers_FromId",
                        column: x => x.FromId,
                        principalTable: "TeamMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Entity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IncomingMessageId = table.Column<string>(nullable: true),
                    MentionedId = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entity_IncomingMessages_IncomingMessageId",
                        column: x => x.IncomingMessageId,
                        principalTable: "IncomingMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entity_TeamMembers_MentionedId",
                        column: x => x.MentionedId,
                        principalTable: "TeamMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Punishments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AuthorId = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "date", nullable: false),
                    FromId = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    RecipientId = table.Column<string>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Punishments_IncomingMessages_FromId",
                        column: x => x.FromId,
                        principalTable: "IncomingMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Punishments_TeamMembers_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "TeamMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entity_IncomingMessageId",
                table: "Entity",
                column: "IncomingMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_MentionedId",
                table: "Entity",
                column: "MentionedId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomingMessages_FromId",
                table: "IncomingMessages",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_Punishments_AuthorId",
                table: "Punishments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Punishments_FromId",
                table: "Punishments",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_Punishments_RecipientId",
                table: "Punishments",
                column: "RecipientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entity");

            migrationBuilder.DropTable(
                name: "Punishments");

            migrationBuilder.DropTable(
                name: "IncomingMessages");

            migrationBuilder.DropTable(
                name: "TeamMembers");
        }
    }
}
