using System.Collections.Generic;
using Parqueadero.App.Dominio;

namespace Parqueadero.App.Persistencia{

    public interface IRepositorioVehiculo{
        IEnumerable<Vehiculo> getAllVehiculo();
        Vehiculo addVehiculo(Vehiculo vehiculo);
        Vehiculo editVehiculo(Vehiculo vehiculo);
        Vehiculo getVehiculo(int Id);
        void removeVehiculo(int Id);
    }
}