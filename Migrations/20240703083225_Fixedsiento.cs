using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OWCodigo5.Migrations
{
    /// <inheritdoc />
    public partial class Fixedsiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tipo de asiento",
                table: "Asientos",
                newName: "Asiento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Asiento",
                table: "Asientos",
                newName: "Tipo de asiento");
        }
    }
}
