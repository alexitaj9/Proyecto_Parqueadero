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
    public class ListaVehiculosModel : PageModel
    {
        //Instancia repositorio
        private readonly IRepositorioPropietario repositorioPropietario;
        private readonly IRepositorioTipoVehiculo repositorioTipoVehiculo;
        private readonly IRepositorioVehiculo repositorioVehiculo;
        
        
        //Propiedades
        public List<SelectListItem> propietarios { get; set; }
        public List<SelectListItem> tipoVehiculos { get; set; }
        public IEnumerable<Vehiculo> vehiculos { get; set; }        
        public int propietarioId { get; set; }
        public int tipoVehiculoId { get; set; }
        public Vehiculo nuevoVehiculo { get; set; }
        

        //Constructor
        public ListaVehiculosModel(IRepositorioVehiculo repositorioVehiculo, IRepositorioTipoVehiculo repositorioTipoVehiculo, IRepositorioPropietario repositorioPropietario){
            //Asignacion
            this.repositorioVehiculo = repositorioVehiculo;
            this.repositorioTipoVehiculo = repositorioTipoVehiculo;
            this.repositorioPropietario = repositorioPropietario;

            //Crear objeto
            nuevoVehiculo = new Vehiculo();

            //Listas
            propietarios = repositorioPropietario.getAllPropietario().Select(
                p => new SelectListItem{
                    Text = p.nombre,
                    Value = Convert.ToString(p.id)
                }
            ).ToList();

            tipoVehiculos = repositorioTipoVehiculo.getAllTipoVehiculo().Select(
                tv => new SelectListItem{
                    Text = tv.nombre,
                    Value = Convert.ToString(tv.id)
                }
            ).ToList();
        }
        
        //Request Get
        public void OnGet()
        {   
            try{
                //Objeto Modelo
                vehiculos = repositorioVehiculo.getAllVehiculo();
            }
            catch(NullReferenceException ex){
                Console.WriteLine(ex);
            }   
        }

        //Request POST
        public IActionResult OnPost(Vehiculo nuevoVehiculo, int propietarioId, int tipoVehiculoId)
        {
            if (ModelState.IsValid) {
                try {
                    //Capturar
                    Propietario propietario = repositorioPropietario.getPropietario(propietarioId);
                    TipoVehiculo tipoVehiculo = repositorioTipoVehiculo.getTipoVehiculo(tipoVehiculoId);

                    //Agregar vehiculo
                    repositorioVehiculo.addVehiculo(nuevoVehiculo);

                    //Asignar
                    nuevoVehiculo.propietario = propietario;
                    nuevoVehiculo.tipoVehiculo = tipoVehiculo;

                    //Editar
                    repositorioVehiculo.editVehiculo(nuevoVehiculo);

                    //Retorno
                    return RedirectToPage("./ListaVehiculos");
                }
                catch (Exception e) {
                    //Imprimir
                    Console.WriteLine(e);

                    //Retorno
                    return RedirectToPage("../Error");
                }
            }
            else
            {
                //Retorno
                return Page();
            }
        }
    }
}
