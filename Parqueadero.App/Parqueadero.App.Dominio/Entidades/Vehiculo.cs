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
        public string placa { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string color { get; set; }
        public string observaciones { get; set; }
    }
}