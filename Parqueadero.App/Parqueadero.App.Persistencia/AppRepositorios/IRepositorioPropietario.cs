using System.Collections.Generic;
using Parqueadero.App.Dominio;

namespace Parqueadero.App.Persistencia{

    public interface IRepositorioPropietario{
        IEnumerable<Propietario> getAllPropietario();
        Propietario addPropietario(Propietario propietario);
        Propietario editPropietario(Propietario propietario);
        Propietario getPropietario(int Id);
        void removePropietario(int Id);
    }
}