using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ayudas",
                columns: table => new
                {
                    Numero = table.Column<string>(type: "varchar(4)", nullable: false),
                    ValorApoyo = table.Column<decimal>(type: "decimal(12,0)", nullable: false),
                    ModalidadApoyo = table.Column<string>(type: "varchar(12)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ayudas", x => x.Numero);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Identificacion = table.Column<string>(type: "varchar(13)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(25)", nullable: true),
                    Apellidos = table.Column<string>(type: "varchar(25)", nullable: true),
                    Sexo = table.Column<string>(type: "varchar(10)", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Departamento = table.Column<string>(type: "varchar(25)", nullable: true),
                    Ciudad = table.Column<string>(type: "varchar(25)", nullable: true),
                    AyudasNumero = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Identificacion);
                    table.ForeignKey(
                        name: "FK_Personas_Ayudas_AyudasNumero",
                        column: x => x.AyudasNumero,
                        principalTable: "Ayudas",
                        principalColumn: "Numero",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_AyudasNumero",
                table: "Personas",
                column: "AyudasNumero");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Ayudas");
        }
    }
}
