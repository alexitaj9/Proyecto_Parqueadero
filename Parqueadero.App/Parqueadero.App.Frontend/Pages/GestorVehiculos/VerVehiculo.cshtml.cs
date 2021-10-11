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
    public class VerVehiculoModel : PageModel
    {
        //Instancia
        private IRepositorioVehiculo repositorioVehiculo;

        //Propietarios
        public Vehiculo vehiculo { get; set; }

        //Constructor
        public VerVehiculoModel(IRepositorioVehiculo repositorioVehiculo)
        {
            this.repositorioVehiculo = repositorioVehiculo;
            vehiculo = new Vehiculo();
        }

        //Request GET
        public void OnGet(int id)
        {
            vehiculo = repositorioVehiculo.getVehiculo(id);
        }

        //Request POST
        public IActionResult OnPost(Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    //Actualizar
                    Vehiculo vehiculoactualizado=repositorioVehiculo.editVehiculo(vehiculo);

                    Console.WriteLine(vehiculoactualizado);

                    //Redireccion
                    return RedirectToPage("./ListaVehiculos");
                }
                catch
                {
                    //Redireccion
                    return RedirectToPage("../Error");
                }
            }
            else
            {
                return Page();
            }
        }
    }
}
