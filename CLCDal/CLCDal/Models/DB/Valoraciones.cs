using System;
using System.Collections.Generic;

namespace CLCDal.Models.DB
{
    public partial class Valoraciones
    {
        public Valoraciones()
        {
            EmpleadoValoraciones = new HashSet<EmpleadoValoraciones>();
        }

        public int Id { get; set; }
        public string Comentario { get; set; }
        public int? Puntuacion { get; set; }

        public virtual ICollection<EmpleadoValoraciones> EmpleadoValoraciones { get; set; }
    }
}
