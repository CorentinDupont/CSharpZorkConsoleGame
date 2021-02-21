using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_CS_ZORK.DATA_ACCESS_LAYER.Migrations
{
    public partial class FixUserCell : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Objects__Id__45BE5BA9",
                table: "Objects");

            migrationBuilder.DropForeignKey(
                name: "FK__Players__Current__41EDCAC5",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK__Players__Objects__43D61337",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK__Players__Weapons__42E1EEFE",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK__WeaponsType__Id__44CA3770",
                table: "WeaponsType");

            migrationBuilder.DropIndex(
                name: "IX_Players_ObjectsId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_WeaponsId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ObjectsId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "WeaponsId",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "Dammage",
                table: "WeaponsType",
                newName: "Damage");

            migrationBuilder.RenameColumn(
                name: "Dammage",
                table: "ObjectsType",
                newName: "Damage");

            migrationBuilder.RenameColumn(
                name: "Dammage",
                table: "Monsters",
                newName: "Damage");

            migrationBuilder.AddColumn<int>(
                name: "WeaponTypeId",
                table: "Weapons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ObjectTypeId",
                table: "Objects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Cells",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_PlayerId",
                table: "Weapons",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_WeaponTypeId",
                table: "Weapons",
                column: "WeaponTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Objects_ObjectTypeId",
                table: "Objects",
                column: "ObjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Objects_PlayerId",
                table: "Objects",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cells_PlayerId",
                table: "Cells",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK__Cells__PlayerId__373B3228",
                table: "Cells",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Objects__ObjectT__3A179ED3",
                table: "Objects",
                column: "ObjectTypeId",
                principalTable: "ObjectsType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Objects__PlayerI__3B0BC30C",
                table: "Objects",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Players__Current__36470DEF",
                table: "Players",
                column: "CurrentCellId",
                principalTable: "Cells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Weapons__PlayerI__39237A9A",
                table: "Weapons",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Weapons__WeaponT__382F5661",
                table: "Weapons",
                column: "WeaponTypeId",
                principalTable: "WeaponsType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Cells__PlayerId__373B3228",
                table: "Cells");

            migrationBuilder.DropForeignKey(
                name: "FK__Objects__ObjectT__3A179ED3",
                table: "Objects");

            migrationBuilder.DropForeignKey(
                name: "FK__Objects__PlayerI__3B0BC30C",
                table: "Objects");

            migrationBuilder.DropForeignKey(
                name: "FK__Players__Current__36470DEF",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK__Weapons__PlayerI__39237A9A",
                table: "Weapons");

            migrationBuilder.DropForeignKey(
                name: "FK__Weapons__WeaponT__382F5661",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_PlayerId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_WeaponTypeId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Objects_ObjectTypeId",
                table: "Objects");

            migrationBuilder.DropIndex(
                name: "IX_Objects_PlayerId",
                table: "Objects");

            migrationBuilder.DropIndex(
                name: "IX_Cells_PlayerId",
                table: "Cells");

            migrationBuilder.DropColumn(
                name: "WeaponTypeId",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "ObjectTypeId",
                table: "Objects");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Cells");

            migrationBuilder.RenameColumn(
                name: "Damage",
                table: "WeaponsType",
                newName: "Dammage");

            migrationBuilder.RenameColumn(
                name: "Damage",
                table: "ObjectsType",
                newName: "Dammage");

            migrationBuilder.RenameColumn(
                name: "Damage",
                table: "Monsters",
                newName: "Dammage");

            migrationBuilder.AddColumn<int>(
                name: "ObjectsId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WeaponsId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Players_ObjectsId",
                table: "Players",
                column: "ObjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_WeaponsId",
                table: "Players",
                column: "WeaponsId");

            migrationBuilder.AddForeignKey(
                name: "FK__Objects__Id__45BE5BA9",
                table: "Objects",
                column: "Id",
                principalTable: "ObjectsType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Players__Current__41EDCAC5",
                table: "Players",
                column: "CurrentCellId",
                principalTable: "Cells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Players__Objects__43D61337",
                table: "Players",
                column: "ObjectsId",
                principalTable: "Objects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Players__Weapons__42E1EEFE",
                table: "Players",
                column: "WeaponsId",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__WeaponsType__Id__44CA3770",
                table: "WeaponsType",
                column: "Id",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
