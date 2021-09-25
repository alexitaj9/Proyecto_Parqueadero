using System;

namespace Parqueadero.App.Dominio
{
    public class Propietario:DatosPersona
    {
        //Propiedades de la clase
        public DateTime FechaNacimiento {get;set;}
        public String Direccion {get;set;}
    }
}