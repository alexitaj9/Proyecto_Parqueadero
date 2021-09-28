using System.Collections.Generic;
using Parqueadero.App.Dominio;

namespace Parqueadero.App.Persistencia{

    public interface IRepositorioEmpleado{
        IEnumerable<Empleado> getAllEmpleado();
        Empleado addEmpleado(Empleado empleado);
        Empleado editEmpleado(Empleado emplaado);
        Empleado getEmpleado(int Id);
        void removeEmpleado(int Id);
    }
}