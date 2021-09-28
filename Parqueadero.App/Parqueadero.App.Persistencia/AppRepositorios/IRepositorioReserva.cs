using System.Collections.Generic;
using Parqueadero.App.Dominio;

namespace Parqueadero.App.Persistencia{

    public interface IRepositorioReserva{
        IEnumerable<Reserva> getAllReserva();
        Reserva addReserva(Reserva Reserva);
        Reserva editReserva(Reserva Reserva);
        Reserva getReserva(int Id);
        void removeReserva(int Id);
    }
}