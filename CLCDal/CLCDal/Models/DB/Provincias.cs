using System;
using System.Collections.Generic;

namespace CLCDal.Models.DB
{
    public partial class Provincias
    {
        public Provincias()
        {
            Direcciones = new HashSet<Direcciones>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Direcciones> Direcciones { get; set; }
    }
}
