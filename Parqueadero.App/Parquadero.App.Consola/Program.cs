using System;
using Parqueadero.App.Persistencia;
using Parqueadero.App.Dominio;

namespace Parqueadero.App.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Empleado empleado1 = new Empleado() {
                id = 1,
                nombre = "Juan",
                apellidos = "Vargas Morales"
            };

            Console.WriteLine("Empleado " + empleado1.id + ": " + empleado1.nombre + " " + empleado1.apellidos);
        }
    }
}
