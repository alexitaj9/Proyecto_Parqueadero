using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Parqueadero.App.Dominio;
using Parqueadero.App.Persistencia;

namespace Parqueadero.App.Frontend.Pages
{
    public class EliminarReservaModel : PageModel
    {
        private readonly IRepositorioReserva repositorioReserva;
        private readonly IRepositorioEspacioParqueadero repositorioEspacioParqueadero;

        //Constructor
        public EliminarReservaModel(IRepositorioReserva repositorioReserva, IRepositorioEspacioParqueadero repositorioEspacioParqueadero) {
            //Asignacion
            this.repositorioReserva = repositorioReserva;
            this.repositorioEspacioParqueadero = repositorioEspacioParqueadero;
        }

        //Request GET
        public IActionResult OnGet(int id)
        {
            //Asignar
            Reserva reservaAEliminar = repositorioReserva.getReserva(id);
            EspacioParqueadero espacioParqueaderoALiberar = reservaAEliminar.espacioParqueadero;

            //Asignar
            espacioParqueaderoALiberar.estado = false;

            //Actualizar
            repositorioEspacioParqueadero.editEspacioParqueadero(espacioParqueaderoALiberar);

            //Repositorio
            repositorioReserva.removeReserva(id);

            //Redireccion
            return RedirectToPage("./ListaReservas");
        }
    }
}
