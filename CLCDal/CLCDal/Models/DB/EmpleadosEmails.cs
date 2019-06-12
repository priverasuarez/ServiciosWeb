using System;
using System.Collections.Generic;

namespace CLCDal.Models.DB
{
    public partial class EmpleadosEmails
    {
        public int Id { get; set; }
        public int? IdEmpleado { get; set; }
        public int? IdEmail { get; set; }

        public virtual Emails IdEmailNavigation { get; set; }
        public virtual Empleados IdEmpleadoNavigation { get; set; }
    }
}
