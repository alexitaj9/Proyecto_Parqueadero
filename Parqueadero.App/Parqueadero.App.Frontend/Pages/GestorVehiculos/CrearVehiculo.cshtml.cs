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
    public class CrearVehiculoModel : PageModel
    {
        private readonly IRepositorioVehiculo repositorioVehiculo;
        private readonly IRepositorioPropietario repositorioPropietario;

        private readonly IRepositorioTipoVehiculo repositorioTipoVehiculo;
        public List<SelectListItem> propietarios { get; set; }
        public List<SelectListItem> tipoVehiculo { get; set; }
        public int idPropietarios { get; set; }

        public int idVehiculos { get; set; }

        public int idTipoVehiculos { get; set; }

        public Vehiculo vehiculo { get; set; }
        public CrearVehiculoModel(IRepositorioVehiculo repositorioVehiculo, IRepositorioPropietario repositorioPropietario, IRepositorioTipoVehiculo repositorioTipoVehiculo)
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
        public void OnGet()
        {

        }

        public IActionResult OnPost(Vehiculo vehiculo, int idPropietarios, int idVehiculos, int idTipoVehiculos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Propietario propietario = repositorioPropietario.getPropietario(idPropietarios);
                    TipoVehiculo tipoVehiculo = repositorioTipoVehiculo.getTipoVehiculo(idTipoVehiculos);

                    repositorioVehiculo.addVehiculo(vehiculo);

                    vehiculo.propietario=propietario;
                    vehiculo.tipoVehiculo=tipoVehiculo;

                    repositorioVehiculo.editVehiculo(vehiculo);
                    return RedirectToPage("./ListaVehiculos");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
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
