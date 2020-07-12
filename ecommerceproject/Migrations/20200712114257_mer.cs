using Microsoft.EntityFrameworkCore.Migrations;

namespace ecommerceproject.Migrations
{
    public partial class mer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Authors",
                table: "Malzeme");

            migrationBuilder.DropColumn(
                name: "PageCount",
                table: "Malzeme");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Authors",
                table: "Malzeme",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PageCount",
                table: "Malzeme",
                type: "int",
                nullable: true);
        }
    }
}
