using System.Collections.Generic;
using System.Linq;
using Parqueadero.App.Dominio;

namespace Parqueadero.App.Persistencia{
    public class RepositorioPropietario : IRepositorioPropietario
    {
        private readonly AppContext _contexto;

        public RepositorioPropietario(AppContext contexto){
            this._contexto = contexto;
        }
        public Propietario addPropietario(Propietario Propietario)
        {
            Propietario PropietarioNueva = _contexto.Add(Propietario).Entity;
            _contexto.SaveChanges();
            return PropietarioNueva;
        }

        public Propietario editPropietario(Propietario Propietario)
        {
            Propietario PropietarioAEditar = _contexto.Propietarios.FirstOrDefault(a => a.id == Propietario.id);
            if (PropietarioAEditar != null){
                PropietarioAEditar.apellidos = Propietario.apellidos;
                PropietarioAEditar.clave = Propietario.clave;
                PropietarioAEditar.correo = Propietario.correo;
                PropietarioAEditar.identificacion = Propietario.identificacion;
                PropietarioAEditar.nombre = Propietario.nombre;                
                PropietarioAEditar.telefono = Propietario.telefono;
                PropietarioAEditar.fechaNacimiento = Propietario.fechaNacimiento;
                PropietarioAEditar.direccion = Propietario.direccion;
                _contexto.SaveChanges();
            }
            return PropietarioAEditar;
        }

        public IEnumerable<Propietario> getAllPropietario()
        {
            return _contexto.Propietarios;
        }

        public Propietario getPropietario(int id)
        {
            Propietario Propietario = _contexto.Propietarios.FirstOrDefault(a => a.id == id);
            return Propietario;
        }

        public void removePropietario(int Id)
        {
            Propietario Propietario = _contexto.Propietarios.FirstOrDefault(a => a.id == Id);
            if(Propietario != null){
                _contexto.Propietarios.Remove(Propietario);
                _contexto.SaveChanges();
            }
        }
    }
}