using System;

namespace Parqueadero.App.Dominio
{
    public class Vehiculo
    {
        //Asociacion de clase Propietario
        public Propietario propietario { get; set; }
        //Asociacion de clase TipoVehiculo
        public TipoVehiculo tipoVehiculo { get; set; }
        //Propiedades de la clase
        public int id { get; set; }
        public String placa { get; set; }
        public String marca { get; set; }
        public String modelo { get; set; }
        public String color { get; set; }
        public String observaciones { get; set; }
    }
}