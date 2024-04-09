using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharedProject.Migrations
{
    /// <inheritdoc />
    public partial class AddProductLongDesc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductLongDescription_ProductId",
                table: "ProductLongDescription");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLongDescription_ProductId",
                table: "ProductLongDescription",
                column: "ProductId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductLongDescription_ProductId",
                table: "ProductLongDescription");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLongDescription_ProductId",
                table: "ProductLongDescription",
                column: "ProductId");
        }
    }
}
