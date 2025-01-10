using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_Project_2.Migrations
{
    /// <inheritdoc />
    public partial class f3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cart_item",
                columns: table => new
                {
                    Car_Item_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Cart_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Item_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart_item", x => x.Car_Item_Id);
                    table.ForeignKey(
                        name: "FK_Cart_item_Cart_Cart_Id",
                        column: x => x.Cart_Id,
                        principalTable: "Cart",
                        principalColumn: "Cart_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cart_item_Item_Item_Id",
                        column: x => x.Item_Id,
                        principalTable: "Item",
                        principalColumn: "Item_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_item_Cart_Id",
                table: "Cart_item",
                column: "Cart_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_item_Item_Id",
                table: "Cart_item",
                column: "Item_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart_item");
        }
    }
}
