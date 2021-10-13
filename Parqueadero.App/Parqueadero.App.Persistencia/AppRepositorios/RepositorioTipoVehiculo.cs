using System.Collections.Generic;
using System.Linq;
using Parqueadero.App.Dominio;

namespace Parqueadero.App.Persistencia{
    public class RepositorioTipoVehiculo : IRepositorioTipoVehiculo
    {
        private readonly AppContext _contexto;

        public RepositorioTipoVehiculo(AppContext contexto){
            this._contexto = contexto;
        }
        public TipoVehiculo addTipoVehiculo(TipoVehiculo TipoVehiculo)
        {
            TipoVehiculo TipoVehiculoNueva = _contexto.Add(TipoVehiculo).Entity;
            _contexto.SaveChanges();
            return TipoVehiculoNueva;
        }

        public TipoVehiculo editTipoVehiculo(TipoVehiculo TipoVehiculo)
        {
            TipoVehiculo TipoVehiculoAEditar = _contexto.TipoVehiculos.FirstOrDefault(a => a.id == TipoVehiculo.id);
            if (TipoVehiculoAEditar != null){
                TipoVehiculoAEditar.id = TipoVehiculo.id;     
                TipoVehiculoAEditar.nombre = TipoVehiculo.nombre;
                _contexto.SaveChanges();
            }
            return TipoVehiculoAEditar;
        }

        public IEnumerable<TipoVehiculo> getAllTipoVehiculo()
        {
            return _contexto.TipoVehiculos;
        }

        public TipoVehiculo getTipoVehiculo(int Id)
        {
            return _contexto.TipoVehiculos.FirstOrDefault(a => a.id == Id);
        }

        public void removeTipoVehiculo(int Id)
        {
            TipoVehiculo TipoVehiculo = _contexto.TipoVehiculos.FirstOrDefault(a => a.id == Id);
            if(TipoVehiculo != null){
                _contexto.TipoVehiculos.Remove(TipoVehiculo);
                _contexto.SaveChanges();
            }
        }
    }
} 