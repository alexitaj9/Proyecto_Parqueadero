namespace Parqueadero.App.Dominio
{
    public class Empleado:DatosPersona
    {
        //Asociacion con la clase RolEmpleado
        public RolEmpleado rolEmpleado { get; set; }
    }
}