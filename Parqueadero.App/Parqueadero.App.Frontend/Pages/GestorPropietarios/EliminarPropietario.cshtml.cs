using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

//Importar
using Parqueadero.App.Dominio;
using Parqueadero.App.Persistencia;

namespace Parqueadero.App.Frontend.Pages
{
    public class EliminarPropietarioModel : PageModel
    {
        //Instancia
        private readonly IRepositorioPropietario repositorioPropietario;

        //Constructor
        public EliminarPropietarioModel(IRepositorioPropietario repositorioPropietario) {
            //Asignacion
            this.repositorioPropietario = repositorioPropietario;
        }

        public IActionResult OnGet(int id)
        {
            //Repositorio
            repositorioPropietario.removePropietario(id);

            //Redireccion
            return RedirectToPage("./ListaPropietarios");
        }
    }
}
