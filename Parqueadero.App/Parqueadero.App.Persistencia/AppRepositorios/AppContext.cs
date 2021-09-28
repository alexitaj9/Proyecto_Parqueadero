using Microsoft.EntityFrameworkCore;
using Parqueadero.App.Dominio;
using System.Collections.Generic;

namespace Parqueadero.App.Persistencia
{
    public class AppContext : DbContext
    {
        //Propiedades
        //public DbSet<DatosPersona> datosPersonas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<EspacioParqueadero> EspacioParqueaderos { get; set; }
        public DbSet<Propietario> Propietarios { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<RolEmpleado> RolEmpleados { get; set; }
        public DbSet<TipoVehiculo> TipoVehiculos { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;user=root;password=;database=ParqueaderoBD;");
            }
        }
        /*
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DatosPersona>()
                .HasIndex(u => u.id)
                .IsUnique();
        }*/
    }
}