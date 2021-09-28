using System.Collections.Generic;
using System.Linq;
using Parqueadero.App.Dominio;

namespace Parqueadero.App.Persistencia{
    public class RepositorioReserva : IRepositorioReserva
    {
        private readonly AppContext _contexto;

        public RepositorioReserva(AppContext contexto){
            this._contexto = contexto;
        }
        public Reserva addReserva(Reserva Reserva)
        {
            Reserva ReservaNueva = _contexto.Add(Reserva).Entity;
            _contexto.SaveChanges();
            return ReservaNueva;
        }

        public Reserva editReserva(Reserva Reserva)
        {
            Reserva ReservaAEditar = _contexto.Reservas.FirstOrDefault(a => a.id == Reserva.id);
            if (ReservaAEditar != null){
                ReservaAEditar.fechaReserva = Reserva.fechaReserva;
                ReservaAEditar.espacioParqueadero = Reserva.espacioParqueadero;
                ReservaAEditar.fechaReserva = Reserva.fechaReserva;
                ReservaAEditar.finReserva = Reserva.finReserva; 
                ReservaAEditar.id = Reserva.id;     
                ReservaAEditar.inicioReserva = Reserva.inicioReserva;
                ReservaAEditar.propietario = Reserva.propietario; 
                ReservaAEditar.vehiculo = Reserva.vehiculo;
                _contexto.SaveChanges();
            }
            return ReservaAEditar;
        }

        public IEnumerable<Reserva> getAllReserva()
        {
            return _contexto. Reservas;
        }

        public Reserva getReserva(int Id)
        {
            return _contexto.Reservas.FirstOrDefault(a => a.id == Id);
        }

        public void removeReserva(int Id)
        {
            Reserva Reserva = _contexto.Reservas.FirstOrDefault(a => a.id == Id);
            if(Reserva != null){
                _contexto.Reservas.Remove(Reserva);
                _contexto.SaveChanges();
            }
        }
    }
} 