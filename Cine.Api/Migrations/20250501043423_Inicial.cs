using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cine.Api.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pelicula",
                columns: table => new
                {
                    id_pelicula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    duracion = table.Column<int>(type: "int", nullable: false),
                    fecha_publicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    audit_delete_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    audit_delete_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pelicula", x => x.id_pelicula);
                });

            migrationBuilder.CreateTable(
                name: "sala_cine",
                columns: table => new
                {
                    id_sala = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    audit_delete_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    audit_delete_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sala_cine", x => x.id_sala);
                });

            migrationBuilder.CreateTable(
                name: "pelicula_salacine",
                columns: table => new
                {
                    id_pelicula_sala = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    salaCineId = table.Column<int>(type: "int", nullable: false),
                    peliculaId = table.Column<int>(type: "int", nullable: false),
                    fecha_publicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_fin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pelicula_salacine", x => x.id_pelicula_sala);
                    table.ForeignKey(
                        name: "FK_pelicula_salacine_pelicula_peliculaId",
                        column: x => x.peliculaId,
                        principalTable: "pelicula",
                        principalColumn: "id_pelicula",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pelicula_salacine_sala_cine_salaCineId",
                        column: x => x.salaCineId,
                        principalTable: "sala_cine",
                        principalColumn: "id_sala",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pelicula_salacine_peliculaId",
                table: "pelicula_salacine",
                column: "peliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_pelicula_salacine_salaCineId",
                table: "pelicula_salacine",
                column: "salaCineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pelicula_salacine");

            migrationBuilder.DropTable(
                name: "pelicula");

            migrationBuilder.DropTable(
                name: "sala_cine");
        }
    }
}
