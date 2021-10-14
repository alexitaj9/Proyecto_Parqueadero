using System.Collections.Generic;
using System.Linq;
using Parqueadero.App.Dominio;

namespace Parqueadero.App.Persistencia{
    public class RepositorioRolEmpleado : IRepositorioRolEmpleado
    {
        private readonly AppContext _contexto;

        public RepositorioRolEmpleado(AppContext contexto){
            this._contexto = contexto;
        }
        
        public IEnumerable<RolEmpleado> getAllRolEmpleado()
        {
            return _contexto. RolEmpleados;
        }

        public RolEmpleado getRolEmpleado(int Id)
        {
            return _contexto.RolEmpleados.FirstOrDefault(a => a.id == Id);
        }
    }
} 