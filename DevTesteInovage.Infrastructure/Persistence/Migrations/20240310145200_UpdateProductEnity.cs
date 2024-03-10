using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevTesteInovage.Infrastructure.Persistence.Migrations
{
    public partial class UpdateProductEnity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Products");
        }
    }
}
