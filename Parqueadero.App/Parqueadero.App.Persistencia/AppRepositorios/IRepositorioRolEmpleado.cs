using System.Collections.Generic;
using Parqueadero.App.Dominio;

namespace Parqueadero.App.Persistencia{

    public interface IRepositorioRolEmpleado{
        IEnumerable<RolEmpleado> getAllRolEmpleado();
        RolEmpleado getRolEmpleado(int Id);
    }
}