﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Parqueadero.App.Persistencia;

namespace Parqueadero.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Parqueadero.App.Dominio.Empleado", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("apellidos")
                        .HasColumnType("text");

                    b.Property<string>("clave")
                        .HasColumnType("text");

                    b.Property<string>("correo")
                        .HasColumnType("text");

                    b.Property<string>("identificacion")
                        .HasColumnType("text");

                    b.Property<string>("nombre")
                        .HasColumnType("text");

                    b.Property<int?>("rolEmpleadoid")
                        .HasColumnType("int");

                    b.Property<string>("telefono")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("rolEmpleadoid");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("Parqueadero.App.Dominio.EspacioParqueadero", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("tipo")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("EspaciosParqueadero");
                });

            modelBuilder.Entity("Parqueadero.App.Dominio.Propietario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("apellidos")
                        .HasColumnType("text");

                    b.Property<string>("clave")
                        .HasColumnType("text");

                    b.Property<string>("correo")
                        .HasColumnType("text");

                    b.Property<string>("direccion")
                        .HasColumnType("text");

                    b.Property<DateTime>("fechaNacimiento")
                        .HasColumnType("datetime");

                    b.Property<string>("identificacion")
                        .HasColumnType("text");

                    b.Property<string>("nombre")
                        .HasColumnType("text");

                    b.Property<string>("telefono")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Propietarios");
                });

            modelBuilder.Entity("Parqueadero.App.Dominio.Reserva", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("espacioParqueaderoid")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaReserva")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("finReserva")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("inicioReserva")
                        .HasColumnType("datetime");

                    b.Property<int?>("propietarioid")
                        .HasColumnType("int");

                    b.Property<int?>("vehiculoid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("espacioParqueaderoid");

                    b.HasIndex("propietarioid");

                    b.HasIndex("vehiculoid");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("Parqueadero.App.Dominio.RolEmpleado", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("RolEmpleados");
                });

            modelBuilder.Entity("Parqueadero.App.Dominio.TipoVehiculo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("TiposVehiculos");
                });

            modelBuilder.Entity("Parqueadero.App.Dominio.Vehiculo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("color")
                        .HasColumnType("text");

                    b.Property<string>("marca")
                        .HasColumnType("text");

                    b.Property<string>("modelo")
                        .HasColumnType("text");

                    b.Property<string>("observaciones")
                        .HasColumnType("text");

                    b.Property<string>("placa")
                        .HasColumnType("text");

                    b.Property<int?>("propietarioid")
                        .HasColumnType("int");

                    b.Property<int?>("tipoVehiculoid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("propietarioid");

                    b.HasIndex("tipoVehiculoid");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("Parqueadero.App.Dominio.Empleado", b =>
                {
                    b.HasOne("Parqueadero.App.Dominio.RolEmpleado", "rolEmpleado")
                        .WithMany()
                        .HasForeignKey("rolEmpleadoid");

                    b.Navigation("rolEmpleado");
                });

            modelBuilder.Entity("Parqueadero.App.Dominio.Reserva", b =>
                {
                    b.HasOne("Parqueadero.App.Dominio.EspacioParqueadero", "espacioParqueadero")
                        .WithMany()
                        .HasForeignKey("espacioParqueaderoid");

                    b.HasOne("Parqueadero.App.Dominio.Propietario", "propietario")
                        .WithMany()
                        .HasForeignKey("propietarioid");

                    b.HasOne("Parqueadero.App.Dominio.Vehiculo", "vehiculo")
                        .WithMany()
                        .HasForeignKey("vehiculoid");

                    b.Navigation("espacioParqueadero");

                    b.Navigation("propietario");

                    b.Navigation("vehiculo");
                });

            modelBuilder.Entity("Parqueadero.App.Dominio.Vehiculo", b =>
                {
                    b.HasOne("Parqueadero.App.Dominio.Propietario", "propietario")
                        .WithMany()
                        .HasForeignKey("propietarioid");

                    b.HasOne("Parqueadero.App.Dominio.TipoVehiculo", "tipoVehiculo")
                        .WithMany()
                        .HasForeignKey("tipoVehiculoid");

                    b.Navigation("propietario");

                    b.Navigation("tipoVehiculo");
                });
#pragma warning restore 612, 618
        }
    }
}
