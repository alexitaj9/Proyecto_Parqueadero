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
    public class VerEmpleadoModel : PageModel
    {
        //Instancia
        private readonly IRepositorioEmpleado repositorioEmpleado;
        private readonly IRepositorioRolEmpleado repositorioRolEmpleado;

        //Propiedades
        public Empleado empleado { get; set; }
        public List<SelectListItem> rolEmpleados { get; set; }
        public int rolEmpleadoId { get; set; }

        //Constructor
        public VerEmpleadoModel(IRepositorioEmpleado repositorioEmpleado, IRepositorioRolEmpleado repositorioRolEmpleado) {
            //Asignar
            this.repositorioEmpleado = repositorioEmpleado;
            this.repositorioRolEmpleado = repositorioRolEmpleado;

            //Select
            rolEmpleados = repositorioRolEmpleado.getAllRolEmpleado().Select(
                r => new SelectListItem {
                    Text = r.nombre,
                    Value = Convert.ToString(r.id)
                }
            ).ToList();
        }

        public void OnGet(int id) {
            empleado = repositorioEmpleado.getEmpleado(id);
        }

        //Request POST
        public IActionResult OnPost(Empleado empleado, int rolEmpleadoId) {
            if(ModelState.IsValid){
                try{
                    //Declarar
                    RolEmpleado rolEmpleado = repositorioRolEmpleado.getRolEmpleado(rolEmpleadoId);

                    //Crear registro
                    repositorioEmpleado.editEmpleado(empleado);
                    
                    //Asignacion rolEmpleado
                    empleado.rolEmpleado = rolEmpleado;

                    //Actualizar registro
                    repositorioEmpleado.editEmpleado(empleado);

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
