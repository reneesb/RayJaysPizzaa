using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RayJaysPizza.Migrations
{
    public partial class updatedusers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UID",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UID",
                table: "Employees");
        }
    }
}
