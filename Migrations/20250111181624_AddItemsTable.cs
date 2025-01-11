using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASPproj.Migrations
{
    /// <inheritdoc />
    public partial class AddItemsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cart_Customer_CustomerId",
                table: "cart");

            migrationBuilder.DropForeignKey(
                name: "FK_cart_item_cart_Cart_Id",
                table: "cart_item");

            migrationBuilder.DropForeignKey(
                name: "FK_cart_item_item_Item_Id",
                table: "cart_item");

            migrationBuilder.DropForeignKey(
                name: "FK_order_Customer_CustomerId",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_order_item_item_Item_Id",
                table: "order_item");

            migrationBuilder.DropForeignKey(
                name: "FK_order_item_order_Order_Id",
                table: "order_item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order_item",
                table: "order_item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order",
                table: "order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_item",
                table: "item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cart_item",
                table: "cart_item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cart",
                table: "cart");

            migrationBuilder.RenameTable(
                name: "order_item",
                newName: "Order_Items");

            migrationBuilder.RenameTable(
                name: "order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "item",
                newName: "Items");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "cart_item",
                newName: "Cart_Items");

            migrationBuilder.RenameTable(
                name: "cart",
                newName: "Carts");

            migrationBuilder.RenameIndex(
                name: "IX_order_item_Order_Id",
                table: "Order_Items",
                newName: "IX_Order_Items_Order_Id");

            migrationBuilder.RenameIndex(
                name: "IX_order_item_Item_Id",
                table: "Order_Items",
                newName: "IX_Order_Items_Item_Id");

            migrationBuilder.RenameIndex(
                name: "IX_order_CustomerId",
                table: "Orders",
                newName: "IX_Orders_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_Email",
                table: "Customers",
                newName: "IX_Customers_Email");

            migrationBuilder.RenameIndex(
                name: "IX_cart_item_Item_Id",
                table: "Cart_Items",
                newName: "IX_Cart_Items_Item_Id");

            migrationBuilder.RenameIndex(
                name: "IX_cart_item_Cart_Id",
                table: "Cart_Items",
                newName: "IX_Cart_Items_Cart_Id");

            migrationBuilder.RenameIndex(
                name: "IX_cart_CustomerId",
                table: "Carts",
                newName: "IX_Carts_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order_Items",
                table: "Order_Items",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart_Items",
                table: "Cart_Items",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Name", "Price", "stock_quantity" },
                values: new object[,]
                {
                    { "1", "Laptop", 1200, 50 },
                    { "2", "Smartphone", 800, 150 },
                    { "3", "Headphones", 150, 200 },
                    { "4", "Monitor", 300, 80 },
                    { "5", "Keyboard", 70, 120 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Items_Carts_Cart_Id",
                table: "Cart_Items",
                column: "Cart_Id",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Items_Items_Item_Id",
                table: "Cart_Items",
                column: "Item_Id",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Customers_CustomerId",
                table: "Carts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Items_Items_Item_Id",
                table: "Order_Items",
                column: "Item_Id",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Items_Orders_Order_Id",
                table: "Order_Items",
                column: "Order_Id",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Items_Carts_Cart_Id",
                table: "Cart_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Items_Items_Item_Id",
                table: "Cart_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Customers_CustomerId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Items_Items_Item_Id",
                table: "Order_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Items_Orders_Order_Id",
                table: "Order_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order_Items",
                table: "Order_Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart_Items",
                table: "Cart_Items");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "order");

            migrationBuilder.RenameTable(
                name: "Order_Items",
                newName: "order_item");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "item");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "cart");

            migrationBuilder.RenameTable(
                name: "Cart_Items",
                newName: "cart_item");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerId",
                table: "order",
                newName: "IX_order_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_Items_Order_Id",
                table: "order_item",
                newName: "IX_order_item_Order_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Order_Items_Item_Id",
                table: "order_item",
                newName: "IX_order_item_Item_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_Email",
                table: "Customer",
                newName: "IX_Customer_Email");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_CustomerId",
                table: "cart",
                newName: "IX_cart_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_Items_Item_Id",
                table: "cart_item",
                newName: "IX_cart_item_Item_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_Items_Cart_Id",
                table: "cart_item",
                newName: "IX_cart_item_Cart_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order",
                table: "order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order_item",
                table: "order_item",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_item",
                table: "item",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cart",
                table: "cart",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cart_item",
                table: "cart_item",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_cart_Customer_CustomerId",
                table: "cart",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cart_item_cart_Cart_Id",
                table: "cart_item",
                column: "Cart_Id",
                principalTable: "cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cart_item_item_Item_Id",
                table: "cart_item",
                column: "Item_Id",
                principalTable: "item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_Customer_CustomerId",
                table: "order",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_item_item_Item_Id",
                table: "order_item",
                column: "Item_Id",
                principalTable: "item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_item_order_Order_Id",
                table: "order_item",
                column: "Order_Id",
                principalTable: "order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
