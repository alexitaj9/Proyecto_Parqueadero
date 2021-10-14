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
    public class VerReservaModel : PageModel
    {
         //Instancia
        private IRepositorioVehiculo repositorioVehiculo;
        private IRepositorioPropietario repositorioPropietario;
        private IRepositorioReserva repositorioReserva;
        private IRepositorioEspacioParqueadero repositorioEspacioParqueadero;

        //Propietarios
        public Reserva reserva { get; set; }

        public int idPropietarios { get; set; }
        public int idVehiculos { get; set; }
        public int idEspacioParqueadero { get; set; }
        public List<SelectListItem> propietarios { get; set; }
        public List<SelectListItem> Vehiculo { get; set; }
        public List<SelectListItem> espacioParqueadero { get; set; }

        //Constructor
        public VerReservaModel(IRepositorioVehiculo repositorioVehiculo, IRepositorioPropietario repositorioPropietario, IRepositorioReserva repositorioReserva, IRepositorioEspacioParqueadero repositorioEspacioParqueadero)
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

        //Request GET
        public void OnGet(int id)
        {
            reserva = repositorioReserva.getReserva(id);
        }

        //Request POST
        public IActionResult OnPost(Reserva reserva, int idPropietarios, int idVehiculos, int idEspacioParqueadero)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Propietario propietario = repositorioPropietario.getPropietario(idPropietarios);
                    Vehiculo Vehiculo = repositorioVehiculo.getVehiculo(idVehiculos);
                    EspacioParqueadero espacioParqueaderoSeleccionado = repositorioEspacioParqueadero.getEspacioParqueadero(idEspacioParqueadero);

                    
                    //Actualizar
                    
                    reserva.propietario=propietario;
                    reserva.vehiculo=Vehiculo;
                    reserva.espacioParqueadero=espacioParqueaderoSeleccionado;

                    repositorioReserva.editReserva(reserva);

                    //Console.WriteLine(vehiculoactualizado);

                    //Redireccion
                    return RedirectToPage("./ListaReservas");
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
