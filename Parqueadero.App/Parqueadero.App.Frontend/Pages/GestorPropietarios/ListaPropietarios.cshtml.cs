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
    public class ListaPropietariosModel : PageModel
    {
        //Instancia repositorio
        private readonly IRepositorioPropietario repositorioPropietario;

        //Propiedades
        public IEnumerable<Propietario> propietarios { get; set; }
        public Propietario nuevoPropietario { get; set; }
        public Propietario editarPropietario { get; set; }

        //Constructor
        public ListaPropietariosModel(IRepositorioPropietario repositorioPropietario){
            //Asignacion
            this.repositorioPropietario = repositorioPropietario;
        }
        
        //Get Propietarios
        public void OnGet()
        {   
            //Objeto Modelo
            propietarios = repositorioPropietario.getAllPropietario();
        }

        //POST Crear Propietario
        public IActionResult OnPost(Propietario nuevoPropietario) {
            if (ModelState.IsValid) {
                try {
                    //Login
                    repositorioPropietario.addPropietario(nuevoPropietario);
                    
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
