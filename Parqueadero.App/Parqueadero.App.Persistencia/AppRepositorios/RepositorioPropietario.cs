using System;
using System.Collections.Generic;
using System.Linq;
using Parqueadero.App.Dominio;

namespace Parqueadero.App.Persistencia{
    public class RepositorioPropietario : IRepositorioPropietario
    {
        private readonly AppContext _contexto;

        //Constructor
        public RepositorioPropietario(AppContext contexto){
            this._contexto = contexto;
        }

        //Agregar propietario
        public Propietario addPropietario(Propietario Propietario)
        {
            Propietario PropietarioNueva = _contexto.Add(Propietario).Entity;
            _contexto.SaveChanges();
            return PropietarioNueva;
        }

        //Editar propietario
        public Propietario editPropietario(Propietario Propietario)
        {   
            Console.WriteLine(Propietario.id);
            //Capturar
            Propietario PropietarioAEditar = _contexto.Propietarios.FirstOrDefault(p => p.id == Propietario.id);
            
            //Editar
            if (PropietarioAEditar != null) {
                //Asignar
                PropietarioAEditar.nombre = Propietario.nombre;
                PropietarioAEditar.apellidos = Propietario.apellidos;
                PropietarioAEditar.identificacion = Propietario.identificacion;
                PropietarioAEditar.fechaNacimiento = Propietario.fechaNacimiento;
                PropietarioAEditar.direccion = Propietario.direccion;
                PropietarioAEditar.telefono = Propietario.telefono;
                PropietarioAEditar.correo = Propietario.correo;
                PropietarioAEditar.clave = Propietario.clave;

                //Guardar cambios
                _contexto.SaveChanges();
            }

            //Retorno
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

        public void removePropietario(int id)
        {
            Propietario Propietario = _contexto.Propietarios.FirstOrDefault(a => a.id == id);
            if(Propietario != null){
                _contexto.Propietarios.Remove(Propietario);
                _contexto.SaveChanges();
            }
        }
    }
}