using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Parqueadero.App.Persistencia.Migrations
{
    public partial class Entidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EspaciosParqueaderos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(type: "text", nullable: true),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspaciosParqueaderos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolEmpelados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolEmpelados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposVehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposVehiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DatosPersonas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Identificacion = table.Column<string>(type: "varchar(767)", nullable: true),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Apellidos = table.Column<string>(type: "text", nullable: true),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    Correo = table.Column<string>(type: "text", nullable: true),
                    Clave = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    RolEmpleadoId = table.Column<int>(type: "int", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime", nullable: true),
                    Direccion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosPersonas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatosPersonas_RolEmpelados_RolEmpleadoId",
                        column: x => x.RolEmpleadoId,
                        principalTable: "RolEmpelados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PropietarioId = table.Column<int>(type: "int", nullable: true),
                    TipoVehiculoId = table.Column<int>(type: "int", nullable: true),
                    Placa = table.Column<string>(type: "text", nullable: true),
                    Marca = table.Column<string>(type: "text", nullable: true),
                    Modelo = table.Column<string>(type: "text", nullable: true),
                    Color = table.Column<string>(type: "text", nullable: true),
                    Observaciones = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehiculos_DatosPersonas_PropietarioId",
                        column: x => x.PropietarioId,
                        principalTable: "DatosPersonas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehiculos_TiposVehiculos_TipoVehiculoId",
                        column: x => x.TipoVehiculoId,
                        principalTable: "TiposVehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PropietarioId = table.Column<int>(type: "int", nullable: true),
                    EspacioParqueaderoId = table.Column<int>(type: "int", nullable: true),
                    VehiculoId = table.Column<int>(type: "int", nullable: true),
                    FechaReserva = table.Column<DateTime>(type: "datetime", nullable: false),
                    InicioReserva = table.Column<DateTime>(type: "datetime", nullable: false),
                    FinReserva = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_DatosPersonas_PropietarioId",
                        column: x => x.PropietarioId,
                        principalTable: "DatosPersonas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_EspaciosParqueaderos_EspacioParqueaderoId",
                        column: x => x.EspacioParqueaderoId,
                        principalTable: "EspaciosParqueaderos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DatosPersonas_Identificacion",
                table: "DatosPersonas",
                column: "Identificacion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DatosPersonas_RolEmpleadoId",
                table: "DatosPersonas",
                column: "RolEmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_EspacioParqueaderoId",
                table: "Reservas",
                column: "EspacioParqueaderoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_PropietarioId",
                table: "Reservas",
                column: "PropietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_VehiculoId",
                table: "Reservas",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_PropietarioId",
                table: "Vehiculos",
                column: "PropietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_TipoVehiculoId",
                table: "Vehiculos",
                column: "TipoVehiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "EspaciosParqueaderos");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "DatosPersonas");

            migrationBuilder.DropTable(
                name: "TiposVehiculos");

            migrationBuilder.DropTable(
                name: "RolEmpelados");
        }
    }
}
