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
        //Instancia
        private IRepositorioPropietario repositorioPropietario;
        
        //Propieades
        public Propietario propietario { get; set; }        

        //Constructor
        public CrearPropietarioModel(IRepositorioPropietario repositorioPropietario)
        {
            this.repositorioPropietario = repositorioPropietario;
            Propietario propietario = new Propietario();
        }
        
        public IActionResult OnPost(Propietario propietario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Login
                    repositorioPropietario.addPropietario(propietario);
                    
                    //Redireccion
                    return RedirectToPage("./ListaPropietarios");
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
