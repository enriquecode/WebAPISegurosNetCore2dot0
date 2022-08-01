using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebAPISegurosNetCore2dot0.Models
{
    public partial class Colonia
    {
        public int ColoniaId { get; set; }
        public int CodigoPostalId { get; set; }
        public string ColoniaNombre { get; set; }

        public virtual CodigoPostal CodigoPostal { get; set; }
    }
}
