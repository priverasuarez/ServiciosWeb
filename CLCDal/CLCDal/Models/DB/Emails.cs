using System;
using System.Collections.Generic;

namespace CLCDal.Models.DB
{
    public partial class Emails
    {
        public Emails()
        {
            EmpleadosEmails = new HashSet<EmpleadosEmails>();
        }

        public int Id { get; set; }
        public string Email { get; set; }

        public virtual ICollection<EmpleadosEmails> EmpleadosEmails { get; set; }
    }
}
