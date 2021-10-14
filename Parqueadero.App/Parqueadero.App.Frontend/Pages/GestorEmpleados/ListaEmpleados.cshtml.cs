using System.Net.Mime;
using System.Collections.Concurrent;
using System.Runtime.Serialization;
using System.Runtime.CompilerServices;
using System.Globalization;
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
    public class ListaEmpleadosModel : PageModel
    {
        //Instancia
        private readonly IRepositorioEmpleado repositorioEmpleado;
        private readonly IRepositorioRolEmpleado repositorioRolEmpleado;

        //Propiedades
        public IEnumerable<Empleado> empleados { get; set; }
        public Empleado nuevoEmpleado { get; set; }
        public List<SelectListItem> rolEmpleados { get; set; }
        public int rolEmpleadoId { get; set; }
        
        //Constructor
        public ListaEmpleadosModel(IRepositorioEmpleado repositorioEmpleado, IRepositorioRolEmpleado repositorioRolEmpleado) {
            //Asignacion
            this.repositorioEmpleado = repositorioEmpleado;
            this.repositorioRolEmpleado = repositorioRolEmpleado;
            
            //Crear objeto
            nuevoEmpleado = new Empleado();

            //Select
            rolEmpleados = repositorioRolEmpleado.getAllRolEmpleado().Select(
                r => new SelectListItem {
                    Text = r.nombre,
                    Value = Convert.ToString(r.id)
                }
            ).ToList();
        }

        //Request GET
        public void OnGet()
        {
            empleados = repositorioEmpleado.getAllEmpleado();
        }

        //Request POST
        public IActionResult OnPost(Empleado nuevoEmpleado, int rolEmpleadoId) {
            if(ModelState.IsValid){
                try{
                    //Declarar
                    RolEmpleado rolEmpleado = repositorioRolEmpleado.getRolEmpleado(rolEmpleadoId);

                    //Crear registro
                    repositorioEmpleado.addEmpleado(nuevoEmpleado);
                    
                    //Asignacion rolEmpleado
                    nuevoEmpleado.rolEmpleado = rolEmpleado;

                    //Actualizar registro
                    repositorioEmpleado.editEmpleado(nuevoEmpleado);

                    //Redireccion
                    return RedirectToPage("./ListaEmpleados");
                }
                catch (Exception e) {
                    //Imprimir
                    Console.WriteLine(e.Message);

                    //Retorno
                    return RedirectToPage("../Error");
                }
            }
            else{
                return Page();
            }
        }

    }
}