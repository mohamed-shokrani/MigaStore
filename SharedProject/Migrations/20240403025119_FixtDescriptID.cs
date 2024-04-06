using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharedProject.Migrations
{
    /// <inheritdoc />
    public partial class FixtDescriptID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProdcutId",
                table: "ProductLongDescription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdcutId",
                table: "ProductLongDescription",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
