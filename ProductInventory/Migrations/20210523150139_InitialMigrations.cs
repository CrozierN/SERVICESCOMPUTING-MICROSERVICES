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
                    productId = table.Column<string>(type: "TEXT", nullable: false),
                    fit = table.Column<string>(type: "TEXT", nullable: true),
                    model = table.Column<string>(type: "TEXT", nullable: true),
                    color = table.Column<int>(type: "INTEGER", nullable: false),
                    quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    orderNumber = table.Column<string>(type: "TEXT", nullable: true)
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
