using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ecommerceproject.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Malzeme",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 512, nullable: false),
                    PageCount = table.Column<int>(nullable: true),
                    Authors = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PressYear = table.Column<int>(nullable: false),
                    StockCount = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Malzeme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Malzeme_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    MalzemeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Malzeme_MalzemeId",
                        column: x => x.MalzemeId,
                        principalTable: "Malzeme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MalzemeImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MalzemeId = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    IsDefaultImage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MalzemeImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MalzemeImage_Malzeme_MalzemeId",
                        column: x => x.MalzemeId,
                        principalTable: "Malzeme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_MalzemeId",
                table: "Comment",
                column: "MalzemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Malzeme_CategoryId",
                table: "Malzeme",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MalzemeImage_MalzemeId",
                table: "MalzemeImage",
                column: "MalzemeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "MalzemeImage");

            migrationBuilder.DropTable(
                name: "Malzeme");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
