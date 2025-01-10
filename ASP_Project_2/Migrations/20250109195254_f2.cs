using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_Project_2.Migrations
{
    /// <inheritdoc />
    public partial class f2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order_item",
                columns: table => new
                {
                    Order_Item_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Order_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Item_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_item", x => x.Order_Item_Id);
                    table.ForeignKey(
                        name: "FK_Order_item_Item_Item_Id",
                        column: x => x.Item_Id,
                        principalTable: "Item",
                        principalColumn: "Item_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_item_Order_Order_Id",
                        column: x => x.Order_Id,
                        principalTable: "Order",
                        principalColumn: "Order_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_item_Item_Id",
                table: "Order_item",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_item_Order_Id",
                table: "Order_item",
                column: "Order_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_item");
        }
    }
}
