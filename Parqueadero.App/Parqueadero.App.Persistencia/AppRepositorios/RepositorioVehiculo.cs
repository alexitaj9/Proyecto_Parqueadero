using System.Collections.Generic;
using System.Linq;
using Parqueadero.App.Dominio;

namespace Parqueadero.App.Persistencia{
    public class RepositorioVehiculo : IRepositorioVehiculo
    {
        private readonly AppContext _contexto;

        public RepositorioVehiculo(AppContext contexto){
            this._contexto = contexto;
        }
        public Vehiculo addVehiculo(Vehiculo Vehiculo)
        {
            Vehiculo VehiculoNueva = _contexto.Add(Vehiculo).Entity;
            _contexto.SaveChanges();
            return VehiculoNueva;
        }

        public Vehiculo editVehiculo(Vehiculo Vehiculo)
        {
            Vehiculo VehiculoAEditar = _contexto.Vehiculos.FirstOrDefault(a => a.id == Vehiculo.id);
            if (VehiculoAEditar != null){
                VehiculoAEditar.id = Vehiculo.id;     
                VehiculoAEditar.color = Vehiculo.color;
                VehiculoAEditar.marca = Vehiculo.marca;
                VehiculoAEditar.modelo = Vehiculo.modelo;
                VehiculoAEditar.observaciones = Vehiculo.observaciones;
                VehiculoAEditar.placa = Vehiculo.placa;
                VehiculoAEditar.propietario = Vehiculo.propietario;
                VehiculoAEditar.tipoVehiculo = Vehiculo.tipoVehiculo;
                _contexto.SaveChanges();
            }
            return VehiculoAEditar;
        }

        public IEnumerable<Vehiculo> getAllVehiculo()
        {
            return _contexto. Vehiculos;
        }

        public Vehiculo getVehiculo(int id)
        {
            return _contexto.Vehiculos.FirstOrDefault(a => a.id == id);
        }

        public void removeVehiculo(int id)
        {
            Vehiculo Vehiculo = _contexto.Vehiculos.FirstOrDefault(a => a.id == id);
            if(Vehiculo != null){
                _contexto.Vehiculos.Remove(Vehiculo);
                _contexto.SaveChanges();
            }
        }
    }
}