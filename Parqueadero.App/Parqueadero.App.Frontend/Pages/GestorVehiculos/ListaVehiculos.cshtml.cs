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
        private readonly IRepositorioVehiculo repositorioVehiculo;
        
        //Propiedades
        public IEnumerable<Vehiculo> vehiculos { get; set; }
        

        //Constructor
        public ListaVehiculosModel(IRepositorioVehiculo repositorioVehiculo){
            //Asignacion
            this.repositorioVehiculo = repositorioVehiculo;  
                     
        }
        
        //Get Vehiculos
          
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

      

       
    }
}
