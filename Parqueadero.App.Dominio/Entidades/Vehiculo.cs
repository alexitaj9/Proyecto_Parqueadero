using System;

namespace Parqueadero.App.Dominio
{
    public class Vehiculo
    {
        //Asociacion de clase Propietario
        public Propietario Propietario { get; set; }
        //Asociacion de clase TipoVehiculo
        public TipoVehiculo TipoVehiculo { get; set; }
        //Propiedades de la clase
        public int Id { get; set; }
        public String Placa { get; set; }
        public String Marca { get; set; }
        public String Modelo { get; set; }
        public String Color { get; set; }
        public String Observaciones { get; set; }

    }
}