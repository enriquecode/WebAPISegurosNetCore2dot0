using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebAPISegurosNetCore2dot0.Models
{
    public partial class CodigoPostal
    {
        public CodigoPostal()
        {
            Colonia = new HashSet<Colonia>();
        }

        public int CodigoPostalId { get; set; }
        public int MunicipioId { get; set; }
        public string CodigoPostalNumero { get; set; }

        public virtual Municipio Municipio { get; set; }
        public virtual ICollection<Colonia> Colonia { get; set; }
    }
}
