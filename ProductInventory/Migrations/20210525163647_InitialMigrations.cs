using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductInventory.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    productId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    fit = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    model = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    color = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.productId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
