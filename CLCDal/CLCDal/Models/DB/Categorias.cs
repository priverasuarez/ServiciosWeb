using System;
using System.Collections.Generic;

namespace CLCDal.Models.DB
{
    public partial class Categorias
    {
        public Categorias()
        {
            Empleados = new HashSet<Empleados>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Empleados> Empleados { get; set; }
    }
}
