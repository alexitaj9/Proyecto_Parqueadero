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
    public class CrearPropietarioModel : PageModel
    {
        private IRepositorioPropietario repositorioPropietario;
        public Propietario propietario { get; set; }
        public CrearPropietarioModel(IRepositorioPropietario repositorioPropietario)
        {
            this.repositorioPropietario = repositorioPropietario;
            Propietario propietario = new Propietario();
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(Propietario propietario)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    repositorioPropietario.addPropietario(propietario);
                    return RedirectToPage("./ListaPropietarios");
                }
                catch
                {
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
