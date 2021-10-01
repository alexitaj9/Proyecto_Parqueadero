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
                name: "EspacioParqueaderos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    tipo = table.Column<string>(type: "text", nullable: true),
                    estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspacioParqueaderos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RolEmpleados",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolEmpleados", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoVehiculos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVehiculos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "datosPersonas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    identificacion = table.Column<string>(type: "varchar(767)", nullable: true),
                    nombre = table.Column<string>(type: "text", nullable: true),
                    apellidos = table.Column<string>(type: "text", nullable: true),
                    telefono = table.Column<string>(type: "text", nullable: true),
                    correo = table.Column<string>(type: "text", nullable: true),
                    clave = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    rolEmpleadoid = table.Column<int>(type: "int", nullable: true),
                    fechaNacimiento = table.Column<DateTime>(type: "datetime", nullable: true),
                    direccion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datosPersonas", x => x.id);
                    table.ForeignKey(
                        name: "FK_datosPersonas_RolEmpleados_rolEmpleadoid",
                        column: x => x.rolEmpleadoid,
                        principalTable: "RolEmpleados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    propietarioid = table.Column<int>(type: "int", nullable: true),
                    tipoVehiculoid = table.Column<int>(type: "int", nullable: true),
                    placa = table.Column<string>(type: "text", nullable: true),
                    marca = table.Column<string>(type: "text", nullable: true),
                    modelo = table.Column<string>(type: "text", nullable: true),
                    color = table.Column<string>(type: "text", nullable: true),
                    observaciones = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vehiculos_datosPersonas_propietarioid",
                        column: x => x.propietarioid,
                        principalTable: "datosPersonas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehiculos_TipoVehiculos_tipoVehiculoid",
                        column: x => x.tipoVehiculoid,
                        principalTable: "TipoVehiculos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    propietarioid = table.Column<int>(type: "int", nullable: true),
                    espacioParqueaderoid = table.Column<int>(type: "int", nullable: true),
                    vehiculoid = table.Column<int>(type: "int", nullable: true),
                    fechaReserva = table.Column<DateTime>(type: "datetime", nullable: false),
                    inicioReserva = table.Column<DateTime>(type: "datetime", nullable: false),
                    finReserva = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reservas_datosPersonas_propietarioid",
                        column: x => x.propietarioid,
                        principalTable: "datosPersonas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_EspacioParqueaderos_espacioParqueaderoid",
                        column: x => x.espacioParqueaderoid,
                        principalTable: "EspacioParqueaderos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_Vehiculos_vehiculoid",
                        column: x => x.vehiculoid,
                        principalTable: "Vehiculos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_datosPersonas_identificacion",
                table: "datosPersonas",
                column: "identificacion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_datosPersonas_rolEmpleadoid",
                table: "datosPersonas",
                column: "rolEmpleadoid");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_espacioParqueaderoid",
                table: "Reservas",
                column: "espacioParqueaderoid");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_propietarioid",
                table: "Reservas",
                column: "propietarioid");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_vehiculoid",
                table: "Reservas",
                column: "vehiculoid");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_propietarioid",
                table: "Vehiculos",
                column: "propietarioid");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_tipoVehiculoid",
                table: "Vehiculos",
                column: "tipoVehiculoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "EspacioParqueaderos");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "datosPersonas");

            migrationBuilder.DropTable(
                name: "TipoVehiculos");

            migrationBuilder.DropTable(
                name: "RolEmpleados");
        }
    }
}
