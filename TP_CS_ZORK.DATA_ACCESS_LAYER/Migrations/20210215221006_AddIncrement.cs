using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_CS_ZORK.DATA_ACCESS_LAYER.Migrations
{
    public partial class AddIncrement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "WeaponsType",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Weapons",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentCellId",
                table: "Players",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Players",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ObjectsType",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Objects",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Monsters",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Cells",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK__Cells__PlayerId__178D7CA5",
                table: "Cells",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Objects__ObjectT__1A69E950",
                table: "Objects",
                column: "ObjectTypeId",
                principalTable: "ObjectsType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Objects__PlayerI__1B5E0D89",
                table: "Objects",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Players__Current__1699586C",
                table: "Players",
                column: "CurrentCellId",
                principalTable: "Cells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Weapons__PlayerI__1975C517",
                table: "Weapons",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Weapons__WeaponT__1881A0DE",
                table: "Weapons",
                column: "WeaponTypeId",
                principalTable: "WeaponsType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Cells__PlayerId__178D7CA5",
                table: "Cells");

            migrationBuilder.DropForeignKey(
                name: "FK__Objects__ObjectT__1A69E950",
                table: "Objects");

            migrationBuilder.DropForeignKey(
                name: "FK__Objects__PlayerI__1B5E0D89",
                table: "Objects");

            migrationBuilder.DropForeignKey(
                name: "FK__Players__Current__1699586C",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK__Weapons__PlayerI__1975C517",
                table: "Weapons");

            migrationBuilder.DropForeignKey(
                name: "FK__Weapons__WeaponT__1881A0DE",
                table: "Weapons");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "WeaponsType",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Weapons",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentCellId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Players",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ObjectsType",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Objects",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Monsters",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Cells",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

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
    }
}
