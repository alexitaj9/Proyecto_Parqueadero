using System;

namespace Parqueadero.App.Dominio
{
    public class Propietario:DatosPersona
    {
        //Propiedades de la clase
        public DateTime fechaNacimiento { get; set;}
        public string direccion {get; set;}
    }
}