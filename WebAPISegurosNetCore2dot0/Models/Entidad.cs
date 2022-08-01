using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebAPISegurosNetCore2dot0.Models
{
    public partial class Entidad
    {
        public Entidad()
        {
            Municipio = new HashSet<Municipio>();
        }

        public int EntidadId { get; set; }
        public string ClaveEntidad { get; set; }
        public string EntidadNombre { get; set; }

        public virtual ICollection<Municipio> Municipio { get; set; }
    }
}
