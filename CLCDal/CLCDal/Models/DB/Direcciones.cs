using System;
using System.Collections.Generic;

namespace CLCDal.Models.DB
{
    public partial class Direcciones
    {
        public Direcciones()
        {
            PerDir = new HashSet<PerDir>();
        }

        public int Id { get; set; }
        public string Calle { get; set; }
        public int? Numero { get; set; }
        public string Piso { get; set; }
        public int? Cp { get; set; }
        public int? IdProvincia { get; set; }
        public int? IdPais { get; set; }
        public string Localidad { get; set; }

        public virtual Paises IdPaisNavigation { get; set; }
        public virtual Provincias IdProvinciaNavigation { get; set; }
        public virtual ICollection<PerDir> PerDir { get; set; }
    }
}
