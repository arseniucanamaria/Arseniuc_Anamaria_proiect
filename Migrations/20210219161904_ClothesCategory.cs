using Microsoft.EntityFrameworkCore.Migrations;

namespace Arseniuc_Anamaria_proiect.Migrations
{
    public partial class ClothesCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandID",
                table: "Clothes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClothesCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClothesID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothesCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClothesCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClothesCategory_Clothes_ClothesID",
                        column: x => x.ClothesID,
                        principalTable: "Clothes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_BrandID",
                table: "Clothes",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_ClothesCategory_CategoryID",
                table: "ClothesCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ClothesCategory_ClothesID",
                table: "ClothesCategory",
                column: "ClothesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_Brand_BrandID",
                table: "Clothes",
                column: "BrandID",
                principalTable: "Brand",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Brand_BrandID",
                table: "Clothes");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "ClothesCategory");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_BrandID",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "BrandID",
                table: "Clothes");
        }
    }
}
