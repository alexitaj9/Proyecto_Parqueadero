using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Parqueadero.App.Persistencia;

namespace Parqueadero.App.Frontend.Pages
{
    public class EliminarVehiculoModel : PageModel
    {
        private readonly IRepositorioVehiculo repositorioVehiculo;

        //Constructor
        public EliminarVehiculoModel(IRepositorioVehiculo repositorioVehiculo) {
            //Asignacion
            this.repositorioVehiculo = repositorioVehiculo;
        }
        public IActionResult OnGet(int id)
        {
            //Repositorio
            repositorioVehiculo.removeVehiculo(id);

            //Redireccion
            return RedirectToPage("./ListaVehiculos");
        }
    }
}
