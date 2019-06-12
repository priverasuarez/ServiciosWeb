using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BecaAvanade.Modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebServiceAPI001.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        List<Empleado> empleados;
       private void llenarEmpleados()
        {
            empleados = new List<Empleado>();
            if (empleados.Count > 0) return;

            Empleado emp1 = new Empleado()
            {
                Nombre = "Patricia",
                Apellido = "Apellidofalso",
                Dni = "DNIFALSONOREAL",
                Id = 1,
                Email = "emailfalso@falso.com",
                Departamento = "Departamento de Mentira",
                Puesto = EPuesto.Intern

            };
            Empleado emp2 = new Empleado()
            {
                Nombre = "Jorge",
                Apellido  ="Apellidofalso",
                Dni = "DNIFALSONOREAL",
                Id = 2,
                Email = "emailfalso@falso.com",
                Departamento = "Departamento de Mentira",
                Puesto = EPuesto.Intern
            };

            empleados.Add(emp1);
            empleados.Add(emp2);


        }

   
        [HttpGet]
        public IEnumerable<Empleado> Get()
        {
            llenarEmpleados();
            return new Empleado[] { empleados[0],empleados[1]};
        }

        // GET: api/Employees/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Empleado> Get(int id)
        {
            llenarEmpleados();
            Empleado res = this.empleados.FirstOrDefault(e => e.Id == id);
            if (res == null ) return NotFound();
            return res;
        }

        // POST: api/Employees
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Empleado empleadoborrar = this.empleados.FirstOrDefault(e => e.Id == id);
            empleados.Remove(empleadoborrar);
            Console.Write("Borrado con exito");
        }
    }
}
//Esto ha sido publicado para el uso del resto de aparatos publicandolo a la carpeta donde esta mi servidor propio.
//llamada: inetpub

//Para publicar : solution explorer -> project -> click derecho -> publish