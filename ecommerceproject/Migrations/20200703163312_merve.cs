using Microsoft.EntityFrameworkCore.Migrations;

namespace ecommerceproject.Migrations
{
    public partial class merve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MalzemeImage_Malzeme_MalzemeId",
                table: "MalzemeImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MalzemeImage",
                table: "MalzemeImage");

            migrationBuilder.DropColumn(
                name: "PressYear",
                table: "Malzeme");

            migrationBuilder.RenameTable(
                name: "MalzemeImage",
                newName: "MalzemeImages");

            migrationBuilder.RenameIndex(
                name: "IX_MalzemeImage_MalzemeId",
                table: "MalzemeImages",
                newName: "IX_MalzemeImages_MalzemeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MalzemeImages",
                table: "MalzemeImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MalzemeImages_Malzeme_MalzemeId",
                table: "MalzemeImages",
                column: "MalzemeId",
                principalTable: "Malzeme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MalzemeImages_Malzeme_MalzemeId",
                table: "MalzemeImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MalzemeImages",
                table: "MalzemeImages");

            migrationBuilder.RenameTable(
                name: "MalzemeImages",
                newName: "MalzemeImage");

            migrationBuilder.RenameIndex(
                name: "IX_MalzemeImages_MalzemeId",
                table: "MalzemeImage",
                newName: "IX_MalzemeImage_MalzemeId");

            migrationBuilder.AddColumn<int>(
                name: "PressYear",
                table: "Malzeme",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MalzemeImage",
                table: "MalzemeImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MalzemeImage_Malzeme_MalzemeId",
                table: "MalzemeImage",
                column: "MalzemeId",
                principalTable: "Malzeme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
