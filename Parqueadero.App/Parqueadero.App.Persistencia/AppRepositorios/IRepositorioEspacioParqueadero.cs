using System.Collections.Generic;
using Parqueadero.App.Dominio;

namespace Parqueadero.App.Persistencia{

    public interface IRepositorioEspacioParqueadero{
        //Crear espacio parqueadero
        EspacioParqueadero addEspacioParqueadero(EspacioParqueadero espacioParqueadero);
        
        //Consultas espacio parqueadero
        IEnumerable<EspacioParqueadero> getAllEspacioParqueadero();
        EspacioParqueadero getEspacioParqueadero(int Id);
        
        //Actualizar espacio parqueadero
        EspacioParqueadero editEspacioParqueadero(EspacioParqueadero espacioParqueadero);

        //Eliminar espacio parqueadero
        void removeEspacioParqueadero(int Id);
    }
}