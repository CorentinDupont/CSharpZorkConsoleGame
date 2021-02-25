using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_CS_ZORK.DATA_ACCESS_LAYER.Migrations
{
    public partial class RemoveCurrentCellPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Players__Current__1699586C",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "CurrentCellId",
                table: "Players",
                newName: "CellId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_CurrentCellId",
                table: "Players",
                newName: "IX_Players_CellId");

            migrationBuilder.AddColumn<bool>(
                name: "PlayerPresence",
                table: "Cells",
                type: "bit",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Cells_CellId",
                table: "Players",
                column: "CellId",
                principalTable: "Cells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Cells_CellId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerPresence",
                table: "Cells");

            migrationBuilder.RenameColumn(
                name: "CellId",
                table: "Players",
                newName: "CurrentCellId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_CellId",
                table: "Players",
                newName: "IX_Players_CurrentCellId");

            migrationBuilder.AddForeignKey(
                name: "FK__Players__Current__1699586C",
                table: "Players",
                column: "CurrentCellId",
                principalTable: "Cells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
