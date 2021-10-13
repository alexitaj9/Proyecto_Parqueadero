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
        public RolEmpleado addRolEmpleado(RolEmpleado RolEmpleado)
        {
            RolEmpleado RolEmpleadoNueva = _contexto.Add(RolEmpleado).Entity;
            _contexto.SaveChanges();
            return RolEmpleadoNueva;
        }

        public RolEmpleado editRolEmpleado(RolEmpleado RolEmpleado)
        {
            RolEmpleado RolEmpleadoAEditar = _contexto.RolEmpleados.FirstOrDefault(a => a.id == RolEmpleado.id);
            if (RolEmpleadoAEditar != null){
                RolEmpleadoAEditar.nombre = RolEmpleado.nombre;                
                RolEmpleadoAEditar.id = RolEmpleado.id;                 
                _contexto.SaveChanges();
            }
            return RolEmpleadoAEditar;
        }

        public IEnumerable<RolEmpleado> getAllRolEmpleado()
        {
            return _contexto.RolEmpleados;
        }

        public RolEmpleado getRolEmpleado(int Id)
        {
            return _contexto.RolEmpleados.FirstOrDefault(a => a.id == Id);
        }

        public void removeRolEmpleado(int Id)
        {
            RolEmpleado RolEmpleado = _contexto.RolEmpleados.FirstOrDefault(a => a.id == Id);
            if(RolEmpleado != null){
                _contexto.RolEmpleados.Remove(RolEmpleado);
                _contexto.SaveChanges();
            }
        }
    }
} 