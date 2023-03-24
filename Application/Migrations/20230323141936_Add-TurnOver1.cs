using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class AddTurnOver1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_turnOvers_eventType_eventTypeid",
                table: "turnOvers");

            migrationBuilder.DropForeignKey(
                name: "FK_turnOvers_pointState_stateid",
                table: "turnOvers");

            migrationBuilder.DropForeignKey(
                name: "FK_turnOvers_transactionType_transactionTypeid",
                table: "turnOvers");

            migrationBuilder.DropIndex(
                name: "IX_turnOvers_eventTypeid",
                table: "turnOvers");

            migrationBuilder.DropIndex(
                name: "IX_turnOvers_stateid",
                table: "turnOvers");

            migrationBuilder.DropIndex(
                name: "IX_turnOvers_transactionTypeid",
                table: "turnOvers");

            migrationBuilder.RenameColumn(
                name: "transactionTypeid",
                table: "turnOvers",
                newName: "transactionType");

            migrationBuilder.RenameColumn(
                name: "stateid",
                table: "turnOvers",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "eventTypeid",
                table: "turnOvers",
                newName: "eventType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "transactionType",
                table: "turnOvers",
                newName: "transactionTypeid");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "turnOvers",
                newName: "stateid");

            migrationBuilder.RenameColumn(
                name: "eventType",
                table: "turnOvers",
                newName: "eventTypeid");

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

            migrationBuilder.AddForeignKey(
                name: "FK_turnOvers_eventType_eventTypeid",
                table: "turnOvers",
                column: "eventTypeid",
                principalTable: "eventType",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_turnOvers_pointState_stateid",
                table: "turnOvers",
                column: "stateid",
                principalTable: "pointState",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_turnOvers_transactionType_transactionTypeid",
                table: "turnOvers",
                column: "transactionTypeid",
                principalTable: "transactionType",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
