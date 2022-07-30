using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebAPISegurosNetCore2dot0.Models
{
    public partial class Marca
    {
        public Marca()
        {
            SubMarca = new HashSet<SubMarca>();
        }

        public int IdMarca { get; set; }
        public string Marca1 { get; set; }

        public virtual ICollection<SubMarca> SubMarca { get; set; }
    }
}
