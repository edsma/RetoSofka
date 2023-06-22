using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetoSofka.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    idProduct = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nameProduct = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inInventory = table.Column<int>(type: "int", nullable: false),
                    enabled = table.Column<bool>(type: "bit", nullable: false),
                    min = table.Column<int>(type: "int", nullable: false),
                    max = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.idProduct);
                });

            migrationBuilder.CreateTable(
                name: "Shopping",
                columns: table => new
                {
                    idShopping = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idType = table.Column<int>(type: "int", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false),
                    clientName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopping", x => x.idShopping);
                });

            migrationBuilder.CreateTable(
                name: "DetailShopProduct",
                columns: table => new
                {
                    idDetatilShopProduct = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idProduct = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idShoppingRef = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailShopProduct", x => x.idDetatilShopProduct);
                    table.ForeignKey(
                        name: "FK_DetailShopProduct_Product_idProduct",
                        column: x => x.idProduct,
                        principalTable: "Product",
                        principalColumn: "idProduct",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailShopProduct_Shopping_idShoppingRef",
                        column: x => x.idShoppingRef,
                        principalTable: "Shopping",
                        principalColumn: "idShopping",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailShopProduct_idProduct",
                table: "DetailShopProduct",
                column: "idProduct");

            migrationBuilder.CreateIndex(
                name: "IX_DetailShopProduct_idShoppingRef",
                table: "DetailShopProduct",
                column: "idShoppingRef");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailShopProduct");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Shopping");
        }
    }
}
