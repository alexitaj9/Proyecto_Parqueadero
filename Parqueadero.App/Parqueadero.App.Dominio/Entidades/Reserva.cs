using System;

namespace Parqueadero.App.Dominio
{
    public class Reserva
    {
        //Asociacion con la clase Propietario
        public Propietario propietario { get; set; }
        //Asociacion con la clase EspacioParqueadero
        public EspacioParqueadero espacioParqueadero { get; set; }
        //Asociacion con la clase Vehiculo
        public Vehiculo vehiculo { get; set; }
        //Propiedades de la clase
        public int id { get; set;}
        public DateTime fechaReserva { get; set; }
        public DateTime inicioReserva { get; set; }
        public DateTime finReserva { get; set; }
    }
}