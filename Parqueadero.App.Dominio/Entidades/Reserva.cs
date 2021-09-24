using System;

namespace Parqueadero.App.Dominio
{
    public class Reserva
    {
        //Asociacion con la clase Propietario
        public Propietario Propietario { get; set; }
        //Asociacion con la clase EspacioParqueadero
        public EspacioParqueadero EspacioParqueadero { get; set; }
        //Asociacion con la clase Vehiculo
        public Vehiculo Vehiculo { get; set; }
        //Propiedades de la clase
        public int Id {get;set;}
        public DateTime FechaReserva {get; set; }
        public DateTime InicioReserva {get; set; }
        public DateTime FinReserva {get; set; }


    }
}