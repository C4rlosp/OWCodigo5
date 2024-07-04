using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OWCodigo5.Migrations
{
    /// <inheritdoc />
    public partial class IdObra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagenUrl",
                table: "Obras");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagenUrl",
                table: "Obras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
