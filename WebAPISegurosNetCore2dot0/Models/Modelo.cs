using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebAPISegurosNetCore2dot0.Models
{
    public partial class Modelo
    {
        public Modelo()
        {
            Descripcion = new HashSet<Descripcion>();
        }

        public int IdModelo { get; set; }
        public int IdSubMarca { get; set; }
        public int Modelo1 { get; set; }

        public virtual SubMarca IdSubMarcaNavigation { get; set; }
        public virtual ICollection<Descripcion> Descripcion { get; set; }
    }
}
