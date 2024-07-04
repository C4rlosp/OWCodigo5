using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OWCodigo5.Migrations
{
    /// <inheritdoc />
    public partial class Fixedsientos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Asiento",
                table: "Asientos",
                newName: "TipoDeAsiento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoDeAsiento",
                table: "Asientos",
                newName: "Asiento");
        }
    }
}
