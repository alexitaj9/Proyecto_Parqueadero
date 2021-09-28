using System.Collections.Generic;
using Parqueadero.App.Dominio;

namespace Parqueadero.App.Persistencia{

    public interface IRepositorioRolEmpleado{
        IEnumerable<RolEmpleado> getAllRolEmpleado();
        RolEmpleado addRolEmpleado(RolEmpleado rolEmplado);
        RolEmpleado editRolEmpleado(RolEmpleado rolEmplado);
        RolEmpleado getRolEmpleado(int Id);
        void removeRolEmpleado(int Id);
    }
}