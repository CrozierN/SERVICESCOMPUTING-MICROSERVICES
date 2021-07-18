using Microsoft.EntityFrameworkCore.Migrations;

namespace MaterialInventory.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    part_name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    part_model = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    fit = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Material");
        }
    }
}
