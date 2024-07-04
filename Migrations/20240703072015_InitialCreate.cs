using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OWCodigo5.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asientos",
                columns: table => new
                {
                    IdAsiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDeAsiento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumeroAsiento = table.Column<int>(type: "int", nullable: false),
                    Fila = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    AsientoIdAsiento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asientos", x => x.IdAsiento);
                    table.ForeignKey(
                        name: "FK_Asientos_Asientos_AsientoIdAsiento",
                        column: x => x.AsientoIdAsiento,
                        principalTable: "Asientos",
                        principalColumn: "IdAsiento");
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    IdGenero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.IdGenero);
                });

            migrationBuilder.CreateTable(
                name: "Teatros",
                columns: table => new
                {
                    IdTeatro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Localidad = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teatros", x => x.IdTeatro);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Cedula = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Obras",
                columns: table => new
                {
                    IdObra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IdGenero = table.Column<int>(type: "int", nullable: false),
                    FechaPresentacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obras", x => x.IdObra);
                    table.ForeignKey(
                        name: "FK_Obras_Generos_IdGenero",
                        column: x => x.IdGenero,
                        principalTable: "Generos",
                        principalColumn: "IdGenero",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Actores",
                columns: table => new
                {
                    IdActor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Personaje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RolEspecifico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdObra = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actores", x => x.IdActor);
                    table.ForeignKey(
                        name: "FK_Actores_Obras_IdObra",
                        column: x => x.IdObra,
                        principalTable: "Obras",
                        principalColumn: "IdObra",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Directores",
                columns: table => new
                {
                    IdDirector = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ObraId = table.Column<int>(type: "int", nullable: false),
                    IdObra = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directores", x => x.IdDirector);
                    table.ForeignKey(
                        name: "FK_Directores_Obras_IdObra",
                        column: x => x.IdObra,
                        principalTable: "Obras",
                        principalColumn: "IdObra",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObrasTeatros",
                columns: table => new
                {
                    IdObraTeatro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdObra = table.Column<int>(type: "int", nullable: false),
                    IdTeatro = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObrasTeatros", x => x.IdObraTeatro);
                    table.ForeignKey(
                        name: "FK_ObrasTeatros_Obras_IdObra",
                        column: x => x.IdObra,
                        principalTable: "Obras",
                        principalColumn: "IdObra",
                        onDelete: ReferentialAction.Cascade);

                    table.ForeignKey(
                        name: "FK_ObrasTeatros_Teatros_IdTeatro",
                        column: x => x.IdTeatro,
                        principalTable: "Teatros",
                        principalColumn: "IdTeatro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carritos",
                columns: table => new
                {
                    IdCarrito = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdObra = table.Column<int>(nullable: false),
                    IdTeatro = table.Column<int>(nullable: false),
                    IdAsiento = table.Column<int>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    NumeroAsiento = table.Column<int>(nullable: false),
                    Fila = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    IdObraTeatro = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carritos", x => x.IdCarrito);
                    table.ForeignKey(
                        name: "FK_Carritos_Asientos_IdAsiento",
                        column: x => x.IdAsiento,
                        principalTable: "Asientos",
                        principalColumn: "IdAsiento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carritos_ObrasTeatros_IdObraTeatro",
                        column: x => x.IdObraTeatro,
                        principalTable: "ObrasTeatros",
                        principalColumn: "IdObraTeatro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carritos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actores_IdObra",
                table: "Actores",
                column: "IdObra");

            migrationBuilder.CreateIndex(
                name: "IX_Asientos_AsientoIdAsiento",
                table: "Asientos",
                column: "AsientoIdAsiento");

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_IdAsiento",
                table: "Carritos",
                column: "IdAsiento");

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_IdObraTeatro",
                table: "Carritos",
                column: "IdObraTeatro");

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_IdUsuario",
                table: "Carritos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Directores_IdObra",
                table: "Directores",
                column: "IdObra");

            migrationBuilder.CreateIndex(
                name: "IX_Obras_IdGenero",
                table: "Obras",
                column: "IdGenero");

            migrationBuilder.CreateIndex(
                name: "IX_ObrasTeatros_IdObra",
                table: "ObrasTeatros",
                column: "IdObra");

            migrationBuilder.CreateIndex(
                name: "IX_ObrasTeatros_ObraIdObra",
                table: "ObrasTeatros",
                column: "ObraIdObra");

            migrationBuilder.CreateIndex(
                name: "IX_ObrasTeatros_IdTeatro",
                table: "ObrasTeatros",
                column: "IdTeatro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actores");

            migrationBuilder.DropTable(
                name: "Carritos");

            migrationBuilder.DropTable(
                name: "Directores");

            migrationBuilder.DropTable(
                name: "Asientos");

            migrationBuilder.DropTable(
                name: "ObrasTeatros");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Obras");

            migrationBuilder.DropTable(
                name: "Teatros");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}

