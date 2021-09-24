using System;

namespace Parqueadero.App.Dominio
{
    public class DatosPersona
    {
        //Propiedades de la clase
        public int Id { get; set; }
        public String Identificacion { get; set; }
        public String Nombre { get; set;}
        public String Apellidos { get; set; }
        public String Telefono { get; set;}
        public String Correo { get; set; }
        public String Clave { get; set; }
    }
}