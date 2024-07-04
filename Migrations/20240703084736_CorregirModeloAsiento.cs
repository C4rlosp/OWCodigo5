using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OWCodigo5.Migrations
{
    /// <inheritdoc />
    public partial class CorregirModeloAsiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asientos_Asientos_AsientoIdAsiento",
                table: "Asientos");

            migrationBuilder.DropIndex(
                name: "IX_Asientos_AsientoIdAsiento",
                table: "Asientos");

            migrationBuilder.DropColumn(
                name: "AsientoIdAsiento",
                table: "Asientos");

            migrationBuilder.RenameColumn(
                name: "TipoDeAsiento",
                table: "Asientos",
                newName: "TipoDeAsiento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoDeAsiento",
                table: "Asientos",
                newName: "TipoDeAsiento");

            migrationBuilder.AddColumn<int>(
                name: "AsientoIdAsiento",
                table: "Asientos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Asientos_AsientoIdAsiento",
                table: "Asientos",
                column: "AsientoIdAsiento");

            migrationBuilder.AddForeignKey(
                name: "FK_Asientos_Asientos_AsientoIdAsiento",
                table: "Asientos",
                column: "AsientoIdAsiento",
                principalTable: "Asientos",
                principalColumn: "IdAsiento");
        }
    }
}
