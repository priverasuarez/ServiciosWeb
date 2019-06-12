using System;
using System.Collections.Generic;

namespace CLCDal.Models.DB
{
    public partial class Empleados
    {
        public Empleados()
        {
            EmpleadoValoraciones = new HashSet<EmpleadoValoraciones>();
            EmpleadosEmails = new HashSet<EmpleadosEmails>();
        }

        public int Id { get; set; }
        public int? PersonaId { get; set; }
        public int? CategoriaId { get; set; }
        public int? NumEmpleado { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int? JornadaId { get; set; }

        public virtual Categorias Categoria { get; set; }
        public virtual Jornadas Jornada { get; set; }
        public virtual Personas Persona { get; set; }
        public virtual ICollection<EmpleadoValoraciones> EmpleadoValoraciones { get; set; }
        public virtual ICollection<EmpleadosEmails> EmpleadosEmails { get; set; }
    }
}
