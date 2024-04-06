using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharedProject.Migrations
{
    /// <inheritdoc />
    public partial class AddDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Models_ModelId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "LongDescriptionImages");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "LongDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Products_ModelId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProductLongDescriptionId",
                table: "ProductImages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductLongDescription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProdcutId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLongDescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductLongDescription_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductLongDescriptionId",
                table: "ProductImages",
                column: "ProductLongDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLongDescription_ProductId",
                table: "ProductLongDescription",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_ProductLongDescription_ProductLongDescriptionId",
                table: "ProductImages",
                column: "ProductLongDescriptionId",
                principalTable: "ProductLongDescription",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_ProductLongDescription_ProductLongDescriptionId",
                table: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductLongDescription");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ProductLongDescriptionId",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductLongDescriptionId",
                table: "ProductImages");

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LongDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LongDescriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LongDescriptionImages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LongDescriptionId = table.Column<int>(type: "int", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LongDescriptionImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LongDescriptionImages_LongDescriptions_LongDescriptionId",
                        column: x => x.LongDescriptionId,
                        principalTable: "LongDescriptions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ModelId",
                table: "Products",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_LongDescriptionImages_LongDescriptionId",
                table: "LongDescriptionImages",
                column: "LongDescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Models_ModelId",
                table: "Products",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
