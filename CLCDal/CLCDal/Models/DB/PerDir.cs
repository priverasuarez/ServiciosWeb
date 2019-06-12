using System;
using System.Collections.Generic;

namespace CLCDal.Models.DB
{
    public partial class PerDir
    {
        public int Id { get; set; }
        public int PerId { get; set; }
        public int DirId { get; set; }

        public virtual Direcciones Dir { get; set; }
        public virtual Personas Per { get; set; }
    }
}
