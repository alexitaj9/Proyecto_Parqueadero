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
    public class VerPropietarioModel : PageModel
    {   
        //Instancia
        private IRepositorioPropietario repositorioPropietario;
        
        //Propietarios
        public Propietario propietario { get; set; }

        //Constructor
        public VerPropietarioModel(IRepositorioPropietario repositorioPropietario){
            this.repositorioPropietario = repositorioPropietario;
        }

        //Request GET
        public void OnGet(int id)
        {
            propietario = repositorioPropietario.getPropietario(id);
        }

        //Request POST
        public IActionResult OnPost(Propietario propietario) {
             if (ModelState.IsValid) {
                try {
                    //Actualizar
                    repositorioPropietario.editPropietario(propietario);
                    
                    //Redireccion
                    return RedirectToPage("./ListaPropietarios");
                }
                catch {   
                    //Redireccion
                    return RedirectToPage("../Error");
                }
            }
            else {
                return Page();
            }
        }
    }
}
