using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharedProject.Migrations
{
    /// <inheritdoc />
    public partial class EditLongDescImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_ProductLongDescription_ProductLongDescriptionId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ProductLongDescriptionId",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "ProductLongDescriptionId",
                table: "ProductImages");

            migrationBuilder.CreateTable(
                name: "ProductLongDescImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductLongDescriptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLongDescImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductLongDescImage_ProductLongDescription_ProductLongDescriptionId",
                        column: x => x.ProductLongDescriptionId,
                        principalTable: "ProductLongDescription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductLongDescImage_ProductLongDescriptionId",
                table: "ProductLongDescImage",
                column: "ProductLongDescriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductLongDescImage");

            migrationBuilder.AddColumn<int>(
                name: "ProductLongDescriptionId",
                table: "ProductImages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductLongDescriptionId",
                table: "ProductImages",
                column: "ProductLongDescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_ProductLongDescription_ProductLongDescriptionId",
                table: "ProductImages",
                column: "ProductLongDescriptionId",
                principalTable: "ProductLongDescription",
                principalColumn: "Id");
        }
    }
}
