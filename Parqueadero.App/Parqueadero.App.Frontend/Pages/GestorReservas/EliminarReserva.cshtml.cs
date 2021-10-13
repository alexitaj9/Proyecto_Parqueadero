using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Parqueadero.App.Persistencia;

namespace Parqueadero.App.Frontend.Pages
{
    public class EliminarReservaModel : PageModel
    {
        private readonly IRepositorioReserva repositorioReserva;

        //Constructor
        public EliminarReservaModel(IRepositorioReserva repositorioReserva) {
            //Asignacion
            this.repositorioReserva = repositorioReserva;
        }
        public IActionResult OnGet(int id)
        {
            //Repositorio
            repositorioReserva.removeReserva(id);

            //Redireccion
            return RedirectToPage("./ListaReservas");
        }
    }
}
