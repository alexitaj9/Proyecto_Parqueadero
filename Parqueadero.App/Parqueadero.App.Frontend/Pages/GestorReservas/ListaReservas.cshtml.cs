using System.Net;
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
    public class ListaReservasModel : PageModel
    {
        //Instancia repositorio
        private readonly IRepositorioEspacioParqueadero repositorioEspacioParqueadero;
        private readonly IRepositorioPropietario repositorioPropietario;
        private readonly IRepositorioReserva repositorioReserva;
        private readonly IRepositorioVehiculo repositorioVehiculo;
        
        //Propiedades
        public List<SelectListItem> espaciosParqueadero { get; set; }
        public List<SelectListItem> propietarios { get; set; }
        public List<SelectListItem> vehiculos { get; set; }
        public IEnumerable<Reserva> reservas { get; set; }
        public Reserva nuevaReserva { get; set; }
        public int propietarioId { get; set; }
        public int vehiculoId { get; set; }
        public int espacioParqueaderoId { get; set; }
        

        //Constructor
        public ListaReservasModel(IRepositorioEspacioParqueadero repositorioEspacioParqueadero, IRepositorioPropietario repositorioPropietario, IRepositorioReserva repositorioReserva, IRepositorioVehiculo repositorioVehiculo){
            //Asignacion
            this.repositorioEspacioParqueadero = repositorioEspacioParqueadero;
            this.repositorioPropietario = repositorioPropietario;
            this.repositorioReserva = repositorioReserva;
            this.repositorioVehiculo = repositorioVehiculo;

            //Creacion objeto
            nuevaReserva = new Reserva();

            //Lista
            espaciosParqueadero = repositorioEspacioParqueadero.getAllEspacioParqueadero().Select(
                ep => new SelectListItem  {
                    Text = (Convert.ToString(ep.id) + " - " + ep.tipo),
                    Value = Convert.ToString(ep.id)
                }
            ).ToList();

            propietarios = repositorioPropietario.getAllPropietario().Select(
                p => new SelectListItem {
                    Text = (p.identificacion + " - " + p.nombre),
                    Value = Convert.ToString(p.id)
                }
            ).ToList();

            vehiculos = repositorioVehiculo.getAllVehiculo().Select(
                v => new SelectListItem {
                    Text = (v.placa + " - " + v.tipoVehiculo.nombre),
                    Value = Convert.ToString(v.id)
                }
            ).ToList();
        }
        
        //Get
        public void OnGet()
        {   
            try {
                //Objeto Modelo
            reservas = repositorioReserva.getAllReserva();
            }
            catch (NullReferenceException ex) {
                Console.WriteLine(ex);
            }   
        }

        public IActionResult OnPost(Reserva nuevaReserva, int PropietarioId, int vehiculoId, int espacioParqueaderoId)
        {
            if (ModelState.IsValid) {
                try {
                    //Capturar
                    Propietario propietario = repositorioPropietario.getPropietario(propietarioId);
                    Vehiculo vehiculo = repositorioVehiculo.getVehiculo(vehiculoId);
                    EspacioParqueadero espacioParqueaderoSeleccionado = repositorioEspacioParqueadero.getEspacioParqueadero(espacioParqueaderoId);

                    //Crear reserva
                    repositorioReserva.addReserva(nuevaReserva);

                    //Asignar
                    nuevaReserva.propietario = propietario;
                    nuevaReserva.vehiculo = vehiculo;
                    nuevaReserva.espacioParqueadero = espacioParqueaderoSeleccionado;

                    //Editar reserva
                    repositorioReserva.editReserva(nuevaReserva);

                    //Retorno
                    return RedirectToPage("./ListaReservas");
                }
                catch (Exception e) {
                    //Imprimir
                    Console.WriteLine(e);

                    //Retorno
                    return RedirectToPage("../Error");
                }
            }
            else {
                return Page();
            }
        }
    }
}
