using System.Collections.Generic;
using System.Linq;
using Parqueadero.App.Dominio;

namespace Parqueadero.App.Persistencia{
    public class RepositorioEmpleado : IRepositorioEmpleado
    {
        private readonly AppContext _contexto;

        public RepositorioEmpleado(AppContext contexto){
            this._contexto = contexto;
        }
        public Empleado addEmpleado(Empleado Empleado)
        {
            Empleado EmpleadoNueva = _contexto.Add(Empleado).Entity;
            _contexto.SaveChanges();
            return EmpleadoNueva;
        }

        public Empleado editEmpleado(Empleado Empleado)
        {
            Empleado EmpleadoAEditar = _contexto.Empleados.FirstOrDefault(a => a.id == Empleado.id);
            if (EmpleadoAEditar != null){
                EmpleadoAEditar.apellidos = Empleado.apellidos;
                EmpleadoAEditar.clave = Empleado.clave;
                EmpleadoAEditar.correo = Empleado.correo;
                EmpleadoAEditar.identificacion = Empleado.identificacion;
                EmpleadoAEditar.nombre = Empleado.nombre;
                EmpleadoAEditar.rolEmpleado = Empleado.rolEmpleado;
                EmpleadoAEditar.telefono = Empleado.telefono;
                _contexto.SaveChanges();
            }
            return EmpleadoAEditar;
        }

        public IEnumerable<Empleado> getAllEmpleado()
        {
            return _contexto.Empleados;
        }

        public Empleado getEmpleado(int Id)
        {
            return _contexto.Empleados.FirstOrDefault(a => a.id == Id);
        }

        public void removeEmpleado(int Id)
        {
            Empleado Empleado = _contexto.Empleados.FirstOrDefault(a => a.id == Id);
            if(Empleado != null){
                _contexto.Empleados.Remove(Empleado);
                _contexto.SaveChanges();
            }
        }
    }
}