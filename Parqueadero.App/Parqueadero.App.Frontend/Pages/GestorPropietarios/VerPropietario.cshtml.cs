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
        private IRepositorioPropietario repositorioPropietario;
        public Propietario propietario { get; set; }
        public VerPropietarioModel(IRepositorioPropietario repositorioPropietario){
            this.repositorioPropietario = repositorioPropietario;
        }
        public void OnGet(int id)
        {
            propietario=repositorioPropietario.getPropietario(id);
        }
    }
}
