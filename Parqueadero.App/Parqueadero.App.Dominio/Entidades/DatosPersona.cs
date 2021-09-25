using System;

namespace Parqueadero.App.Dominio
{
    public class DatosPersona
    {
        //Propiedades de la clase
        public int id { get; set; }
        public string identificacion { get; set; }
        public string nombre { get; set;}
        public string apellidos { get; set; }
        public string telefono { get; set;}
        public string correo { get; set; }
        public string clave { get; set; }
    }
}