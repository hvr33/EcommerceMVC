using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_COMMERCE.Migrations.Commerce2
{
    /// <inheritdoc />
    public partial class UpdateCommerce2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "order");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "order",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
