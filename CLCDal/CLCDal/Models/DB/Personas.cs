using System;
using System.Collections.Generic;

namespace CLCDal.Models.DB
{
    public partial class Personas
    {
        public Personas()
        {
            Empleados = new HashSet<Empleados>();
            PerDir = new HashSet<PerDir>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public virtual ICollection<Empleados> Empleados { get; set; }
        public virtual ICollection<PerDir> PerDir { get; set; }
    }
}
