using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebAPISegurosNetCore2dot0.Models
{
    public partial class SubMarca
    {
        public SubMarca()
        {
            Modelo = new HashSet<Modelo>();
        }

        public int IdSubMarca { get; set; }
        public int IdMarca { get; set; }
        public string SubMarca1 { get; set; }

        public virtual Marca IdMarcaNavigation { get; set; }
        public virtual ICollection<Modelo> Modelo { get; set; }
    }
}
