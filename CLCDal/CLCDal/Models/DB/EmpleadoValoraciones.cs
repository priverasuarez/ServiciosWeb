using System;
using System.Collections.Generic;

namespace CLCDal.Models.DB
{
    public partial class EmpleadoValoraciones
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public int ValoracionId { get; set; }

        public virtual Empleados Empleado { get; set; }
        public virtual Valoraciones Valoracion { get; set; }
    }
}
