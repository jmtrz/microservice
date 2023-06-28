using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessApi.Migrations
{
    /// <inheritdoc />
    public partial class CorrectedTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsContext",
                table: "ProductsContext");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersContext",
                table: "OrdersContext");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItemsContext",
                table: "OrderItemsContext");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryContext",
                table: "InventoryContext");

            migrationBuilder.RenameTable(
                name: "ProductsContext",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "OrdersContext",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "OrderItemsContext",
                newName: "OrderItems");

            migrationBuilder.RenameTable(
                name: "InventoryContext",
                newName: "Inventory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventory",
                table: "Inventory",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventory",
                table: "Inventory");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "ProductsContext");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "OrdersContext");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "OrderItemsContext");

            migrationBuilder.RenameTable(
                name: "Inventory",
                newName: "InventoryContext");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsContext",
                table: "ProductsContext",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersContext",
                table: "OrdersContext",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItemsContext",
                table: "OrderItemsContext",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryContext",
                table: "InventoryContext",
                column: "Id");
        }
    }
}
