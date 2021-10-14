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
    public class CrearReservaModel : PageModel
    {
         private readonly IRepositorioReserva repositorioReserva;
        private readonly IRepositorioPropietario repositorioPropietario;
        private readonly IRepositorioEspacioParqueadero repositorioEspacioParqueadero;

        private readonly IRepositorioVehiculo repositorioVehiculo;
        public List<SelectListItem> propietarios { get; set; }
        public List<SelectListItem> Vehiculo { get; set; }
        public List<SelectListItem> espacioParqueadero { get; set; }
        public int idPropietarios { get; set; }

        public int idVehiculos { get; set; }

        public int idEspacioParqueadero { get; set; }

        public Reserva reserva { get; set; }
        public CrearReservaModel(IRepositorioVehiculo repositorioVehiculo, IRepositorioPropietario repositorioPropietario, IRepositorioReserva repositorioReserva, IRepositorioEspacioParqueadero repositorioEspacioParqueadero)
        {
            this.repositorioVehiculo = repositorioVehiculo;
            this.repositorioPropietario = repositorioPropietario;
            this.repositorioReserva = repositorioReserva;
            this.repositorioEspacioParqueadero = repositorioEspacioParqueadero;
                  

            reserva = new Reserva();

            propietarios = repositorioPropietario.getAllPropietario().Select(
                m => new SelectListItem{
                    Text = m.nombre,
                    Value = Convert.ToString(m.id)
                }
            ).ToList();

            Vehiculo = repositorioVehiculo.getAllVehiculo().Select(
                m => new SelectListItem{
                    Text = m.placa,
                    Value = Convert.ToString(m.id)
                }
            ).ToList();

            espacioParqueadero = repositorioEspacioParqueadero.getAllEspacioParqueadero().Select(
                m => new SelectListItem{
                    Text = m.tipo,
                    Value = Convert.ToString(m.id)
                }
            ).ToList();
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost(Reserva reserva, int idPropietarios, int idVehiculos, int idEspacioParqueadero)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Propietario propietario = repositorioPropietario.getPropietario(idPropietarios);
                    Vehiculo Vehiculo = repositorioVehiculo.getVehiculo(idVehiculos);
                    EspacioParqueadero espacioParqueaderoSeleccionado = repositorioEspacioParqueadero.getEspacioParqueadero(idEspacioParqueadero);

                    repositorioReserva.addReserva(reserva);

                    reserva.propietario=propietario;
                    reserva.vehiculo=Vehiculo;
                    reserva.espacioParqueadero=espacioParqueaderoSeleccionado;

                    //Console.WriteLine(propietario.nombre);

                    repositorioReserva.editReserva(reserva);
                    return RedirectToPage("./ListaReservas");
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
