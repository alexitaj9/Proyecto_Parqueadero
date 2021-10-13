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
        private readonly IRepositorioReserva repositorioReserva;
        
        //Propiedades
        public IEnumerable<Reserva> reservas { get; set; }
        

        //Constructor
        public ListaReservasModel(IRepositorioReserva repositorioReserva){
            //Asignacion
            this.repositorioReserva = repositorioReserva;                     
        }
        
        //Get Vehiculos
          
        public void OnGet()
        {   
            try{
                //Objeto Modelo
            reservas = repositorioReserva.getAllReserva(); 
            }
            catch(NullReferenceException ex){
                Console.WriteLine(ex);
            }
            
        }

      

       
    }
}
