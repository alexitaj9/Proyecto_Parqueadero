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

        //Propiedades
        public List<SelectListItem> propietarios { get; set; }
        public int propietarioId { get; set; }
        public List<SelectListItem> tipoVehiculos { get; set; }
        public int tipoVehiculoId { get; set; }
        public Vehiculo vehiculo { get; set; }

        //Constructor
        public VerVehiculoModel(IRepositorioVehiculo repositorioVehiculo, IRepositorioPropietario repositorioPropietario, IRepositorioTipoVehiculo repositorioTipoVehiculo)
        {
            //Asignar
            this.repositorioVehiculo = repositorioVehiculo;
            this.repositorioPropietario = repositorioPropietario;
            this.repositorioTipoVehiculo = repositorioTipoVehiculo;
            
            //Crear objeto
            vehiculo = new Vehiculo();

            //Listas
            propietarios = repositorioPropietario.getAllPropietario().Select(
                p => new SelectListItem{
                    Text = p.nombre,
                    Value = Convert.ToString(p.id)
                }
            ).ToList();

            tipoVehiculos = repositorioTipoVehiculo.getAllTipoVehiculo().Select(
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
        public IActionResult OnPost(Vehiculo vehiculo, int propietarioId, int tipoVehiculoId) {
            if (ModelState.IsValid) {
                try {
                    //Capturar
                    Propietario propietario = repositorioPropietario.getPropietario(propietarioId);
                    TipoVehiculo tipoVehiculo = repositorioTipoVehiculo.getTipoVehiculo(tipoVehiculoId);
                    
                    //Actualizar
                    vehiculo.propietario = propietario;
                    vehiculo.tipoVehiculo = tipoVehiculo;

                    //Editar vehiculo
                    repositorioVehiculo.editVehiculo(vehiculo);

                    //Redireccion
                    return RedirectToPage("./ListaVehiculos");
                }
                catch {
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
