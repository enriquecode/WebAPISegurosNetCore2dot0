using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebAPISegurosNetCore2dot0.Models
{
    public partial class Municipio
    {
        public Municipio()
        {
            CodigoPostal = new HashSet<CodigoPostal>();
        }

        public int MunicipioId { get; set; }
        public int EntidadId { get; set; }
        public string MunicipioNombre { get; set; }

        public virtual Entidad Entidad { get; set; }
        public virtual ICollection<CodigoPostal> CodigoPostal { get; set; }
    }
}
