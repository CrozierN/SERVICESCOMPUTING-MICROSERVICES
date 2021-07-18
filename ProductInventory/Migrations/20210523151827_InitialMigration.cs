using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductInventory.Migrations
{
    public partial class InitialMigration : Migration
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
                    color = table.Column<string>(type: "TEXT", nullable: true),
                    quantity = table.Column<int>(type: "INTEGER", nullable: false)
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
