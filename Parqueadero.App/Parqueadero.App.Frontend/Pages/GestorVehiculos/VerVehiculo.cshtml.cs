using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Parqueadero.App.Dominio;
using Parqueadero.App.Persistencia;

namespace Parqueadero.App.Frontend.Pages
{
    public class VerVehiculoModel : PageModel
    {
        //Instancia
        private IRepositorioVehiculo repositorioVehiculo;
        private IRepositorioPropietario repositorioPropietario;
        private IRepositorioTipoVehiculo repositorioTipoVehiculo;

        //Propietarios
        public Vehiculo vehiculo { get; set; }

        public int idPropietarios { get; set; }
        public int idTipoVehiculos { get; set; }
        public List<SelectListItem> propietarios { get; set; }
        public List<SelectListItem> tipoVehiculo { get; set; }

        //Constructor
        public VerVehiculoModel(IRepositorioVehiculo repositorioVehiculo, IRepositorioPropietario repositorioPropietario, IRepositorioTipoVehiculo repositorioTipoVehiculo)
        {
            this.repositorioVehiculo = repositorioVehiculo;
            this.repositorioPropietario = repositorioPropietario;
            this.repositorioTipoVehiculo = repositorioTipoVehiculo;

            vehiculo = new Vehiculo();

            propietarios = repositorioPropietario.getAllPropietario().Select(
                m => new SelectListItem{
                    Text = m.nombre,
                    Value = Convert.ToString(m.id)
                }
            ).ToList();

            tipoVehiculo = repositorioTipoVehiculo.getAllTipoVehiculo().Select(
                m => new SelectListItem{
                    Text = m.nombre,
                    Value = Convert.ToString(m.id)
                }
            ).ToList();
        }

        //Request GET
        public void OnGet(int id)
        {
            vehiculo = repositorioVehiculo.getVehiculo(id);
        }

        //Request POST
        public IActionResult OnPost(Vehiculo vehiculo, int idPropietarios, int idTipoVehiculos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Propietario propietario = repositorioPropietario.getPropietario(idPropietarios);
                    TipoVehiculo tipoVehiculo = repositorioTipoVehiculo.getTipoVehiculo(idTipoVehiculos);

                    
                    //Actualizar
                    
                    vehiculo.propietario=propietario;
                    vehiculo.tipoVehiculo=tipoVehiculo;

                    repositorioVehiculo.editVehiculo(vehiculo);

                    //Console.WriteLine(vehiculoactualizado);

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
