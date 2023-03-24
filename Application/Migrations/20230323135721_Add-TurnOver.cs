using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class AddTurnOver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "turnOvers",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    point = table.Column<int>(type: "int", nullable: false),
                    transactionTypeid = table.Column<int>(type: "int", nullable: false),
                    eventTypeid = table.Column<int>(type: "int", nullable: false),
                    stateid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_turnOvers", x => x.id);
                    table.ForeignKey(
                        name: "FK_turnOvers_eventType_eventTypeid",
                        column: x => x.eventTypeid,
                        principalTable: "eventType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_turnOvers_pointState_stateid",
                        column: x => x.stateid,
                        principalTable: "pointState",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_turnOvers_transactionType_transactionTypeid",
                        column: x => x.transactionTypeid,
                        principalTable: "transactionType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_turnOvers_eventTypeid",
                table: "turnOvers",
                column: "eventTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_turnOvers_stateid",
                table: "turnOvers",
                column: "stateid");

            migrationBuilder.CreateIndex(
                name: "IX_turnOvers_transactionTypeid",
                table: "turnOvers",
                column: "transactionTypeid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "turnOvers");
        }
    }
}
