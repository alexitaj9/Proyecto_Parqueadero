using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Parqueadero.App.Dominio;

namespace Parqueadero.App.Persistencia{
    public class RepositorioEspacioParqueadero : IRepositorioEspacioParqueadero
    {
        private readonly AppContext _contexto;

        public RepositorioEspacioParqueadero(AppContext contexto){
            this._contexto = contexto;
        }
        public EspacioParqueadero addEspacioParqueadero(EspacioParqueadero EspacioParqueadero)
        {
            EspacioParqueadero EspacioParqueaderoNueva = _contexto.Add(EspacioParqueadero).Entity;
            _contexto.SaveChanges();
            return EspacioParqueaderoNueva;
        }

        public EspacioParqueadero editEspacioParqueadero(EspacioParqueadero EspacioParqueadero)
        {
            EspacioParqueadero EspacioParqueaderoAEditar = _contexto.EspacioParqueaderos.FirstOrDefault(a => a.id == EspacioParqueadero.id);
            if (EspacioParqueaderoAEditar != null){
                EspacioParqueaderoAEditar.estado = EspacioParqueadero.estado;
                EspacioParqueaderoAEditar.id = EspacioParqueadero.id;
                EspacioParqueaderoAEditar.tipo = EspacioParqueadero.tipo;                
                _contexto.SaveChanges();
            }
            return EspacioParqueaderoAEditar;
        }

        public IEnumerable<EspacioParqueadero> getAllEspacioParqueadero()
        {
            return _contexto.EspacioParqueaderos.Where(p => p.estado == false);
        }

        public EspacioParqueadero getEspacioParqueadero(int Id)
        {
            return _contexto.EspacioParqueaderos.FirstOrDefault(a => a.id == Id);
        }

        public void removeEspacioParqueadero(int Id)
        {
            EspacioParqueadero EspacioParqueadero = _contexto.EspacioParqueaderos.FirstOrDefault(a => a.id == Id);
            if(EspacioParqueadero != null){
                _contexto.EspacioParqueaderos.Remove(EspacioParqueadero);
                _contexto.SaveChanges();
            }
        }
    }
}    