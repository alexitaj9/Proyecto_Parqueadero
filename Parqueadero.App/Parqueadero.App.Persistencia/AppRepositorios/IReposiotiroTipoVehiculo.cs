using System.Collections.Generic;
using Parqueadero.App.Dominio;

namespace Parqueadero.App.Persistencia{

    public interface IRepositorioTipoVehiculo{
        IEnumerable<TipoVehiculo> getAllTipoVehiculo();
        TipoVehiculo addTipoVehiculo(TipoVehiculo tipoVehiculo);
        TipoVehiculo editTipoVehiculo(TipoVehiculo tipoVehiculo);
        TipoVehiculo getTipoVehiculo(int Id);
        void removeTipoVehiculo(int Id);
    }
}