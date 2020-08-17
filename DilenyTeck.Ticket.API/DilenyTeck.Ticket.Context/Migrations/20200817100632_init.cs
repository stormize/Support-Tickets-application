using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DilenyTeck.Ticket.Context.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ticket",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    Status = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(maxLength: 300, nullable: true),
                    LastStatusChange = table.Column<DateTime>(nullable: false),
                    FK_UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ticket_user_FK_UserId",
                        column: x => x.FK_UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "audit log",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Action = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    FK_UserId = table.Column<Guid>(nullable: false),
                    FK_TicketId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_audit log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_audit log_ticket_FK_TicketId",
                        column: x => x.FK_TicketId,
                        principalTable: "ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_audit log_user_FK_UserId",
                        column: x => x.FK_UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_audit log_FK_TicketId",
                table: "audit log",
                column: "FK_TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_audit log_FK_UserId",
                table: "audit log",
                column: "FK_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_FK_UserId",
                table: "ticket",
                column: "FK_UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "audit log");

            migrationBuilder.DropTable(
                name: "ticket");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
