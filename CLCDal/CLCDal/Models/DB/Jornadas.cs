using System;
using System.Collections.Generic;

namespace CLCDal.Models.DB
{
    public partial class Jornadas
    {
        public Jornadas()
        {
            Empleados = new HashSet<Empleados>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? NumHoras { get; set; }

        public virtual ICollection<Empleados> Empleados { get; set; }
    }
}
