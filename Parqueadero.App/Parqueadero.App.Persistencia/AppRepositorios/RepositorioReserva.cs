using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
                ReservaAEditar.id = Reserva.id;
                ReservaAEditar.propietario = Reserva.propietario;
                ReservaAEditar.espacioParqueadero = Reserva.espacioParqueadero;
                ReservaAEditar.vehiculo = Reserva.vehiculo;
                ReservaAEditar.fechaReserva = Reserva.fechaReserva;
                ReservaAEditar.inicioReserva = Reserva.inicioReserva;
                ReservaAEditar.fechaReserva = Reserva.fechaReserva;
                ReservaAEditar.finReserva = Reserva.finReserva; 
                _contexto.SaveChanges();
            }
            return ReservaAEditar;
        }

        public IEnumerable<Reserva> getAllReserva()
        {
            return _contexto.Reservas.Include("propietario").Include("vehiculo").Include("espacioParqueadero");
        }

        public Reserva getReserva(int Id)
        {
            return _contexto.Reservas.FirstOrDefault(a => a.id == Id);
        }

        public void removeReserva(int Id)
        {
            Reserva Reserva = _contexto.Reservas.Include("propietario").Include("vehiculo").Include("espacioParqueadero").FirstOrDefault(a => a.id == Id);
            if(Reserva != null){
                _contexto.Reservas.Remove(Reserva);
                _contexto.SaveChanges();
            }
        }
    }
} 