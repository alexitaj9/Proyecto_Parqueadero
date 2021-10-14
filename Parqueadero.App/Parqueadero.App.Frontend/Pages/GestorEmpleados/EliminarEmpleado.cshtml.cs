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
    public class EliminarEmpleadoModel : PageModel
    {
        //Instancia
        private readonly IRepositorioEmpleado repositorioEmpleado;

        //Constructor
        public EliminarEmpleadoModel(IRepositorioEmpleado repositorioEmpleado) {
            //Asignar
            this.repositorioEmpleado = repositorioEmpleado;
        }
        public IActionResult OnGet(int id)
        {   
            //Eliminar
            repositorioEmpleado.removeEmpleado(id);

            //Retorno
            return RedirectToPage("./ListaEmpleados");
        }
    }
}
