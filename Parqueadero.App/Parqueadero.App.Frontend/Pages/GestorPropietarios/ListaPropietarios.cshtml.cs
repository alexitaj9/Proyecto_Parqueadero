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
        private readonly IRepositorioPropietario repositorioPropietario;
        public IEnumerable<Propietario> propietarios;
        public ListaPropietariosModel(IRepositorioPropietario repositorioPropietario){
            this.repositorioPropietario = repositorioPropietario;
        }
        public void OnGet()
        {
            propietarios=repositorioPropietario.getAllPropietario();
        }
    }
}
