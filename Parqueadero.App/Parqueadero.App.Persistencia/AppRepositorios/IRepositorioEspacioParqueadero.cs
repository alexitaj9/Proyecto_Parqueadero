using System.Collections.Generic;
using Parqueadero.App.Dominio;

namespace Parqueadero.App.Persistencia{

    public interface IRepositorioEspacioParqueadero{
        IEnumerable<EspacioParqueadero> getAllEspacioParqueadero();
        EspacioParqueadero addEspacioParqueadero(EspacioParqueadero espacioParqueadero);
        EspacioParqueadero editEspacioParqueadero(EspacioParqueadero espacioParqueadero);
        EspacioParqueadero getEspacioParqueadero(int Id);
        void removeEspacioParqueadero(int Id);
    }
}