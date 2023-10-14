using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RayJaysPizza.Migrations
{
    public partial class changedids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Status",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ratings",
                newName: "RatingId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PaymentTypes",
                newName: "PaymentTypeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Orders",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Items",
                newName: "ItemId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employees",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customers",
                newName: "CustomerId");

            migrationBuilder.AddColumn<int>(
                name: "OrdersOrderId",
                table: "Items",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_OrdersOrderId",
                table: "Items",
                column: "OrdersOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Orders_OrdersOrderId",
                table: "Items",
                column: "OrdersOrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Orders_OrdersOrderId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_OrdersOrderId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "OrdersOrderId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Status",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RatingId",
                table: "Ratings",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PaymentTypeId",
                table: "PaymentTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Items",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Employees",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Customers",
                newName: "Id");
        }
    }
}
